using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Google_Project____Hao_Li.Properties;
using ZedGraph;

namespace Google_Project____Hao_Li
{
    internal delegate void del_ShowDataView(List<int> iData);
    internal delegate void del_DrawDataView(List<int> iData);

    public partial class Form1 : Form
    {
        private Thread _thrdReadData;
        private Thread _thrdReadTouchFlag;
        private Thread _thrdShowData;
        private Thread _thrdDrawData;


        private List<List<int>> _rawdata_drawList = new List<List<int>>();
        private List<List<int>> _rawdata_obsList = new List<List<int>>();
        private StringBuilder _rawdata_realtime_sb = new StringBuilder();
        private StringBuilder _rawdata_Save_sb = new StringBuilder();
        private StringBuilder _rawdata_Info_Save_sb = new StringBuilder();
        private GraphPane _rawdata_gpRawdata;
        private List<int> _rawdata_touchflaglist = new List<int>();
        private List<int> _rawdata_touchflagFiltedlist = new List<int>();

        private string _exestrFileName;
        private int _rawdata_tickStart = 0;
        private int _rawdata_Line = 0; // Data View中的行号
        private bool _rawdata_bFirstCycle = true;
        private int _rawdata_periodID = 1;

        private int _rawdata_samplingTime = 10;
        public static int _rawdata_channelAmount = 3;
        private string _rawdata_commType = "Collecting Data"; // IIC和Serial Port
        private int _rawdata_obsInterval = 2000;
        private int _rawdata_touchflagFilterLen = 3;
        private int _rawdata_part0frame = 100;
        private int _rawdata_part1frame = 200;
        private int _rawdata_part2frame = 300;
        private string _rawdata_strSettings = "setting.ini";
        private string _rawdata_strInfoSavePath = "Info.txt";
        private string _rawdata_strRawdataSavePath = "RawData.txt";
        private int _rawdata_AutoStartTime = 1000;
        private int _rawdata_AutoCloseTime = 10;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _exestrFileName = Path.GetFileNameWithoutExtension(Application.ExecutablePath).Replace(" ", "");
            LoadParams();
            CheckForIllegalCrossThreadCalls = false;
            zgcRawdataInitialize();
            tmr_AutoStart.Enabled = true;
            tmr_AutoStart.Interval = _rawdata_AutoStartTime;
            ShowLog("Application will start in " + _rawdata_AutoStartTime + "ms...");
            tmr_AutoStart.Start();
            pbarNoiseProc.Maximum = _rawdata_part0frame;
            pbarSignalProc.Maximum = _rawdata_part1frame;
            pbarDriftProc.Maximum = _rawdata_part2frame;
            pbarAutoCloseProc.Maximum = _rawdata_AutoCloseTime;
        }

