using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Google_Project____Hao_Li
{
    public class IICoperation
    {
        [DllImport("USBIOX.DLL")]
        private static extern UInt32 USBIO_OpenDevice(UInt32 iIndex);

        [DllImport("USBIOX.DLL")]
        private static extern bool USBIO_SetStream(UInt32 iIndex, UInt32 iMode);

        [DllImport("USBIOX.DLL")]
        private static extern bool USBIO_StreamI2C(UInt32 iIndex, UInt32 iWriteLength, UInt32 iWriteBuffer,
            UInt32 iReadLength, UInt32 oReadBuffer);

        private static byte[] _IIcWriteBuffer = new byte[256];
        private static byte[] _IIcReadBuffer = new byte[256];

        private enum Reg
        {
            REG_HOST_STATUS = 0x50,

            REG_DEBUG_MODE = 0x60,
            REG_DATA_READY = 0x61,
            REG_DEBUG_DATA1 = 0x62,
            REG_DEBUG_DATA2 = 0x63,
            REG_DEBUG_DATA3 = 0x64,
            REG_DEBUG_DATA4 = 0x65,
            REG_DEBUG_DATA5 = 0x66,
            REG_DEBUG_DATA6 = 0x67,
            REG_DEBUG_DATA7 = 0x68,
            REG_DEBUG_DATA8 = 0x69,
            REG_DEBUG_DATA9 = 0x6A,
            REG_DEBUG_DATA10 = 0x6B,
            REG_DEBUG_DATA11 = 0x6C,
            REG_DEBUG_DATA12 = 0x6D,
            REG_DEBUG_DATA13 = 0x6E,
            REG_DEBUG_DATA14 = 0x6F,

            REG_DEBUG_MODEB = 0x80,
            REG_DATA_READYB = 0x81,
            REG_DEBUG_DATAB = 0x82,

            REG_DEBUG_MODEC = 0x83,
            REG_DATA_READYC = 0x84,
            REG_DEBUG_DATAC = 0x85,

            REG_POINTER_NUMBER = 0x10,
            REG_POINTER1_DATA = 0x11,
            REG_FORCE_DATA_NUMBER = 0x20,
            REG_FORCE_DATA1 = 0x21,

            REG_DEVICE_ID = 0x02,
            REG_MANUFACTURER_ID = 0x03,
            REG_MODULE_ID = 0x04,
            REG_FW_VERSION = 0x05,

            REG_TASK_ENABLE = 0x0A,

            REG_TEST_REG = 0x1F,

            REG_UART_PRINT_ENABLE = 0xD4,
        };

        private enum Host
        {
            HOST_STATUS_NORMAL = 0x00,
        };

        private enum DataReady
        {
            DATA_READY_CLEAR = 0x00,
        };

        private enum DebugMode
        {
            DEBUG_MODE_OFF = 0x00,
            DEBUG_MODE_RAWDATA_OUT = 0x01,
            DEBUG_MODE_AFE_INFO = 0x04,
            DEBUG_MODE_RAED_PARAMETER = 0x06,
            DEBUG_MODE_DIRECTLY_PARAMETER = 0x08,
            DEBUG_MODE_WRITE_CAL_DATA_CHANNEL = 0x0A,
            DEBUG_MODE_READ_CAL_DATA_CHANNEL = 0x0B,
            DEBUG_MODE_RAWDATA_CRC16 = 0x10,
            DEBUG_MODE_NOISE_CALCULATE = 0x11,
            DEBUG_MODE_RAWDATA_COUNT_CRC16 = 0x21,
            DEBUG_MODE_ADCRAWDATA_COUNT_CRC16 = 0x22,
            DEBUG_MODE_RAWDATA_COUNT_FRAMES_CRC16 = 0x23,
            DEBUG_MODE_ADCRAWDATA_COUNT_FRAMES_CRC16 = 0x24,
        };


        public static unsafe byte[] getbytes(UInt32 address, int iReadLength)
        {
            byte* p = (byte*)address;
            byte[] ret = new byte[iReadLength];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = *(p + i);
            }
            return ret;
        }


        public static bool IICOpenClose()
        {
            uint val_Handle = 0;
            try
            {
                val_Handle = USBIO_OpenDevice(0);
            }
            catch
            {
                MessageBox.Show("请检查USBIOX.DLL和usb2io.dll文件是否在当前目录下!");
                return false;
            }
            if (val_Handle == 4294967295 || val_Handle == 0)
            {
                MessageBox.Show("IIC detected failed!");
                return false;
            }
            //MessageBox.Show("IIC detected Successfully!");
            USBIO_SetStream(0, 0x81);
            return true;
        }

        public static bool IICWriteRead(UInt32 iIndex, UInt32 iWriteLength, UInt32 iWriteBuffer, UInt32 iReadLength,
            UInt32 iReadBuffer)
        {
            bool bResult = USBIO_StreamI2C(iIndex, iWriteLength, iWriteBuffer, iReadLength, iReadBuffer);

            return bResult;
        }

        public static bool StartNDTModule()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODE;
            _IIcWriteBuffer[2] = 0x01;

            return IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static byte QueryDataReady()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READY; //0x61;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 1, MyConvertor.getaddress(_IIcReadBuffer));

            return _IIcReadBuffer[0];
        }

        public static void WriteDataReady(byte value)
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READY; // 0x61;
            _IIcWriteBuffer[2] = value;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static byte[] GetRawdata(byte chnl)
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = chnl;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 2, MyConvertor.getaddress(_IIcReadBuffer));

            return _IIcReadBuffer;
        }

        public static void DebugModeBClean()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODEB;
            _IIcWriteBuffer[2] = (byte)DebugMode.DEBUG_MODE_OFF;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYB;
            _IIcWriteBuffer[2] = (byte)DataReady.DATA_READY_CLEAR;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static void DebugModeCClean()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODEC;
            _IIcWriteBuffer[2] = (byte)DebugMode.DEBUG_MODE_OFF;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYC;
            _IIcWriteBuffer[2] = (byte)DataReady.DATA_READY_CLEAR;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static object[] ModuleInfoCheck()
        {
            object[] oRet = new object[8];

            _IIcWriteBuffer[0] = 0xA0;

            // Manufacturer ID
            _IIcWriteBuffer[1] = (byte)Reg.REG_MANUFACTURER_ID;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 2, MyConvertor.getaddress(_IIcReadBuffer));

            oRet[1] = _IIcReadBuffer[0] | (_IIcReadBuffer[1] << 8);

            // Module ID
            _IIcWriteBuffer[1] = (byte)Reg.REG_MODULE_ID;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 2, MyConvertor.getaddress(_IIcReadBuffer));

            oRet[2] = _IIcReadBuffer[0] | (_IIcReadBuffer[1] << 8);

            // Firmware Version
            _IIcWriteBuffer[1] = (byte)Reg.REG_FW_VERSION;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 2, MyConvertor.getaddress(_IIcReadBuffer));

            oRet[3] = _IIcReadBuffer[0] | (_IIcReadBuffer[1] << 8);

            // Device ID
            _IIcWriteBuffer[1] = (byte)Reg.REG_DEVICE_ID;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 10, MyConvertor.getaddress(_IIcReadBuffer));

            oRet[4] = string.Format("{0:X2}{1:X2}-{2:X2}{3:X2}{4:X2}{5:X2}-{6:X2}{7:X2}{8:X2}{9:X2}",
                _IIcReadBuffer[9], _IIcReadBuffer[8], _IIcReadBuffer[7], _IIcReadBuffer[6], _IIcReadBuffer[3],
                _IIcReadBuffer[4], _IIcReadBuffer[3], _IIcReadBuffer[2], _IIcReadBuffer[1], _IIcReadBuffer[0]);

            DebugModeBClean();

            // 
            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODEB;
            _IIcWriteBuffer[2] = (byte)DebugMode.DEBUG_MODE_AFE_INFO;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYB;

            int iCount = 0;
            do
            {
                MyDelay.Delay(10);
                IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 1, MyConvertor.getaddress(_IIcReadBuffer));
                iCount++;
            } while (_IIcReadBuffer[0] == 0 && iCount < 100);

            if (_IIcReadBuffer[0] != 0)
            {
                uint iAFEInfoBytes = _IIcReadBuffer[0];
                _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_DATAB;

                IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), iAFEInfoBytes,
                    MyConvertor.getaddress(_IIcReadBuffer));

                if (iAFEInfoBytes == 2 + _IIcReadBuffer[1] * 4)
                {
                    oRet[5] = _IIcReadBuffer[0];
                    oRet[6] = _IIcReadBuffer[1];
                    int[] o = new int[Convert.ToInt32(oRet[6])];
                    for (int chnl = 0; chnl < o.Length; chnl++)
                    {
                        o[chnl] = (_IIcReadBuffer[2 + chnl * 4 + 1]);
                        o[chnl] <<= 8;
                        o[chnl] += (_IIcReadBuffer[2 + chnl * 4]);
                        o[chnl] = MyConvertor.bytetoint(o[chnl]);
                    }
                    oRet[7] = o;
                    oRet[0] = "Read module information successfully!";
                }
                else
                {
                    oRet[0] = "AFE information was read incorrectly."; // 读值出错
                }
                if (Convert.ToInt32(oRet[6]) != Form1._rawdata_channelAmount)
                {
                    oRet[6] = 0;
                    oRet[0] = "Channel number is not equal to predefined."; // 通道数错误
                }
            }
            else
            {
                oRet[0] = "Data Ready was read 0."; // DataReady 为0
            }

            DebugModeBClean();

            return oRet;
        }

        public static object[] DebugModeBRawDataCountCRC16Read(int iOutcomeFrames, int iTotalChannelNum)
        {
            object[] oRet = new object[2];
            ushort crc16 = 0;
            short[,] iData = new short[iOutcomeFrames, iTotalChannelNum];
            uint[] iCount = new uint[iOutcomeFrames];

            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYB;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 1, MyConvertor.getaddress(_IIcReadBuffer));
            uint iReadLength = _IIcReadBuffer[0];

            if (iReadLength != 0)
            {
                _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_DATAB;

                IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), iReadLength, MyConvertor.getaddress(_IIcReadBuffer));

                crc16 = _IIcReadBuffer[iReadLength - 1];
                crc16 <<= 8;
                crc16 += _IIcReadBuffer[iReadLength - 2];

                if (crc16 == CRC_Check.calc_crc16(MyConvertor.getaddress(_IIcReadBuffer), iReadLength - 2))
                {
                    for (int i = 0; i < (iReadLength - 2 - 4) / 2; i++)
                    {
                        iData[0, i] = _IIcReadBuffer[i * 2 + 1];
                        iData[0, i] <<= 8;
                        iData[0, i] += _IIcReadBuffer[i * 2];
                    }
                }
                iCount[0] = _IIcReadBuffer[iReadLength - 3];
                iCount[0] <<= 8;
                iCount[0] += _IIcReadBuffer[iReadLength - 4];
                iCount[0] <<= 8;
                iCount[0] += _IIcReadBuffer[iReadLength - 5];
                iCount[0] <<= 8;
                iCount[0] += _IIcReadBuffer[iReadLength - 6];

                _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYB;
                _IIcWriteBuffer[2] = (byte)DataReady.DATA_READY_CLEAR;

                IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
            }
            oRet[0] = iData;
            oRet[1] = iCount;
            return oRet;
        }


        public static object[] DebugModeCRawDataCountFramesCRC16Read(int iOutcomeFrames, int iTotalChannelNum)
        {
            object[] oRet = new object[2];
            ushort crc16 = 0;
            short[,] iData = new short[iOutcomeFrames, iTotalChannelNum];
            uint[] iCount = new uint[iOutcomeFrames];

            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYC;

            IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), 1, MyConvertor.getaddress(_IIcReadBuffer));
            uint iReadLength = _IIcReadBuffer[0];

            if (iReadLength != 0)
            {
                _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_DATAC;

                IICWriteRead(0, 2, MyConvertor.getaddress(_IIcWriteBuffer), iReadLength, MyConvertor.getaddress(_IIcReadBuffer));

                crc16 = _IIcReadBuffer[iReadLength - 1];
                crc16 <<= 8;
                crc16 += _IIcReadBuffer[iReadLength - 2];

                if (crc16 == CRC_Check.calc_crc16(MyConvertor.getaddress(_IIcReadBuffer), iReadLength - 2))
                {
                    for (int j = 0; j < iOutcomeFrames; j++)
                    {
                        for (int i = 0; i < iTotalChannelNum; i++)
                        {
                            iData[j, i] = _IIcReadBuffer[i * 2 + 1 + j * iOutcomeFrames];
                            iData[j, i] <<= 8;
                            iData[j, i] += _IIcReadBuffer[i * 2 + j * iOutcomeFrames];
                        }
                        iCount[j] = _IIcReadBuffer[(j + 1) * iOutcomeFrames - 1];
                        iCount[j] <<= 8;
                        iCount[j] += _IIcReadBuffer[(j + 1) * iOutcomeFrames - 2];
                        iCount[j] <<= 8;
                        iCount[j] += _IIcReadBuffer[(j + 1) * iOutcomeFrames - 3];
                        iCount[j] <<= 8;
                        iCount[j] += _IIcReadBuffer[(j + 1) * iOutcomeFrames - 4];
                    }
                }

                _IIcWriteBuffer[1] = (byte)Reg.REG_DATA_READYC;
                _IIcWriteBuffer[2] = (byte)DataReady.DATA_READY_CLEAR;

                IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
            }

            oRet[0] = iData;
            oRet[1] = iCount;
            return oRet;
        }


        public static void DebugModeBRawDataCRC16Open()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODEB;
            _IIcWriteBuffer[2] = (byte)DebugMode.DEBUG_MODE_RAWDATA_CRC16;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static void DebugModeBRawDataCountCRC16Open()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODEB;
            _IIcWriteBuffer[2] = (byte)DebugMode.DEBUG_MODE_RAWDATA_COUNT_CRC16;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }

        public static void DebugModeCRawDataCountFramesCRC16Open()
        {
            _IIcWriteBuffer[0] = 0xA0;

            _IIcWriteBuffer[1] = (byte)Reg.REG_DEBUG_MODEC;
            _IIcWriteBuffer[2] = (byte)DebugMode.DEBUG_MODE_RAWDATA_COUNT_FRAMES_CRC16;

            IICWriteRead(0, 3, MyConvertor.getaddress(_IIcWriteBuffer), 0, MyConvertor.getaddress(_IIcReadBuffer));
        }
    }
}