using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraphControl = ZedGraph.ZedGraphControl;

namespace Google_Project____Hao_Li
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_ITOP_InfoSavePath = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tb_ITOP_RawdataSavePath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_ITOP_Drift = new System.Windows.Forms.Label();
            this.lbl_ITOP_Noise = new System.Windows.Forms.Label();
            this.lbl_ITOP_RealScanningRate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_ITOP_Settings = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ITOP_ObservationInterval = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_ITOP_CommType = new System.Windows.Forms.ComboBox();
            this.tb_ITOP_ChnlNum = new System.Windows.Forms.TextBox();
            this.tb_ITOP_SamplingTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_ITOP_SamplingTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbData = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zgcRawdata = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tmr_DataScanning = new System.Windows.Forms.Timer(this.components);
            this.tmr_AutoStart = new System.Windows.Forms.Timer(this.components);
            this.pbarNoiseProc = new System.Windows.Forms.ProgressBar();
            this.label16 = new System.Windows.Forms.Label();
            this.pbarDriftProc = new System.Windows.Forms.ProgressBar();
            this.label17 = new System.Windows.Forms.Label();
            this.pbarSignalProc = new System.Windows.Forms.ProgressBar();
            this.label18 = new System.Windows.Forms.Label();
            this.pbarAutoCloseProc = new System.Windows.Forms.ProgressBar();
            this.label19 = new System.Windows.Forms.Label();
            this.pb_Noise = new System.Windows.Forms.PictureBox();
            this.pb_Signal = new System.Windows.Forms.PictureBox();
            this.pb_Drift = new System.Windows.Forms.PictureBox();
            this.pb_AutoClose = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Noise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Signal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Drift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AutoClose)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 610);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1256, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 82);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1250, 499);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.tb_ITOP_InfoSavePath);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Controls.Add(this.tb_ITOP_RawdataSavePath);
            this.groupBox5.Controls.Add(this.panel2);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.btnView);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(542, 499);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ITOP";
            // 
            // tb_ITOP_InfoSavePath
            // 
            this.tb_ITOP_InfoSavePath.Location = new System.Drawing.Point(88, 392);
            this.tb_ITOP_InfoSavePath.Name = "tb_ITOP_InfoSavePath";
            this.tb_ITOP_InfoSavePath.Size = new System.Drawing.Size(122, 21);
            this.tb_ITOP_InfoSavePath.TabIndex = 8;
            this.tb_ITOP_InfoSavePath.Text = "Info.txt";
            this.tb_ITOP_InfoSavePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(265, 452);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 31);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tb_ITOP_RawdataSavePath
            // 
            this.tb_ITOP_RawdataSavePath.Location = new System.Drawing.Point(254, 392);
            this.tb_ITOP_RawdataSavePath.Name = "tb_ITOP_RawdataSavePath";
            this.tb_ITOP_RawdataSavePath.Size = new System.Drawing.Size(122, 21);
            this.tb_ITOP_RawdataSavePath.TabIndex = 6;
            this.tb_ITOP_RawdataSavePath.Text = "Rawdata.txt";
            this.tb_ITOP_RawdataSavePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.lbl_ITOP_Drift);
            this.panel2.Controls.Add(this.lbl_ITOP_Noise);
            this.panel2.Controls.Add(this.lbl_ITOP_RealScanningRate);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(88, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 100);
            this.panel2.TabIndex = 5;
            // 
            // lbl_ITOP_Drift
            // 
            this.lbl_ITOP_Drift.AutoSize = true;
            this.lbl_ITOP_Drift.Location = new System.Drawing.Point(185, 70);
            this.lbl_ITOP_Drift.Name = "lbl_ITOP_Drift";
            this.lbl_ITOP_Drift.Size = new System.Drawing.Size(35, 12);
            this.lbl_ITOP_Drift.TabIndex = 13;
            this.lbl_ITOP_Drift.Text = "0 ADC";
            this.lbl_ITOP_Drift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ITOP_Noise
            // 
            this.lbl_ITOP_Noise.AutoSize = true;
            this.lbl_ITOP_Noise.Location = new System.Drawing.Point(185, 44);
            this.lbl_ITOP_Noise.Name = "lbl_ITOP_Noise";
            this.lbl_ITOP_Noise.Size = new System.Drawing.Size(35, 12);
            this.lbl_ITOP_Noise.TabIndex = 12;
            this.lbl_ITOP_Noise.Text = "0 ADC";
            this.lbl_ITOP_Noise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ITOP_RealScanningRate
            // 
            this.lbl_ITOP_RealScanningRate.AutoSize = true;
            this.lbl_ITOP_RealScanningRate.Location = new System.Drawing.Point(185, 16);
            this.lbl_ITOP_RealScanningRate.Name = "lbl_ITOP_RealScanningRate";
            this.lbl_ITOP_RealScanningRate.Size = new System.Drawing.Size(29, 12);
            this.lbl_ITOP_RealScanningRate.TabIndex = 11;
            this.lbl_ITOP_RealScanningRate.Text = "0 Hz";
            this.lbl_ITOP_RealScanningRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "Drift:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "Noise(Standard Deviation):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Real Scanning Rate:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.tb_ITOP_Settings);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tb_ITOP_ObservationInterval);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbo_ITOP_CommType);
            this.panel1.Controls.Add(this.tb_ITOP_ChnlNum);
            this.panel1.Controls.Add(this.tb_ITOP_SamplingTime);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbl_ITOP_SamplingTime);
            this.panel1.Location = new System.Drawing.Point(88, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 168);
            this.panel1.TabIndex = 4;
            // 
            // tb_ITOP_Settings
            // 
            this.tb_ITOP_Settings.Location = new System.Drawing.Point(147, 134);
            this.tb_ITOP_Settings.Name = "tb_ITOP_Settings";
            this.tb_ITOP_Settings.Size = new System.Drawing.Size(85, 21);
            this.tb_ITOP_Settings.TabIndex = 13;
            this.tb_ITOP_Settings.Text = "settings.ini";
            this.tb_ITOP_Settings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "Settings File Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(215, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "ms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "ms";
            // 
            // tb_ITOP_ObservationInterval
            // 
            this.tb_ITOP_ObservationInterval.Location = new System.Drawing.Point(166, 103);
            this.tb_ITOP_ObservationInterval.Name = "tb_ITOP_ObservationInterval";
            this.tb_ITOP_ObservationInterval.Size = new System.Drawing.Size(43, 21);
            this.tb_ITOP_ObservationInterval.TabIndex = 7;
            this.tb_ITOP_ObservationInterval.Text = "2000";
            this.tb_ITOP_ObservationInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "Observation Interval:";
            // 
            // cbo_ITOP_CommType
            // 
            this.cbo_ITOP_CommType.Enabled = false;
            this.cbo_ITOP_CommType.FormattingEnabled = true;
            this.cbo_ITOP_CommType.Items.AddRange(new object[] {
            "IIC Communication",
            "Serial Port",
            "Collecting Data"});
            this.cbo_ITOP_CommType.Location = new System.Drawing.Point(147, 72);
            this.cbo_ITOP_CommType.Name = "cbo_ITOP_CommType";
            this.cbo_ITOP_CommType.Size = new System.Drawing.Size(85, 20);
            this.cbo_ITOP_CommType.TabIndex = 5;
            this.cbo_ITOP_CommType.Text = "Collecting Data";
            this.cbo_ITOP_CommType.SelectedIndexChanged += new System.EventHandler(this.cbo_ITOP_CommType_SelectedIndexChanged);
            // 
            // tb_ITOP_ChnlNum
            // 
            this.tb_ITOP_ChnlNum.Location = new System.Drawing.Point(189, 43);
            this.tb_ITOP_ChnlNum.Name = "tb_ITOP_ChnlNum";
            this.tb_ITOP_ChnlNum.Size = new System.Drawing.Size(43, 21);
            this.tb_ITOP_ChnlNum.TabIndex = 4;
            this.tb_ITOP_ChnlNum.Text = "3";
            this.tb_ITOP_ChnlNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_ITOP_SamplingTime
            // 
            this.tb_ITOP_SamplingTime.Location = new System.Drawing.Point(166, 16);
            this.tb_ITOP_SamplingTime.Name = "tb_ITOP_SamplingTime";
            this.tb_ITOP_SamplingTime.Size = new System.Drawing.Size(43, 21);
            this.tb_ITOP_SamplingTime.TabIndex = 3;
            this.tb_ITOP_SamplingTime.Text = "10";
            this.tb_ITOP_SamplingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "Communication Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Channel Amount:";
            // 
            // lbl_ITOP_SamplingTime
            // 
            this.lbl_ITOP_SamplingTime.AutoSize = true;
            this.lbl_ITOP_SamplingTime.Location = new System.Drawing.Point(14, 19);
            this.lbl_ITOP_SamplingTime.Name = "lbl_ITOP_SamplingTime";
            this.lbl_ITOP_SamplingTime.Size = new System.Drawing.Size(89, 12);
            this.lbl_ITOP_SamplingTime.TabIndex = 0;
            this.lbl_ITOP_SamplingTime.Text = "Cycling Delay:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Test:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 31);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Output:";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(178, 452);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(55, 31);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Parameters:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(88, 205);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 43);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.zgcRawdata);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(704, 499);
            this.splitContainer2.SplitterDistance = 385;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtbLog);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 273);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 226);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 17);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(379, 206);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            this.rtbLog.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 273);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data View";
            // 
            // rtbData
            // 
            this.rtbData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rtbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbData.Location = new System.Drawing.Point(3, 17);
            this.rtbData.Name = "rtbData";
            this.rtbData.Size = new System.Drawing.Size(379, 253);
            this.rtbData.TabIndex = 0;
            this.rtbData.Text = "";
            this.rtbData.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pb_AutoClose);
            this.groupBox3.Controls.Add(this.pb_Drift);
            this.groupBox3.Controls.Add(this.pb_Signal);
            this.groupBox3.Controls.Add(this.pb_Noise);
            this.groupBox3.Controls.Add(this.pbarAutoCloseProc);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.pbarDriftProc);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.pbarSignalProc);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.pbarNoiseProc);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 248);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Graph View";
            // 
            // zgcRawdata
            // 
            this.zgcRawdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcRawdata.Location = new System.Drawing.Point(0, 248);
            this.zgcRawdata.Margin = new System.Windows.Forms.Padding(4);
            this.zgcRawdata.Name = "zgcRawdata";
            this.zgcRawdata.ScrollGrace = 0D;
            this.zgcRawdata.ScrollMaxX = 0D;
            this.zgcRawdata.ScrollMaxY = 0D;
            this.zgcRawdata.ScrollMaxY2 = 0D;
            this.zgcRawdata.ScrollMinX = 0D;
            this.zgcRawdata.ScrollMinY = 0D;
            this.zgcRawdata.ScrollMinY2 = 0D;
            this.zgcRawdata.Size = new System.Drawing.Size(315, 251);
            this.zgcRawdata.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1250, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(407, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Importing Module";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1256, 584);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tmr_DataScanning
            // 
            this.tmr_DataScanning.Interval = 2000;
            this.tmr_DataScanning.Tick += new System.EventHandler(this.tmr_DataScanning_Tick);
            // 
            // tmr_AutoStart
            // 
            this.tmr_AutoStart.Interval = 1000;
            this.tmr_AutoStart.Tick += new System.EventHandler(this.tmr_AutoStart_Tick);
            // 
            // pbarNoiseProc
            // 
            this.pbarNoiseProc.Location = new System.Drawing.Point(175, 51);
            this.pbarNoiseProc.Name = "pbarNoiseProc";
            this.pbarNoiseProc.Size = new System.Drawing.Size(81, 23);
            this.pbarNoiseProc.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarNoiseProc.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "Noise Process:";
            // 
            // pbarDriftProc
            // 
            this.pbarDriftProc.Location = new System.Drawing.Point(175, 149);
            this.pbarDriftProc.Name = "pbarDriftProc";
            this.pbarDriftProc.Size = new System.Drawing.Size(81, 23);
            this.pbarDriftProc.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarDriftProc.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(44, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "Drift Process:";
            // 
            // pbarSignalProc
            // 
            this.pbarSignalProc.Location = new System.Drawing.Point(175, 100);
            this.pbarSignalProc.Name = "pbarSignalProc";
            this.pbarSignalProc.Size = new System.Drawing.Size(81, 23);
            this.pbarSignalProc.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarSignalProc.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(44, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 12);
            this.label18.TabIndex = 4;
            this.label18.Text = "Signal Process:";
            // 
            // pbarAutoCloseProc
            // 
            this.pbarAutoCloseProc.Location = new System.Drawing.Point(175, 198);
            this.pbarAutoCloseProc.Maximum = 5;
            this.pbarAutoCloseProc.Name = "pbarAutoCloseProc";
            this.pbarAutoCloseProc.Size = new System.Drawing.Size(81, 23);
            this.pbarAutoCloseProc.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarAutoCloseProc.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(44, 203);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(119, 12);
            this.label19.TabIndex = 8;
            this.label19.Text = "Auto Close Process:";
            // 
            // pb_Noise
            // 
            this.pb_Noise.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Noise.BackgroundImage")));
            this.pb_Noise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Noise.Location = new System.Drawing.Point(277, 51);
            this.pb_Noise.Name = "pb_Noise";
            this.pb_Noise.Size = new System.Drawing.Size(30, 30);
            this.pb_Noise.TabIndex = 10;
            this.pb_Noise.TabStop = false;
            // 
            // pb_Signal
            // 
            this.pb_Signal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Signal.BackgroundImage")));
            this.pb_Signal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Signal.Location = new System.Drawing.Point(277, 98);
            this.pb_Signal.Name = "pb_Signal";
            this.pb_Signal.Size = new System.Drawing.Size(30, 30);
            this.pb_Signal.TabIndex = 11;
            this.pb_Signal.TabStop = false;
            // 
            // pb_Drift
            // 
            this.pb_Drift.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Drift.BackgroundImage")));
            this.pb_Drift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Drift.Location = new System.Drawing.Point(277, 149);
            this.pb_Drift.Name = "pb_Drift";
            this.pb_Drift.Size = new System.Drawing.Size(30, 30);
            this.pb_Drift.TabIndex = 12;
            this.pb_Drift.TabStop = false;
            // 
            // pb_AutoClose
            // 
            this.pb_AutoClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_AutoClose.BackgroundImage")));
            this.pb_AutoClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_AutoClose.Location = new System.Drawing.Point(277, 198);
            this.pb_AutoClose.Name = "pb_AutoClose";
            this.pb_AutoClose.Size = new System.Drawing.Size(30, 30);
            this.pb_AutoClose.TabIndex = 13;
            this.pb_AutoClose.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Importing Module, 2017/03/20, v0.8, y.wang@newdegreetech.com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Noise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Signal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Drift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AutoClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private Label label1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private GroupBox groupBox2;
        private RichTextBox rtbData;
        private GroupBox groupBox3;
        private ZedGraphControl zgcRawdata;
        private Button btnSave;
        private Button btnView;
        private Button btnStart;
        private GroupBox groupBox5;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label5;
        private Panel panel1;
        private Label lbl_ITOP_SamplingTime;
        private Label label7;
        private Label label8;
        private TextBox tb_ITOP_SamplingTime;
        private TextBox tb_ITOP_ChnlNum;
        private ComboBox cbo_ITOP_CommType;
        private Panel panel2;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label lbl_ITOP_RealScanningRate;
        private Label lbl_ITOP_Drift;
        private Label lbl_ITOP_Noise;
        private Timer tmr_DataScanning;
        private TextBox tb_ITOP_ObservationInterval;
        private Label label9;
        private GroupBox groupBox4;
        private RichTextBox rtbLog;
        private TextBox tb_ITOP_RawdataSavePath;
        private Label label14;
        private Label label6;
        private Button btnClear;
        private TextBox tb_ITOP_Settings;
        private Label label13;
        private TextBox tb_ITOP_InfoSavePath;
        private Timer tmr_AutoStart;
        private ProgressBar pbarAutoCloseProc;
        private Label label19;
        private ProgressBar pbarDriftProc;
        private Label label17;
        private ProgressBar pbarSignalProc;
        private Label label18;
        private ProgressBar pbarNoiseProc;
        private Label label16;
        private PictureBox pb_AutoClose;
        private PictureBox pb_Drift;
        private PictureBox pb_Signal;
        private PictureBox pb_Noise;
    }
}