        private void LoadParams()
        {
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + _exestrFileName + @"Config.xml"))
            {
                WriteParams();
                ShowLog("Load default settings.");
            }
            else
            {
                ReadParams();
                ShowLog("Load settings successfully.");
            }
            tb_ITOP_SamplingTime.Text = _rawdata_samplingTime.ToString();
            tb_ITOP_ChnlNum.Text = _rawdata_channelAmount.ToString();
            cbo_ITOP_CommType.Text = _rawdata_commType;
            tb_ITOP_ObservationInterval.Text = _rawdata_obsInterval.ToString();
            tb_ITOP_Settings.Text = _rawdata_strSettings;
            tb_ITOP_InfoSavePath.Text = _rawdata_strInfoSavePath;
            tb_ITOP_RawdataSavePath.Text = _rawdata_strRawdataSavePath;
        }

        private void SaveParams()
        {
            _rawdata_samplingTime = int.Parse(tb_ITOP_SamplingTime.Text);
            _rawdata_channelAmount = int.Parse(tb_ITOP_ChnlNum.Text);
            _rawdata_commType = cbo_ITOP_CommType.Text;
            _rawdata_obsInterval = int.Parse(tb_ITOP_ObservationInterval.Text);
            _rawdata_strSettings = tb_ITOP_Settings.Text;
            _rawdata_strInfoSavePath = tb_ITOP_InfoSavePath.Text;
            _rawdata_strRawdataSavePath = tb_ITOP_RawdataSavePath.Text;
            WriteParams();
        }

        private void WriteParams()
        {
            XmlConfigRW xmlcrw =
                new XmlConfigRW(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + _exestrFileName + "Config.xml",
                    _exestrFileName + "Config");
            xmlcrw.Write(_rawdata_samplingTime.ToString(), "SamplingTime");
            xmlcrw.Write(_rawdata_channelAmount.ToString(), "ChannelAmount");
            xmlcrw.Write(_rawdata_commType, "CommunicationType");
            xmlcrw.Write(_rawdata_obsInterval.ToString(), "ObservationInterval");
            xmlcrw.Write(_rawdata_touchflagFilterLen.ToString(), "TouchFlagFilterLength");
            xmlcrw.Write(_rawdata_part0frame.ToString(), "NoisePeriod");
            xmlcrw.Write(_rawdata_part1frame.ToString(), "SignalPeriod");
            xmlcrw.Write(_rawdata_part2frame.ToString(), "DriftPeriod");
            xmlcrw.Write(_rawdata_strSettings, "SettingsPath");
            xmlcrw.Write(_rawdata_strInfoSavePath, "InfoSavePath");
            xmlcrw.Write(_rawdata_strRawdataSavePath, "RawdataSavePath");
            xmlcrw.Write(_rawdata_AutoStartTime.ToString(), "AutoStartTime");
            xmlcrw.Write(_rawdata_AutoCloseTime.ToString(), "AutoCloseTime");
        }

        private void ReadParams()
        {
            try
            {
                XmlConfigRW xmlcrw =
                    new XmlConfigRW(
                        Path.GetDirectoryName(Application.ExecutablePath) + @"\" + _exestrFileName + "Config.xml",
                        _exestrFileName + "Config");
                _rawdata_samplingTime = int.Parse(xmlcrw.Read("SamplingTime"));
                _rawdata_channelAmount = int.Parse(xmlcrw.Read("ChannelAmount"));
                _rawdata_commType = xmlcrw.Read("CommunicationType");
                _rawdata_obsInterval = int.Parse(xmlcrw.Read("ObservationInterval"));
                _rawdata_touchflagFilterLen = int.Parse(xmlcrw.Read("TouchFlagFilterLength"));
                _rawdata_part0frame = int.Parse(xmlcrw.Read("NoisePeriod"));
                _rawdata_part1frame = int.Parse(xmlcrw.Read("SignalPeriod"));
                _rawdata_part2frame = int.Parse(xmlcrw.Read("DriftPeriod"));
                _rawdata_strSettings = xmlcrw.Read("SettingsPath");
                _rawdata_strInfoSavePath = xmlcrw.Read("InfoSavePath");
                _rawdata_strRawdataSavePath = xmlcrw.Read("RawdataSavePath");
                _rawdata_AutoStartTime = int.Parse(xmlcrw.Read("AutoStartTime"));
                _rawdata_AutoCloseTime = int.Parse(xmlcrw.Read("AutoCloseTime"));
            }
            catch
            {
                WriteParams();
            }
        }

        private void zgcRawdataInitialize()
        {
            _rawdata_gpRawdata = zgcRawdata.GraphPane;
            _rawdata_gpRawdata.Title.Text = @"Real time Curve:";
            _rawdata_gpRawdata.XAxis.Title.Text = @"时间(单位: 毫秒)";
            _rawdata_gpRawdata.YAxis.Title.Text = @"ADC";
            _rawdata_gpRawdata.XAxis.Scale.MinAuto = true;
            _rawdata_gpRawdata.XAxis.Scale.MaxAuto = true;
            _rawdata_gpRawdata.YAxis.Scale.MinAuto = true;
            _rawdata_gpRawdata.YAxis.Scale.MaxAuto = true;
            _rawdata_gpRawdata.XAxis.Scale.MinorStepAuto = true;
            _rawdata_gpRawdata.XAxis.Scale.MajorStepAuto = true;
            _rawdata_gpRawdata.YAxis.Scale.MinorStepAuto = true;
            _rawdata_gpRawdata.YAxis.Scale.MajorStepAuto = true;
            _rawdata_gpRawdata.XAxis.MajorGrid.IsVisible = true;
            _rawdata_gpRawdata.XAxis.MajorGrid.DashOn = 0;
            _rawdata_gpRawdata.XAxis.MajorGrid.Color = Color.Gray;
            _rawdata_gpRawdata.YAxis.MajorGrid.IsVisible = true;
            _rawdata_gpRawdata.YAxis.MajorGrid.DashOn = 0;
            _rawdata_gpRawdata.YAxis.MajorGrid.Color = Color.Gray;
            _rawdata_gpRawdata.Chart.Fill = new Fill(Color.Black);
            zgcRawdata.AxisChange();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Enabled == false)
            {
                return;
            }
            btnStart.Enabled = false;


            #region 读取界面参数
            try
            {
                _rawdata_samplingTime = int.Parse(tb_ITOP_SamplingTime.Text);
                _rawdata_channelAmount = int.Parse(tb_ITOP_ChnlNum.Text);
                _rawdata_commType = cbo_ITOP_CommType.Text;
                _rawdata_obsInterval = int.Parse(tb_ITOP_ObservationInterval.Text);
            }
            catch
            {
                ShowLog("Parameters input wrong!");
                ForceFormClose(_rawdata_AutoCloseTime);
                return;
            }
            ShowLog("Parameters input correctly!");
            #endregion

            #region GUI配置
            RollingPointPairList[] listRawdata = new RollingPointPairList[_rawdata_channelAmount];
            for (int chnl = 0; chnl < _rawdata_channelAmount; chnl++)
            {
                _rawdata_gpRawdata.AddCurve("Sensor" + (chnl + 1), listRawdata[chnl], Color.Red, SymbolType.None);
            }
            ShowLog("GUI configured successfully.");
            #endregion

            tmr_DataScanning.Stop();
            tmr_DataScanning.Enabled = false;
            tmr_DataScanning.Enabled = true;
            tmr_DataScanning.Interval = _rawdata_obsInterval;
            tmr_DataScanning.Start();
            ShowLog("Timer configured successfully.");

            try
            {
                bool bOpenIO = IOoperation.IOPortOpen(false);
                if (bOpenIO)
                {
                    ShowLog("IO started successfully.");
                    try
                    {
                        IOoperation.IOPortSet();
                        ShowLog("IO set successfully.");
                    }
                    catch
                    {
                        ShowLog("IO set failed!");
                        ForceFormClose(_rawdata_AutoCloseTime);
                        return;
                    }
                }
                else
                {
                    ShowLog("IO started failed.");
                    ForceFormClose(_rawdata_AutoCloseTime);
                    return;
                }
            }
            catch
            {
                ShowLog("IO started failed.");
                ForceFormClose(_rawdata_AutoCloseTime);
                return;
            }

            _rawdata_Save_sb.Clear();
            _rawdata_Info_Save_sb.Clear();

            switch (_rawdata_commType)
            {
                #region 实时曲线
                case "IIC Communication":
                    ShowLog("Read rawdata using IIC.");
                    if (IICoperation.IICOpenClose())
                    {
                        _rawdata_tickStart = Environment.TickCount;
                        object[] oModuleInfo = IICoperation.ModuleInfoCheck();
                        if ((string)(oModuleInfo[0]) == "Read module information successfully!")
                        {
                            _rawdata_Info_Save_sb.Append("Manufacturer ID: " + oModuleInfo[1] + "\r\n" +
                                                 "Module ID: " + oModuleInfo[2] + "\r\n" +
                                                 "Firmware Version: " + oModuleInfo[3] + "\r\n" +
                                                 "UID: " + oModuleInfo[4] + "\r\n" +
                                                 "Gain: " + oModuleInfo[5] + "\r\n" +
                                                 "Channel Number: " + oModuleInfo[6] + "\r\n");

                            ShowLog("Module Information checked successfully.");
                            ShowLog("Manufacturer ID: " + oModuleInfo[1]);
                            ShowLog("Module ID: " + oModuleInfo[2]);
                            ShowLog("Firmware Version: " + oModuleInfo[3]);
                            ShowLog("UID: " + oModuleInfo[4]);
                            ShowLog("Gain: " + oModuleInfo[5]);
                            ShowLog("Channel Number: " + oModuleInfo[6]);
                        }
                        else
                        {
                            ShowLog((string)(oModuleInfo[0]));
                            ShowLog("Read module information failed!");
                            return;
                        }
                    }
                    else
                    {
                        ShowLog("Couldn't connect via IIC, please check.");
                        return;
                    }

                    bool bNDTBtnStart = IICoperation.StartNDTModule();

                    if (bNDTBtnStart)
                    {
                        ShowLog("Start IIC successfully, start to get rawdata...");
                        _thrdReadData = new Thread(ReadData) { IsBackground = true };
                        _thrdReadData?.Start();
                    }
                    break;
                #endregion

                #region 模块化 type
                case "Collecting Data":

                    #region IIC get rawdata
                    ShowLog("Testing using count.");
                    if (IICoperation.IICOpenClose())
                    {
                        _rawdata_tickStart = Environment.TickCount;
                        object[] oModuleInfo = IICoperation.ModuleInfoCheck();
                        int[] offset = oModuleInfo[7] as int[];

                        if ((string)(oModuleInfo[0]) == "Read module information successfully!")
                        {
                            _rawdata_Info_Save_sb.Append("Manufacturer ID: " + oModuleInfo[1] + "\r\n" +
                                                 "Module ID: " + oModuleInfo[2] + "\r\n" +
                                                 "Firmware Version: " + oModuleInfo[3] + "\r\n" +
                                                 "UID: " + oModuleInfo[4] + "\r\n" +
                                                 "Gain: " + oModuleInfo[5] + "\r\n" +
                                                 "Channel Number: " + oModuleInfo[6] + "\r\n");
                            for (int chnl = 0; chnl < offset.Length; chnl++)
                            {
                                _rawdata_Info_Save_sb.Append("Sensor " + (chnl + 1) + "# offset: " + offset[chnl] + "\r\n");
                            }

                            ShowLog("Module Information checked successfully.");
                            ShowLog("Manufacturer ID: " + oModuleInfo[1]);
                            ShowLog("Module ID: " + oModuleInfo[2]);
                            ShowLog("Firmware Version: " + oModuleInfo[3]);
                            ShowLog("UID: " + oModuleInfo[4]);
                            ShowLog("Gain: " + oModuleInfo[5]);
                            ShowLog("Channel Number: " + oModuleInfo[6]);
                        }
                        else
                        {
                            ShowLog((string)(oModuleInfo[0]));
                            ShowLog("Read module information failed!");
                            ForceFormClose(_rawdata_AutoCloseTime);
                            return;
                        }
                    }
                    else
                    {
                        ShowLog("Couldn't connect via IIC, please check.");
                        ForceFormClose(_rawdata_AutoCloseTime);
                        return;
                    }

                    //IICoperation.DebugModeBClean();
                    //IICoperation.DebugModeBRawDataCountCRC16Open();
                    IICoperation.DebugModeCClean();
                    IICoperation.DebugModeCRawDataCountFramesCRC16Open();

                    {
                        ShowLog("Start IIC successfully, start to get rawdata...");
                        _thrdReadData = new Thread(ReadDataAndCount) { IsBackground = true };
                        _thrdReadData?.Start();
                    }
                    #endregion

                    #region IO get touch flag
                    _thrdReadTouchFlag = new Thread(ReadTouchFlag) { IsBackground = true };
                    _thrdReadTouchFlag?.Start();
                    #endregion

                    break;
                    #endregion
            }
        }

        private void ForceFormClose(int time)
        {
            int maxTime = time;
            while (time-- > 0)
            {
                ShowLog("Error occured, application will close in " + time + "s...");
                BeginInvoke((EventHandler)delegate { pbarAutoCloseProc.Value = maxTime - time; });
                MyDelay.Delay(1000);
            }
            pb_AutoClose.BackgroundImage = Resources.pass;
            MyDelay.Delay(1000);
            Close();
            Dispose();
        }

        private void AddInfoToSaveSB(List<int> iData)
        {
            string strEncry = _rawdata_Line.ToString();
            _rawdata_Save_sb.Append(_rawdata_Line.ToString("00000000") + "  ");
            //_rawdata_Save_sb.Append(string.Format("Line {0,-7}{1:00}:{2:00}:{3:00}.{4:000}", _rawdata_Line, DateTime.Now.Hour,
            _rawdata_Save_sb.Append(DateTime.Now.Ticks);

            for (int ind = 0; ind < iData.Count; ind++)
            {
                _rawdata_Save_sb.Append(string.Format("{0,8}", iData[ind]));
                strEncry += " " + iData[ind];
            }

            _rawdata_Save_sb.Append(string.Format("{0,4}", _rawdata_touchflaglist[_rawdata_touchflaglist.Count - 1]));
            _rawdata_Save_sb.Append(string.Format("{0,4}", _rawdata_touchflagFiltedlist[_rawdata_touchflagFiltedlist.Count - 1]));
            _rawdata_Save_sb.Append(string.Format("{0,4}", _rawdata_periodID));

            //_rawdata_Save_sb.Append(AES_Encrypt.AESEncrypt(strEncry) + "\r\n");
            _rawdata_Save_sb.Append("\r\n");
        }

        private void ReadData()
        {
            while (true)
            {
                // 采样率
                MyDelay.Delay(_rawdata_samplingTime);

                byte iDataReady = IICoperation.QueryDataReady();
                if (iDataReady != 0)
                {
                    #region 采集数据
                    List<int> iData = new List<int>();
                    int value;
                    for (int chnl = 0; chnl < _rawdata_channelAmount; chnl++)
                    {
                        byte[] readbuffer = IICoperation.GetRawdata((byte)(0x62 + chnl));
                        value = -1 * (MyConvertor.bytetoint((readbuffer[1] << 8) | readbuffer[0]));
                        iData.Add(value);
                    }
                    IICoperation.WriteDataReady(0);
                    _rawdata_Line++;
                    _rawdata_obsList.Add(iData);
                    AddInfoToSaveSB(iData);
                    #endregion

                    //Invoke(new del_ShowDataView(ShowDataStream), iData);
                    //Invoke(new del_DrawDataView(DrawDataLine), iData);
                }
            }
        }

        private void ReadDataAndCount()
        {
            bool bCycle = true;
            while (bCycle)
            {
                MyDelay.Delay(_rawdata_samplingTime);

                #region IIC采集数据
                object[] oGet = IICoperation.DebugModeCRawDataCountFramesCRC16Read(10, _rawdata_channelAmount);
                //object[] oGet = IICoperation.DebugModeBRawDataCountCRC16Read(10, _rawdata_channelAmount);

                short[,] isData = oGet[0] as short[,];
                uint[] iCount = oGet[1] as uint[];
                List<int> iData = new List<int>();

                if (oGet[0] == null || oGet[1] == null)
                {
                    ShowLog("Counld't get proper data.");
                    return;
                }

                for (int i = 0; i < isData.GetLength(0); i++)
                {
                    // TODO: 此处需要修改
                    if (iCount[i] == 0)
                    {
                        continue;
                    }
                    iData.Clear();
                    for (int j = 0; j < isData.GetLength(1); j++)
                    {
                        iData.Add(isData[i, j]);
                    }

                    iData.Add((int)iCount[i]);
                    _rawdata_Line++;

                    if (bCycle)
                    {
                        _rawdata_obsList.Add(iData);
                        AddInfoToSaveSB(iData);
                    }

                    if (_rawdata_periodID == 1 &&
                        _rawdata_Line <= _rawdata_part0frame)
                    {
                        pbarNoiseProc.Value = _rawdata_Line;
                    }

                    if (_rawdata_periodID == 2 &&
                        _rawdata_Line <= _rawdata_part0frame + _rawdata_part1frame)
                    {
                        pbarSignalProc.Value = _rawdata_Line - _rawdata_part0frame;
                    }

                    if (_rawdata_periodID == 3 &&
                        _rawdata_Line <= _rawdata_part0frame + _rawdata_part1frame + _rawdata_part2frame)
                    {
                        pbarDriftProc.Value = _rawdata_Line - _rawdata_part0frame - _rawdata_part1frame;
                    }

                    if (_rawdata_periodID == 1
                        && _rawdata_Line >= _rawdata_part0frame)
                    {
                        _rawdata_periodID = 2;
                        pb_Noise.BackgroundImage = Resources.pass;
                        btnView_Click(null, null);
                    }
                    if (_rawdata_periodID == 2
                        && _rawdata_Line >= _rawdata_part0frame + _rawdata_part1frame)
                    {
                        _rawdata_periodID = 3;
                        pb_Signal.BackgroundImage = Resources.pass;
                        btnView_Click(null, null);
                    }
                    if (_rawdata_Line >= _rawdata_part0frame + _rawdata_part1frame + _rawdata_part2frame)
                    {
                        pb_Drift.BackgroundImage = Resources.pass;
                        btnView_Click(null, null);
                        bCycle = false;
                    }
                }
                #endregion
            }
            ForceFormClose(_rawdata_AutoCloseTime);
        }

        private void ReadTouchFlag()
        {
            while (true)
            {
                MyDelay.Delay(_rawdata_samplingTime);

                int iData = IOoperation.IOPortReadData();

                if (_rawdata_touchflaglist.Count > _rawdata_touchflagFilterLen)
                {
                    _rawdata_touchflaglist.RemoveAt(0);
                }
                _rawdata_touchflaglist.Add(iData);

                // 滤波, 去除单帧跳变
                if (_rawdata_touchflagFiltedlist.Count > _rawdata_touchflagFilterLen)
                {
                    _rawdata_touchflagFiltedlist.RemoveAt(0);
                    if (_rawdata_touchflaglist.Where((list, index) => (index > 0)).Sum() % _rawdata_touchflagFilterLen == 0
                        && _rawdata_touchflagFiltedlist[0] != iData)
                    {
                        _rawdata_touchflagFiltedlist.Add(iData);
                    }
                    else
                    {
                        _rawdata_touchflagFiltedlist.Add(_rawdata_touchflagFiltedlist[_rawdata_touchflagFiltedlist.Count - 1]);
                    }
                }
                else
                {
                    _rawdata_touchflagFiltedlist.Add(iData);
                }
            }
        }

        private void ShowDataStream(List<int> iData)
        {
            _rawdata_realtime_sb.Append("Line: " + _rawdata_Line + "\t");
            for (int chnl = 0; chnl < iData.Count; chnl++)
            {
                _rawdata_realtime_sb.Append(iData[chnl] + "\t");
            }

            _rawdata_realtime_sb.Append("\n");
        }

        private void DrawDataLine(List<int> iData)
        {
            if (_rawdata_gpRawdata.CurveList.Count <= 0)
            {
                return;
            }

            Invoke((EventHandler)delegate
            {
                LineItem[] curveRawdata = new LineItem[_rawdata_gpRawdata.CurveList.Count];
                for (int item = 0; item < curveRawdata.Length; item++)
                {
                    curveRawdata[item] = _rawdata_gpRawdata.CurveList[item] as LineItem;
                    if (curveRawdata[item] == null)
                    {
                        return;
                    }
                }

                IPointListEdit[] ipleRawdata = new IPointListEdit[curveRawdata.Length];

                for (int item = 0; item < ipleRawdata.Length; item++)
                {
                    ipleRawdata[item] = curveRawdata[item].Points as IPointListEdit;
                    if (ipleRawdata[item] == null)
                    {
                        return;
                    }
                }

                double time = (Environment.TickCount - _rawdata_tickStart) / 1;
                try
                {
                    for (int item = 0; item < ipleRawdata.Length; item++)
                    {
                        ipleRawdata[item].Add(time, iData[item]);
                    }
                    Scale xScaleRawdata = _rawdata_gpRawdata.XAxis.Scale;
                    if (time > xScaleRawdata.Max - xScaleRawdata.MajorStep)
                    {
                        xScaleRawdata.Max = time + xScaleRawdata.MajorStep;
                        xScaleRawdata.Min = xScaleRawdata.Max - 5000;
                    }
                    _rawdata_gpRawdata.AxisChange();
                    zgcRawdata.Invalidate();
                }
                catch
                {
                }
            });
        }

        private void tmr_DataScanning_Tick(object sender, EventArgs e)
        {
            if (_rawdata_obsList == null || _rawdata_obsList.Count <= 1)
            {
                return;
            }

            // 采样时间/采样频率
            lbl_ITOP_RealScanningRate.Text = _rawdata_obsList.Count * 1000 / _rawdata_obsInterval + " Hz";

            // 方差计算
            if (_rawdata_obsList.Count <= 1)
            {
                lbl_ITOP_Noise.Text = 0.ToString();
            }
            else
            {
                double[] avg = new double[_rawdata_channelAmount];
                double[] vars = new double[_rawdata_channelAmount];
                for (int chnl = 0; chnl < _rawdata_channelAmount; chnl++)
                {
                    for (int ind = 0; ind < _rawdata_obsList.Count; ind++)
                    {
                        avg[chnl] += _rawdata_obsList[ind][chnl];
                        vars[chnl] += _rawdata_obsList[ind][chnl] * _rawdata_obsList[ind][chnl];
                    }
                    avg[chnl] /= _rawdata_obsList.Count;
                    vars[chnl] -= _rawdata_obsList.Count * avg[chnl] * avg[chnl];
                    vars[chnl] /= (_rawdata_obsList.Count - 1);
                }
                lbl_ITOP_Noise.Text = Math.Sqrt(vars.Max()).ToString("0.00") + " ADC";
            }

            // 漂移估算
            int[] drift = new int[_rawdata_channelAmount];
            int[] drift_min = new int[_rawdata_channelAmount];
            int[] drift_max = new int[_rawdata_channelAmount];
            for (int chnl = 0; chnl < _rawdata_channelAmount; chnl++)
            {
                drift_min[chnl] = _rawdata_obsList[0][chnl];
                drift_max[chnl] = _rawdata_obsList[0][chnl];
                for (int ind = 0; ind < _rawdata_obsList.Count; ind++)
                {
                    drift_min[chnl] = Math.Min(drift_min[chnl], _rawdata_obsList[ind][chnl]);
                    drift_max[chnl] = Math.Max(drift_max[chnl], _rawdata_obsList[ind][chnl]);
                }
                drift[chnl] = drift_max[chnl] - drift_min[chnl];
            }
            lbl_ITOP_Drift.Text = drift.Max() + " ADC";

            // 数据清空
            _rawdata_obsList.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            rtbData.Text = _rawdata_Save_sb.ToString();
            rtbData.Focus();//获取焦点
            rtbData.Select(rtbData.TextLength, 0);//光标定位到文本最后
            rtbData.ScrollToCaret();//滚动到光标处
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strDataFilePrefix = @"helloworld";
            string strDataFilePath = ReadPathNameFromINI();
            SavePathNameToINI(strDataFilePrefix);
            string strModuleInfoSavePath = strDataFilePath + strDataFilePrefix + _rawdata_strInfoSavePath;
            string strRawdataSavePath = strDataFilePath + strDataFilePrefix + _rawdata_strRawdataSavePath;

            if (File.Exists(strModuleInfoSavePath))
            {
                File.Delete(strModuleInfoSavePath);
            }
            if (File.Exists(strRawdataSavePath))
            {
                File.Delete(strRawdataSavePath);
            }

            byte[] bufferInfo = Encoding.UTF8.GetBytes(_rawdata_Info_Save_sb.ToString());
            using (FileStream fs = new FileStream(strModuleInfoSavePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(bufferInfo, 0, bufferInfo.Length);
                fs.Close();
                fs.Dispose();
                ShowLog("Module info was successfully saved at: " + strModuleInfoSavePath);
            }

            byte[] bufferRawdata = Encoding.UTF8.GetBytes(_rawdata_Save_sb.ToString());
            using (FileStream fs = new FileStream(strRawdataSavePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(bufferRawdata, 0, bufferRawdata.Length);
                fs.Close();
                fs.Dispose();
                ShowLog("Rawdata was successfully saved at: " + strRawdataSavePath);
            }
        }

        private string ReadPathNameFromINI()
        {
            string strIniFileName = Path.GetFullPath(_rawdata_strSettings);
            if (!File.Exists(_rawdata_strSettings))
            {
                ShowLog("Setting file does not exist!");
                return "";
            }

            IniReadWrite inirw = new IniReadWrite(strIniFileName);

            string strDataFilePath = inirw.ReadValue("General", "DataFilePath");
            try
            {
                strDataFilePath = strDataFilePath.Remove(strDataFilePath.IndexOf("//")).Trim();
            }
            catch
            {
                strDataFilePath = strDataFilePath.Trim();
            }

            return strDataFilePath;
        }

        private void SavePathNameToINI(string strDataFilePrefix)
        {
            string strIniFileName = Path.GetFullPath(_rawdata_strSettings);

            IniReadWrite inirw = new IniReadWrite(strIniFileName);

            inirw.WriteValue("General", "DataFilePrefix", strDataFilePrefix);
        }

        private void ShowLog(string strLog)
        {
            rtbLog.AppendText(">>> " + strLog + "\r\n");
            rtbLog.Focus();//获取焦点
            rtbLog.Select(rtbLog.TextLength, 0);//光标定位到文本最后
            rtbLog.ScrollToCaret();//滚动到光标处
        }

        private void cbo_ITOP_CommType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbo_ITOP_CommType.Text)
            {
                case "IIC Communication":
                    lbl_ITOP_SamplingTime.Text = "Cycling Delay: ";
                    break;
                case "Serial Port":
                    lbl_ITOP_SamplingTime.Text = "Cycling Delay: ";
                    break;
                case "Manually Import":
                    lbl_ITOP_SamplingTime.Text = "Sampling Time: ";
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _rawdata_Save_sb.Clear();
            _rawdata_realtime_sb.Clear();
            rtbData.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveParams();
                btnSave_Click(null, null);
            }
            catch
            {

            }
        }

        private void tmr_AutoStart_Tick(object sender, EventArgs e)
        {
            btnStart_Click(null, null); // 模拟按下start按钮
            tmr_AutoStart.Stop();
            tmr_AutoStart.Enabled = false;
        }
    }
}
