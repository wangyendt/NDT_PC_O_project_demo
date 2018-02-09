using System;
using System.Runtime.InteropServices;

namespace Google_Project____Hao_Li
{
    public class IOoperation
    {
        [DllImport("usb2io.DLL")]
        private static extern UInt32 USB2IO_Open(int Nbr);

        [DllImport("usb2io.DLL")]
        private static extern UInt32 USB2IO_Close(UInt32 USB2IO_hdl);

        [DllImport("usb2io.DLL")]
        private static extern UInt32 USB2IO_SetIoCfg(UInt32 USB2IO_hdl, int IoNbr, int IoCfg);

        [DllImport("usb2io.DLL")]
        private static extern UInt32 USB2IO_RdPin(UInt32 USB2IO_hdl, int IoNbr, UInt32 PinValue);
        //        private static extern UInt32 USB2IO_RdPin(UInt32 USB2IO_hdl, int IoNbr, int* PinValue);

        private static UInt32 _mIOHandle = 0;
        private static int _IoNbr =1;

        public static bool IOPortOpen(bool bIOOpen)
        {
            if (bIOOpen)
            {
                USB2IO_Close(_mIOHandle);
                bIOOpen = false;
            }
            else
            {
                _mIOHandle = USB2IO_Open(_IoNbr);
                if (_mIOHandle == 4294967295) // INVALID_HANDLE_VALUE
                {
                    bIOOpen = false;
                }
                else
                {
                    bIOOpen = true;
                }
            }

            return bIOOpen;
        }

        public static void IOPortSet()
        {
            USB2IO_SetIoCfg(_mIOHandle, 3, 3);  // IO3
        }

        public static int IOPortReadData()
        {
            byte[] buffer = new byte[32];
            //USB2IO_RdPin(_mIOHandle, _IoNbr, MyConvertor.getaddress(buffer));
            USB2IO_RdPin(_mIOHandle, 3, MyConvertor.getaddress(buffer));

            //int iRet = MyConvertoAAAr.bytetoint(buffer[1] << 8 | buffer[0]);
            int iRet = MyConvertor.bytetoint( buffer[0]);

            return iRet;
        }
    }
}