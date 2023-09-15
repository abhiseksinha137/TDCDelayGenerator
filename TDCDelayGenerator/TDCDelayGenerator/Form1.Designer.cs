namespace TDCDelayGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxServo = new System.Windows.Forms.GroupBox();
            this.btnBeamBlock = new System.Windows.Forms.Button();
            this.btnBeamOn = new System.Windows.Forms.Button();
            this.groupBoxDelayChip = new System.Windows.Forms.GroupBox();
            this.trackBarDelay = new System.Windows.Forms.TrackBar();
            this.txtBxDelay = new System.Windows.Forms.TextBox();
            this.btnSendDelay = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxStage = new System.Windows.Forms.GroupBox();
            this.btnMoveRel = new System.Windows.Forms.Button();
            this.btnMoveAbs = new System.Windows.Forms.Button();
            this.btnUpdateCurrentPos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxMoveRel = new System.Windows.Forms.TextBox();
            this.txtBxCurrentPos = new System.Windows.Forms.TextBox();
            this.txtBxmoveAbs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblexpStatus = new System.Windows.Forms.Label();
            this.lblPositionNumber = new System.Windows.Forms.Label();
            this.lblSweepNum = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lblStageStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnStopExp = new System.Windows.Forms.Button();
            this.btnStartExp = new System.Windows.Forms.Button();
            this.txtBxIterations = new System.Windows.Forms.TextBox();
            this.txtBxNumber = new System.Windows.Forms.TextBox();
            this.txtBxStop = new System.Windows.Forms.TextBox();
            this.txtBxACQseconds = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBxStart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gradientPanel2 = new TDCDelayGenerator.GradientPanel();
            this.tareStage = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.txtBxBeamOff = new System.Windows.Forms.TextBox();
            this.txtBxBeamOn = new System.Windows.Forms.TextBox();
            this.txtBxStepsPerDegree = new System.Windows.Forms.TextBox();
            this.lblBeamOff = new System.Windows.Forms.Label();
            this.lblBeamOn = new System.Windows.Forms.Label();
            this.lblSettingsPerDegree = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.comboSerial1 = new customControl.comboSerial();
            this.gradientPanel1 = new TDCDelayGenerator.GradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxServo.SuspendLayout();
            this.groupBoxDelayChip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).BeginInit();
            this.groupBoxStage.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(114, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightYellow;
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxServo);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxDelayChip);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxStage);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel2.Controls.Add(this.pnlStatus);
            this.splitContainer1.Panel2.Controls.Add(this.lblPositionNumber);
            this.splitContainer1.Panel2.Controls.Add(this.lblSweepNum);
            this.splitContainer1.Panel2.Controls.Add(this.lbl13);
            this.splitContainer1.Panel2.Controls.Add(this.lblStageStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.btnStopExp);
            this.splitContainer1.Panel2.Controls.Add(this.btnStartExp);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxIterations);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxNumber);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxStop);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxACQseconds);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxStart);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(599, 326);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 6;
            // 
            // groupBoxServo
            // 
            this.groupBoxServo.Controls.Add(this.btnBeamBlock);
            this.groupBoxServo.Controls.Add(this.btnBeamOn);
            this.groupBoxServo.Location = new System.Drawing.Point(5, 200);
            this.groupBoxServo.Name = "groupBoxServo";
            this.groupBoxServo.Size = new System.Drawing.Size(352, 81);
            this.groupBoxServo.TabIndex = 1;
            this.groupBoxServo.TabStop = false;
            this.groupBoxServo.Text = "Servo";
            // 
            // btnBeamBlock
            // 
            this.btnBeamBlock.Location = new System.Drawing.Point(90, 19);
            this.btnBeamBlock.Name = "btnBeamBlock";
            this.btnBeamBlock.Size = new System.Drawing.Size(75, 23);
            this.btnBeamBlock.TabIndex = 0;
            this.btnBeamBlock.Text = "Beam Block";
            this.btnBeamBlock.UseVisualStyleBackColor = true;
            this.btnBeamBlock.Click += new System.EventHandler(this.btnBeamBlock_Click);
            // 
            // btnBeamOn
            // 
            this.btnBeamOn.Location = new System.Drawing.Point(6, 19);
            this.btnBeamOn.Name = "btnBeamOn";
            this.btnBeamOn.Size = new System.Drawing.Size(75, 23);
            this.btnBeamOn.TabIndex = 0;
            this.btnBeamOn.Text = "Beam On";
            this.btnBeamOn.UseVisualStyleBackColor = true;
            this.btnBeamOn.Click += new System.EventHandler(this.btnBeamOn_Click);
            // 
            // groupBoxDelayChip
            // 
            this.groupBoxDelayChip.Controls.Add(this.trackBarDelay);
            this.groupBoxDelayChip.Controls.Add(this.txtBxDelay);
            this.groupBoxDelayChip.Controls.Add(this.btnSendDelay);
            this.groupBoxDelayChip.Controls.Add(this.label4);
            this.groupBoxDelayChip.Location = new System.Drawing.Point(5, 117);
            this.groupBoxDelayChip.Name = "groupBoxDelayChip";
            this.groupBoxDelayChip.Size = new System.Drawing.Size(352, 59);
            this.groupBoxDelayChip.TabIndex = 1;
            this.groupBoxDelayChip.TabStop = false;
            this.groupBoxDelayChip.Text = "Delay Chip";
            // 
            // trackBarDelay
            // 
            this.trackBarDelay.Location = new System.Drawing.Point(169, 20);
            this.trackBarDelay.Maximum = 255;
            this.trackBarDelay.Name = "trackBarDelay";
            this.trackBarDelay.Size = new System.Drawing.Size(89, 45);
            this.trackBarDelay.TabIndex = 2;
            this.trackBarDelay.Scroll += new System.EventHandler(this.trackBarDelay_Scroll);
            // 
            // txtBxDelay
            // 
            this.txtBxDelay.Location = new System.Drawing.Point(88, 20);
            this.txtBxDelay.Name = "txtBxDelay";
            this.txtBxDelay.Size = new System.Drawing.Size(75, 20);
            this.txtBxDelay.TabIndex = 1;
            this.txtBxDelay.TextChanged += new System.EventHandler(this.txtBxDelay_TextChanged);
            // 
            // btnSendDelay
            // 
            this.btnSendDelay.Location = new System.Drawing.Point(267, 17);
            this.btnSendDelay.Name = "btnSendDelay";
            this.btnSendDelay.Size = new System.Drawing.Size(75, 23);
            this.btnSendDelay.TabIndex = 0;
            this.btnSendDelay.Text = "Send";
            this.btnSendDelay.UseVisualStyleBackColor = true;
            this.btnSendDelay.Click += new System.EventHandler(this.btnSendDelay_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Delay Value";
            // 
            // groupBoxStage
            // 
            this.groupBoxStage.Controls.Add(this.btnMoveRel);
            this.groupBoxStage.Controls.Add(this.btnMoveAbs);
            this.groupBoxStage.Controls.Add(this.btnUpdateCurrentPos);
            this.groupBoxStage.Controls.Add(this.label5);
            this.groupBoxStage.Controls.Add(this.label6);
            this.groupBoxStage.Controls.Add(this.label3);
            this.groupBoxStage.Controls.Add(this.txtBxMoveRel);
            this.groupBoxStage.Controls.Add(this.txtBxCurrentPos);
            this.groupBoxStage.Controls.Add(this.txtBxmoveAbs);
            this.groupBoxStage.Location = new System.Drawing.Point(5, 19);
            this.groupBoxStage.Name = "groupBoxStage";
            this.groupBoxStage.Size = new System.Drawing.Size(352, 81);
            this.groupBoxStage.TabIndex = 1;
            this.groupBoxStage.TabStop = false;
            this.groupBoxStage.Text = "Rotation Stage";
            // 
            // btnMoveRel
            // 
            this.btnMoveRel.Location = new System.Drawing.Point(169, 43);
            this.btnMoveRel.Name = "btnMoveRel";
            this.btnMoveRel.Size = new System.Drawing.Size(42, 23);
            this.btnMoveRel.TabIndex = 3;
            this.btnMoveRel.Text = "Go";
            this.btnMoveRel.UseVisualStyleBackColor = true;
            this.btnMoveRel.Click += new System.EventHandler(this.btnMoveRel_Click);
            // 
            // btnMoveAbs
            // 
            this.btnMoveAbs.Location = new System.Drawing.Point(169, 17);
            this.btnMoveAbs.Name = "btnMoveAbs";
            this.btnMoveAbs.Size = new System.Drawing.Size(42, 23);
            this.btnMoveAbs.TabIndex = 3;
            this.btnMoveAbs.Text = "Go";
            this.btnMoveAbs.UseVisualStyleBackColor = true;
            this.btnMoveAbs.Click += new System.EventHandler(this.btnMoveAbs_Click);
            // 
            // btnUpdateCurrentPos
            // 
            this.btnUpdateCurrentPos.Location = new System.Drawing.Point(267, 42);
            this.btnUpdateCurrentPos.Name = "btnUpdateCurrentPos";
            this.btnUpdateCurrentPos.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCurrentPos.TabIndex = 2;
            this.btnUpdateCurrentPos.Text = "Update";
            this.btnUpdateCurrentPos.UseVisualStyleBackColor = true;
            this.btnUpdateCurrentPos.Click += new System.EventHandler(this.btnUpdateCurrentPos_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Current Pos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Move Relative";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Move Absolute";
            // 
            // txtBxMoveRel
            // 
            this.txtBxMoveRel.Location = new System.Drawing.Point(88, 45);
            this.txtBxMoveRel.Name = "txtBxMoveRel";
            this.txtBxMoveRel.Size = new System.Drawing.Size(75, 20);
            this.txtBxMoveRel.TabIndex = 0;
            this.txtBxMoveRel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxMoveRel_KeyDown);
            this.txtBxMoveRel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxMoveRel_KeyPress);
            // 
            // txtBxCurrentPos
            // 
            this.txtBxCurrentPos.Enabled = false;
            this.txtBxCurrentPos.Location = new System.Drawing.Point(267, 17);
            this.txtBxCurrentPos.Name = "txtBxCurrentPos";
            this.txtBxCurrentPos.Size = new System.Drawing.Size(75, 20);
            this.txtBxCurrentPos.TabIndex = 0;
            // 
            // txtBxmoveAbs
            // 
            this.txtBxmoveAbs.Location = new System.Drawing.Point(88, 19);
            this.txtBxmoveAbs.Name = "txtBxmoveAbs";
            this.txtBxmoveAbs.Size = new System.Drawing.Size(75, 20);
            this.txtBxmoveAbs.TabIndex = 0;
            this.txtBxmoveAbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxmoveAbs_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controls";
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblexpStatus);
            this.pnlStatus.Location = new System.Drawing.Point(99, 283);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(115, 38);
            this.pnlStatus.TabIndex = 5;
            // 
            // lblexpStatus
            // 
            this.lblexpStatus.AutoSize = true;
            this.lblexpStatus.Location = new System.Drawing.Point(4, 15);
            this.lblexpStatus.Name = "lblexpStatus";
            this.lblexpStatus.Size = new System.Drawing.Size(67, 13);
            this.lblexpStatus.TabIndex = 0;
            this.lblexpStatus.Text = "Not Running";
            // 
            // lblPositionNumber
            // 
            this.lblPositionNumber.AutoSize = true;
            this.lblPositionNumber.Location = new System.Drawing.Point(65, 200);
            this.lblPositionNumber.Name = "lblPositionNumber";
            this.lblPositionNumber.Size = new System.Drawing.Size(10, 13);
            this.lblPositionNumber.TabIndex = 4;
            this.lblPositionNumber.Text = "-";
            // 
            // lblSweepNum
            // 
            this.lblSweepNum.AutoSize = true;
            this.lblSweepNum.Location = new System.Drawing.Point(65, 183);
            this.lblSweepNum.Name = "lblSweepNum";
            this.lblSweepNum.Size = new System.Drawing.Size(10, 13);
            this.lblSweepNum.TabIndex = 4;
            this.lblSweepNum.Text = "-";
            // 
            // lbl13
            // 
            this.lbl13.AutoSize = true;
            this.lbl13.Location = new System.Drawing.Point(5, 200);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(44, 13);
            this.lbl13.TabIndex = 4;
            this.lbl13.Text = "Position";
            // 
            // lblStageStatus
            // 
            this.lblStageStatus.AutoSize = true;
            this.lblStageStatus.Location = new System.Drawing.Point(33, 298);
            this.lblStageStatus.Name = "lblStageStatus";
            this.lblStageStatus.Size = new System.Drawing.Size(16, 13);
            this.lblStageStatus.TabIndex = 4;
            this.lblStageStatus.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Sweep No. ";
            // 
            // btnStopExp
            // 
            this.btnStopExp.Location = new System.Drawing.Point(120, 225);
            this.btnStopExp.Name = "btnStopExp";
            this.btnStopExp.Size = new System.Drawing.Size(94, 41);
            this.btnStopExp.TabIndex = 3;
            this.btnStopExp.Text = "Stop Experiment";
            this.btnStopExp.UseVisualStyleBackColor = true;
            this.btnStopExp.Click += new System.EventHandler(this.btnStopExp_Click);
            // 
            // btnStartExp
            // 
            this.btnStartExp.Location = new System.Drawing.Point(19, 225);
            this.btnStartExp.Name = "btnStartExp";
            this.btnStartExp.Size = new System.Drawing.Size(95, 41);
            this.btnStartExp.TabIndex = 3;
            this.btnStartExp.Text = "Start Experiment";
            this.btnStartExp.UseVisualStyleBackColor = true;
            this.btnStartExp.Click += new System.EventHandler(this.btnStartExp_Click);
            // 
            // txtBxIterations
            // 
            this.txtBxIterations.Location = new System.Drawing.Point(114, 108);
            this.txtBxIterations.Name = "txtBxIterations";
            this.txtBxIterations.Size = new System.Drawing.Size(100, 20);
            this.txtBxIterations.TabIndex = 2;
            // 
            // txtBxNumber
            // 
            this.txtBxNumber.Location = new System.Drawing.Point(114, 84);
            this.txtBxNumber.Name = "txtBxNumber";
            this.txtBxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtBxNumber.TabIndex = 2;
            // 
            // txtBxStop
            // 
            this.txtBxStop.Location = new System.Drawing.Point(114, 61);
            this.txtBxStop.Name = "txtBxStop";
            this.txtBxStop.Size = new System.Drawing.Size(100, 20);
            this.txtBxStop.TabIndex = 2;
            // 
            // txtBxACQseconds
            // 
            this.txtBxACQseconds.Location = new System.Drawing.Point(114, 132);
            this.txtBxACQseconds.Name = "txtBxACQseconds";
            this.txtBxACQseconds.Size = new System.Drawing.Size(100, 20);
            this.txtBxACQseconds.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Acquisition (Seconds)";
            // 
            // txtBxStart
            // 
            this.txtBxStart.Location = new System.Drawing.Point(114, 38);
            this.txtBxStart.Name = "txtBxStart";
            this.txtBxStart.Size = new System.Drawing.Size(100, 20);
            this.txtBxStart.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Start Angle";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Iterations";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Number of Angles";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Stop Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Experiment";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Angle = -90F;
            this.gradientPanel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.gradientPanel2.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel2.Controls.Add(this.tareStage);
            this.gradientPanel2.Controls.Add(this.btnSaveChanges);
            this.gradientPanel2.Controls.Add(this.txtBxBeamOff);
            this.gradientPanel2.Controls.Add(this.txtBxBeamOn);
            this.gradientPanel2.Controls.Add(this.txtBxStepsPerDegree);
            this.gradientPanel2.Controls.Add(this.lblBeamOff);
            this.gradientPanel2.Controls.Add(this.lblBeamOn);
            this.gradientPanel2.Controls.Add(this.lblSettingsPerDegree);
            this.gradientPanel2.Controls.Add(this.lblSettings);
            this.gradientPanel2.Controls.Add(this.comboSerial1);
            this.gradientPanel2.Location = new System.Drawing.Point(0, 31);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(112, 326);
            this.gradientPanel2.TabIndex = 10;
            this.gradientPanel2.TopColor = System.Drawing.Color.White;
            // 
            // tareStage
            // 
            this.tareStage.Location = new System.Drawing.Point(3, 299);
            this.tareStage.Name = "tareStage";
            this.tareStage.Size = new System.Drawing.Size(92, 23);
            this.tareStage.TabIndex = 9;
            this.tareStage.Text = "Tare Stage";
            this.tareStage.UseVisualStyleBackColor = true;
            this.tareStage.Click += new System.EventHandler(this.tareStage_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(3, 265);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(92, 23);
            this.btnSaveChanges.TabIndex = 8;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // txtBxBeamOff
            // 
            this.txtBxBeamOff.Location = new System.Drawing.Point(8, 235);
            this.txtBxBeamOff.Name = "txtBxBeamOff";
            this.txtBxBeamOff.Size = new System.Drawing.Size(71, 20);
            this.txtBxBeamOff.TabIndex = 7;
            // 
            // txtBxBeamOn
            // 
            this.txtBxBeamOn.Location = new System.Drawing.Point(8, 184);
            this.txtBxBeamOn.Name = "txtBxBeamOn";
            this.txtBxBeamOn.Size = new System.Drawing.Size(71, 20);
            this.txtBxBeamOn.TabIndex = 7;
            // 
            // txtBxStepsPerDegree
            // 
            this.txtBxStepsPerDegree.Location = new System.Drawing.Point(8, 137);
            this.txtBxStepsPerDegree.Name = "txtBxStepsPerDegree";
            this.txtBxStepsPerDegree.Size = new System.Drawing.Size(71, 20);
            this.txtBxStepsPerDegree.TabIndex = 7;
            // 
            // lblBeamOff
            // 
            this.lblBeamOff.AutoSize = true;
            this.lblBeamOff.Location = new System.Drawing.Point(5, 215);
            this.lblBeamOff.Name = "lblBeamOff";
            this.lblBeamOff.Size = new System.Drawing.Size(51, 13);
            this.lblBeamOff.TabIndex = 6;
            this.lblBeamOff.Text = "Beam Off";
            // 
            // lblBeamOn
            // 
            this.lblBeamOn.AutoSize = true;
            this.lblBeamOn.Location = new System.Drawing.Point(5, 164);
            this.lblBeamOn.Name = "lblBeamOn";
            this.lblBeamOn.Size = new System.Drawing.Size(51, 13);
            this.lblBeamOn.TabIndex = 6;
            this.lblBeamOn.Text = "Beam On";
            // 
            // lblSettingsPerDegree
            // 
            this.lblSettingsPerDegree.AutoSize = true;
            this.lblSettingsPerDegree.Location = new System.Drawing.Point(5, 118);
            this.lblSettingsPerDegree.Name = "lblSettingsPerDegree";
            this.lblSettingsPerDegree.Size = new System.Drawing.Size(90, 13);
            this.lblSettingsPerDegree.TabIndex = 6;
            this.lblSettingsPerDegree.Text = "Steps per Degree";
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.Location = new System.Drawing.Point(5, 96);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(53, 13);
            this.lblSettings.TabIndex = 6;
            this.lblSettings.Text = "Settings";
            // 
            // comboSerial1
            // 
            this.comboSerial1.Location = new System.Drawing.Point(3, 9);
            this.comboSerial1.Name = "comboSerial1";
            this.comboSerial1.Size = new System.Drawing.Size(109, 72);
            this.comboSerial1.TabIndex = 5;
            this.comboSerial1.Load += new System.EventHandler(this.comboSerial1_Load);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = -90F;
            this.gradientPanel1.BackColor = System.Drawing.Color.Silver;
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Location = new System.Drawing.Point(-1, -1);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(937, 30);
            this.gradientPanel1.TabIndex = 9;
            this.gradientPanel1.TopColor = System.Drawing.Color.White;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 362);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Delay Generator Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxServo.ResumeLayout(false);
            this.groupBoxDelayChip.ResumeLayout(false);
            this.groupBoxDelayChip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).EndInit();
            this.groupBoxStage.ResumeLayout(false);
            this.groupBoxStage.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private customControl.comboSerial comboSerial1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxStage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxServo;
        private System.Windows.Forms.GroupBox groupBoxDelayChip;
        private System.Windows.Forms.Button btnMoveRel;
        private System.Windows.Forms.Button btnMoveAbs;
        private System.Windows.Forms.Button btnUpdateCurrentPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxMoveRel;
        private System.Windows.Forms.TextBox txtBxCurrentPos;
        private System.Windows.Forms.TextBox txtBxmoveAbs;
        private System.Windows.Forms.Button btnSendDelay;
        private System.Windows.Forms.TrackBar trackBarDelay;
        private System.Windows.Forms.TextBox txtBxDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBeamBlock;
        private System.Windows.Forms.Button btnBeamOn;
        private GradientPanel gradientPanel1;
        private GradientPanel gradientPanel2;
        private System.Windows.Forms.TextBox txtBxStepsPerDegree;
        private System.Windows.Forms.Label lblSettingsPerDegree;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button tareStage;
        private System.Windows.Forms.TextBox txtBxBeamOff;
        private System.Windows.Forms.TextBox txtBxBeamOn;
        private System.Windows.Forms.Label lblBeamOff;
        private System.Windows.Forms.Label lblBeamOn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtBxIterations;
        private System.Windows.Forms.TextBox txtBxNumber;
        private System.Windows.Forms.TextBox txtBxStop;
        private System.Windows.Forms.TextBox txtBxStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStopExp;
        private System.Windows.Forms.Button btnStartExp;
        private System.Windows.Forms.TextBox txtBxACQseconds;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPositionNumber;
        private System.Windows.Forms.Label lblSweepNum;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblexpStatus;
        private System.Windows.Forms.Label lblStageStatus;
    }
}

