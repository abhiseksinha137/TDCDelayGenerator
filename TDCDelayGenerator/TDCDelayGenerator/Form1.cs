using Newport.ConexAGPCmdLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDCDelayGenerator
{
    public partial class Form1 : Form
    {
        //private readonly object textbox2;

        int beamOn;
        int beamOff;
        int stepsPerDegree;
        public Form1()
        {
            InitializeComponent();
        }


        float currentDegVal;
        int currentDelay;
        int currentServo;
        ConexAGPCmds conex;
        String saveFileName;
        double conexCurrentPos;
        AutoResetEvent mreCom;
        AutoResetEvent mreMov;
        AutoResetEvent sleepTimer;
        private void Form1_Load(object sender, EventArgs e)
        {
            mreCom =new AutoResetEvent(false);
            mreMov = new AutoResetEvent(false);

            //this.BackColor = Color.Lime;
            //this.TransparencyKey = Color.Lime;

            comboSerial1.com.DataReceived += new SerialDataReceivedEventHandler(dataReceived); // Add Handler
            // Initialize settings
            initializeSettings();

            // Set transparent back color
            lblSettings.BackColor= System.Drawing.Color.Transparent;
            lblSettingsPerDegree.BackColor= System.Drawing.Color.Transparent;
            comboSerial1.BackColor= System.Drawing.Color.Transparent;
            lblBeamOn.BackColor = System.Drawing.Color.Transparent;
            lblBeamOff.BackColor = System.Drawing.Color.Transparent;
            //changePanelStaus("Off");

            // Dummy values
            txtBxStart.Text = "3";
            txtBxStop.Text = "93";
            txtBxNumber.Text = "5";
            txtBxIterations.Text = "24";
            txtBxACQseconds.Text = "1000";
            txtBxFileName.Text = "C:/Users/abhisek/Desktop/text.txt";

            //MessageBox.Show((2 % 2).ToString());

            // Initialize conex
            conex = new ConexAGPCmds();

            // Check linspace
            //float[] nums = linspace(2, 2, 2);
            //MessageBox.Show(string.Join(" ", nums));

            // Tool Tip About
            toolTipAbout.SetToolTip(lblAbout, "Delay Experiment Control" + Environment.NewLine +
                "Developed by Abhisek");
            toolTipAbout.InitialDelay = 0;
            toolTipAbout.AutoPopDelay =60000;
            // Tool Tip Filename TextBox
            toolTiptxtBxFileName.SetToolTip(txtBxFileName, "Full path of log file in .txt format");
            // Tool Tip Conex Connect
            toolTipConexConnect.SetToolTip(btnConexConnect, "Connect Conex");
            // Tool Tip Connect Disconnect
            toolTipConexDisconnect.SetToolTip(btnConexDisconnect, "DisConnect Conex");

        }
        private void initializeSettings()
        {
            stepsPerDegree = Properties.Settings.Default.stepsPerDegree;
            beamOn = Properties.Settings.Default.beamOn;
            beamOff = Properties.Settings.Default.beamOff;

            txtBxStepsPerDegree.Text = stepsPerDegree.ToString();
            txtBxBeamOn.Text = beamOn.ToString();
            txtBxBeamOff.Text = beamOff.ToString();
        }


        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String data = comboSerial1.com.ReadLine();
            try
            {
                if (data.Substring(0, 3) != "com")
                { 
                    string[] substrings = data.Split(',');
                    float stagePos = int.Parse(substrings[0]) / stepsPerDegree;
                    int delay = int.Parse(substrings[1]);
                    int servo = int.Parse(substrings[2]);

                    //int val;
                    //int.TryParse(data, out val);
                    //int valDeg = val/stepsPerDegree;
                    currentDegVal = stagePos;
                    currentDelay = delay;
                    currentServo = servo;

                    ThreadHelperClass.SetText(this, txtBxCurrentPos, currentDegVal.ToString());

                    ThreadHelperClass.SetText(this, txtBxCurrentDelay, currentDelay.ToString());

                    ThreadHelperClass.SetText(this, txtBxCurrentServo, currentServo.ToString());
                    mreMov.Set();
                }
                else
                {
                    String received = data.Substring(3);
                    mreCom.Set();
                }

            }
            catch (Exception ex)
            { }
        }




        public void getCurrentStagePos()
        {
            comboSerial1.sendSerial("p");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getCurrentStagePos();
        }

        private void comboSerial1_Load(object sender, EventArgs e)
        {

        }

        private void trackBarDelay_Scroll(object sender, EventArgs e)
        {
            txtBxDelay.Text = trackBarDelay.Value.ToString();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            saveSettings();
        }
        private void saveSettings()
        {
            
            try {
                Properties.Settings.Default.stepsPerDegree = int.Parse(txtBxStepsPerDegree.Text);
                Properties.Settings.Default.beamOn = int.Parse(txtBxBeamOn.Text);
                Properties.Settings.Default.beamOff = int.Parse(txtBxBeamOff.Text);
                Properties.Settings.Default.Save();

                initializeSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tareStage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Tare Rotation Satge?", "Tare?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                tareRotStage();
        }
        public void tareRotStage()
        {
            comboSerial1.sendSerial("t");  // Tare
            Thread.Sleep(1000);
            comboSerial1.sendSerial("p");  // Query Current Value
        }

        private void btnUpdateCurrentPos_Click(object sender, EventArgs e)
        {
            getCurrentStagePos();
        }

        public void moveRelative(float moveRelDeg)
        {
            //MessageBox.Show("Received Rel");

            //int steps = moveRelDeg * stepsPerDegree;
            //comboSerial1.com.DiscardInBuffer();
            //comboSerial1.com.DiscardInBuffer();

            //comboSerial1.sendSerial("r"+steps.ToString());
            //ThreadHelperClass.SetText(this, lblexpStatus, "Moved " + steps.ToString() + " steps");

            float target=currentDegVal + moveRelDeg;
            moveAbs(target);
        }

        private void btnMoveAbs_Click(object sender, EventArgs e)
        {
            try
            {
                float targetDeg = float.Parse(txtBxmoveAbs.Text);
                moveAbs(targetDeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        float RoundToTwoPlaces(float input)
        {
            float output = (float)Math.Round(input * 100) / 100;
            return output;
        }
        float[] RoundToTwoPlaces(float[] input)
        {
            float[] output = new float[input.Length];
            for (int ii=0; ii<input.Length; ii++)
            {
                output[ii] = RoundToTwoPlaces(input[ii]);
            }
            return output;
        }
        void moveAbs(float targetDeg)
        {
            int steps = (int) (RoundToTwoPlaces(targetDeg) * stepsPerDegree);
            //comboSerial1.com.DiscardInBuffer();
            //comboSerial1.com.DiscardInBuffer();

            comboSerial1.sendSerial("r" + steps.ToString());
            Thread.Sleep(500);
            ThreadHelperClass.SetText(this, lblexpStatus, "Moved " + steps.ToString() + " steps");


            //if (txtBxCurrentPos.Text == "")
            //{
            //    MessageBox.Show("Update the Current Position First");
            //}
            //else
            //{
            //    int currentDeg = int.Parse(txtBxCurrentPos.Text);
            //    int relDeg = targetDeg - currentDeg;
            //    //MessageBox.Show("Sent From Abs");
            //    moveRelative(relDeg);
            //}
            
        }

        private void btnMoveRel_Click(object sender, EventArgs e)
        {
            try
            {
                float relDeg = float.Parse(txtBxMoveRel.Text);
                moveRelative(relDeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBxMoveRel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMoveRel.PerformClick();
            }
        }

        private void txtBxMoveRel_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtBxmoveAbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMoveAbs.PerformClick();
            }
        }

        private void txtBxDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int delayVal = int.Parse(txtBxDelay.Text);
                trackBarDelay.Value = delayVal;
            }
            catch(Exception ex)
            {
                
            }
        }

        private void btnSendDelay_Click(object sender, EventArgs e)
        {
            sendDelay(trackBarDelay.Value);
        }
        
        public void sendDelay(int delayVal)
        {
            comboSerial1.sendSerial("d" + delayVal.ToString());
        }

        private void btnBeamOn_Click(object sender, EventArgs e)
        {
            SendbeamOn();
        }

        private void SendbeamOn()
        {
            comboSerial1.sendSerial("s" + beamOn.ToString());
        }
        private void SendbeamOff()
        {
            comboSerial1.sendSerial("s" + beamOff.ToString());
        }

        private void btnBeamBlock_Click(object sender, EventArgs e)
        {
            SendbeamOff();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStartExp_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }


        public static float[] linspace(float startval, float endval, int steps)
        {
            if (steps == 1 || endval == startval)
            {
                float[] ret = { startval };
                return ret;
            }
            else
            {
                float interval = (endval / Math.Abs(endval)) * Math.Abs(endval - startval) / (steps - 1);
                return (from val in Enumerable.Range(0, steps)
                        select startval + (val * interval)).ToArray();
            }
        }

        private void btnStopExp_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();

                writeToFile("Experiment Interrupted", saveFileName, "a");
                addLog("Experiment Interrupted");
                //changePanelStaus("Off");
            }

        }

        //void changePanelStaus(string status)
        //{
        //    if (status=="On")
        //    {
        //        ThreadHelperClass.SetText(this, lblexpStatus, "Running");
        //        ThreadHelperClass.SetColor(this, pnlStatus, Color.Red);
        //    }
        //    if (status == "Off")
        //    {
        //        ThreadHelperClass.SetText(this, lblexpStatus, "Not Running");
        //        ThreadHelperClass.SetColor(this, pnlStatus, Color.Green);
        //    }

        //}

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{

        //    ThreadHelperClass.SetText(this, lblexpStatus, "Started");
        //    try
        //    {
        //        //changePanelStaus("On");
        //        int startDeg = int.Parse(txtBxStart.Text);
        //        int stopDeg = int.Parse(txtBxStop.Text);
        //        int N= int.Parse(txtBxNumber.Text);
        //        int iterations= int.Parse(txtBxIterations.Text);
        //        int ACQTime = int.Parse(txtBxACQseconds.Text);
        //        int waitLim = 3000;

        //        float [] positions=linspace(startDeg, stopDeg, N);
        //        float [] delays= linspace(0, 255, N);

        //        int deltaTime = ACQTime / (N * iterations) * 1000; // in milliseconds
        //        int iterPositions = 0;
        //        for (int iterSweep = 0; iterSweep < iterations; iterSweep++)
        //        {
        //            ThreadHelperClass.SetText(this, lblSweepNum, (iterSweep + 1).ToString());
        //            if (iterSweep % 2 == 0) // even
        //                iterPositions = 0;
        //            else
        //                iterPositions = N - 1;
        //            //MessageBox.Show(iterSweep.ToString()+","+iterPositions.ToString());
        //            while (iterPositions>=0 && iterPositions < N)
        //            {

        //                int position = (int)(Math.Round(positions[iterPositions]));
        //                ThreadHelperClass.SetText(this, lblPositionNumber, (position).ToString());
        //                Thread.Sleep(1000);
        //                //int relPos = position - currentDegVal;
        //                //comboSerial1.sendSerial("r"+ relPos.ToString()); Thread.Sleep(1000);
        //                moveAbs(position);
        //                int waitIdx = 0;
        //                while (currentDegVal != position) // Wait for stage to reach
        //                {
        //                    //if (comboSerial1.com)
        //                    //if (waitIdx > 10000)
        //                    //{
        //                    //    moveAbs(position);
        //                    //    waitIdx = 0;
        //                    //}
        //                    ThreadHelperClass.SetText(this, lblStageStatus, "Moving " + waitIdx.ToString());
        //                    waitIdx = waitIdx+1;
        //                    if (waitIdx> waitLim)
        //                    {
        //                        moveAbs(position); waitIdx = 0;
        //                    }
        //                    if (backgroundWorker1.CancellationPending)
        //                        return;
        //                }
        //                waitIdx = 0;

        //                // Do your thing
        //                // move servo To on Position
        //                int delay= (int)(Math.Round(delays[iterPositions]));
        //                sendDelay(delay);
        //                Thread.Sleep(100);
        //                while (currentDelay != delay)
        //                {
        //                    ThreadHelperClass.SetText(this, lblStageStatus, "Waiting Delay " + waitIdx.ToString());
        //                    waitIdx = waitIdx + 1;
        //                    if (waitIdx > waitLim)
        //                    {
        //                        sendDelay(delay); waitIdx = 0;
        //                    }
        //                    if (backgroundWorker1.CancellationPending)
        //                        return;
        //                }
        //                waitIdx = 0;
        //                SendbeamOn();
        //                while (currentServo != beamOn)
        //                {
        //                    ThreadHelperClass.SetText(this, lblStageStatus, "Waiting Beam On " + waitIdx.ToString()+ currentServo.ToString());
        //                    waitIdx = waitIdx + 1;
        //                    if (waitIdx > waitLim)
        //                    {
        //                        SendbeamOn(); waitIdx = 0;
        //                    }
        //                    if (backgroundWorker1.CancellationPending)
        //                        return;
        //                }

        //                    // Acquire Data
        //                    Thread.Sleep(deltaTime);

        //                SendbeamOff();

        //                waitIdx = 0;
        //                while (currentServo != beamOff)
        //                {
        //                    ThreadHelperClass.SetText(this, lblStageStatus, "Waiting Beam Off " + waitIdx.ToString());
        //                    waitIdx = waitIdx + 1;
        //                    if (waitIdx > waitLim)
        //                    {
        //                        SendbeamOff(); waitIdx = 0;
        //                    }
        //                    if (backgroundWorker1.CancellationPending)
        //                        return;
        //                }

        //                if (iterSweep%2 ==0) // even
        //                    iterPositions = iterPositions + 1;
        //                else
        //                    iterPositions = iterPositions -1;

        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        //changePanelStaus("Off");
        //        MessageBox.Show(ex.Message);
        //    }

        //}
        bool isWhithinError(float input, float reference, float error)
        {
            input = Math.Abs(input);
            reference = Math.Abs(reference);
            error = Math.Abs(error);

            if ((input + error) > reference && (input - error) < reference)
                return true;
            else
                return false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            clearLog();
            string fileName = saveFileName;
            writeToFile("", fileName, "w"); // clear the file

            ThreadHelperClass.SetText(this, lblexpStatus, "Started");
            try
            {
                //changePanelStaus("On");
                int startDegConex = int.Parse(txtBxConexStart.Text);
                int stopDegConex = int.Parse(txtBxConexStop.Text);
                int NConex = int.Parse(txtBxConexNumber.Text);

                int startDeg = int.Parse(txtBxStart.Text);
                int stopDeg = int.Parse(txtBxStop.Text);
                int N = int.Parse(txtBxNumber.Text);
        
                int iterations = int.Parse(txtBxIterations.Text);
                int ACQTime = int.Parse(txtBxACQseconds.Text);
                int waitLim = 3000;

                float[] positions =RoundToTwoPlaces(linspace(startDeg, stopDeg, N));
                float[] positionsConex = RoundToTwoPlaces(linspace(startDegConex, stopDegConex, NConex));
                float[] delayTimes = linspace(0, 190, N*NConex);
                float[,] delayMatrix = ConvertMatrix(delayTimes, NConex, N);

                int deltaTime = ACQTime / (N * NConex* iterations) * 1000; // in milliseconds
                Stopwatch stopwatch = new Stopwatch(); // Create stopwatch
                int iterPositions = 0;
                int iterConex = 0;

                ThreadHelperClass.SetText(this, txtBxTImePerEvent, ((int)(deltaTime/1000)).ToString());

                for (int iterSweep = 0; iterSweep < iterations; iterSweep++)
                {
                    Thread.Sleep(400);
                    if (backgroundWorker1.CancellationPending)
                        return;

                    if (iterSweep % 2 == 0) // even
                        iterConex = 0;
                    else
                        iterConex = NConex - 1;

                    while (iterConex >= 0 && iterConex < NConex)
                    {
                        Thread.Sleep(400);
                        if (backgroundWorker1.CancellationPending)
                            return;

                        // Move Conex
                        conexMoveAbs(positionsConex[iterConex]);

                        int waitIdx = 0;
                        while (Math.Round(conexCurrentPos) != Math.Round(positionsConex[iterConex]))
                        {
                            ThreadHelperClass.SetText(this, lblStageStatus, "Moving Conex " + waitIdx.ToString());
                            waitIdx = waitIdx + 1;
                            //if (waitIdx > waitLim)
                            //{
                            //    conexMoveAbs(positionsConex[iterConex]); waitIdx = 0;
                            //}
                            if (backgroundWorker1.CancellationPending)
                                return;
                            Thread.Sleep(1000);
                        }



                        ThreadHelperClass.SetText(this, lblSweepNum, (iterSweep + 1).ToString());
                        if ((iterSweep % 2 == 0) && (iterConex % 2 == 0) ) // even
                            iterPositions = 0;
                        if ((iterSweep % 2 == 0) && (iterConex % 2 == 1))
                            iterPositions = N - 1;
                        if ((iterSweep % 2 == 1) && (iterConex % 2 == 0))
                            iterPositions = N - 1;
                        if ((iterSweep % 2 == 1) && (iterConex % 2 == 1))
                            iterPositions = 0;
                        //MessageBox.Show(iterSweep.ToString()+","+iterPositions.ToString());

                        while (iterPositions >= 0 && iterPositions < N)
                        {
                            Thread.Sleep(400);
                            if (backgroundWorker1.CancellationPending)
                                return;
                            

                            float RotPosition = positions[iterPositions];
                            int DelayVal = (int)delayMatrix[iterConex, iterPositions];
                            string text = "iteration : " + (iterSweep).ToString() + 
                                "; Conex-Pos: "+positionsConex[iterConex].ToString()+
                                ";  Rot-Pos: " + RotPosition.ToString()+
                                ";  Delay: "+ DelayVal.ToString();

                            //*********** Move Rotation Stage ******************

                            ThreadHelperClass.SetText(this, lblStageStatus, "Moving Stage to "+ RotPosition.ToString());
                            var responseTimeoutCom = TimeSpan.FromSeconds(10);
                            var responseTimeoutMov = TimeSpan.FromSeconds(120);
                            mreCom = new AutoResetEvent(false);
                            mreMov = new AutoResetEvent(false);

                            Thread.Sleep(200);
                            while (true)
                            {
                                mreCom = new AutoResetEvent(false);
                                mreMov = new AutoResetEvent(false);
                                moveAbs(RotPosition);
                                addLog("Command: moveAbs " + RotPosition.ToString() + " Sent");
                                if (!mreCom.WaitOne(responseTimeoutCom))
                                {
                                    addLog("ACK time out. ");
                                    continue;
                                }
                                if (!mreMov.WaitOne(responseTimeoutMov))
                                {
                                    addLog("Motion time out");
                                    continue;
                                }
                                Thread.Sleep(10000);

                                addLog($"currentDegVal {currentDegVal}, RotPosition Target {RotPosition}");
                                if (isWhithinError(currentDegVal, RotPosition, 1))
                                    break;
                                else
                                    addLog("Position not within Error");
                            }
                            if (backgroundWorker1.CancellationPending)
                                return;
                            // **************************************************

                            //waitIdx = 0;
                            //while (Math.Floor(currentDegVal) != Math.Floor(RotPosition)) // Wait for stage to reach
                            //{
                            //    ThreadHelperClass.SetText(this, lblStageStatus, "Moving " + waitIdx.ToString());
                            //    waitIdx = waitIdx + 1;
                            //    if (waitIdx > waitLim)
                            //    {
                            //        moveAbs((float)Math.Floor(RotPosition)); waitIdx = 0;
                            //    }
                            //    if (backgroundWorker1.CancellationPending)
                            //        return;
                            //}
                            //waitIdx = 0;
                            //*********** Send Delay ******************
                            ThreadHelperClass.SetText(this, lblStageStatus, "Sending Delay =  " + DelayVal.ToString());
                            responseTimeoutCom = TimeSpan.FromSeconds(3);
                            responseTimeoutMov = TimeSpan.FromSeconds(3);
                            Thread.Sleep(200);
                            while (true)
                            {
                                mreCom = new AutoResetEvent(false);
                                mreMov = new AutoResetEvent(false);
                                sendDelay(DelayVal);
                                if (!mreCom.WaitOne(responseTimeoutCom))
                                {
                                    continue;
                                }
                                if (!mreMov.WaitOne(responseTimeoutMov))
                                {
                                    continue;
                                }
                                Thread.Sleep(1000);
                                if (isWhithinError(currentDelay, DelayVal, 1))
                                    break;
                            }
                            // *********************************************************
                            if (backgroundWorker1.CancellationPending)
                                return;
                            //sendDelay(DelayVal);  // Send Delay
                            addLog(text);


                            //while (currentDelay != DelayVal)
                            //{
                            //    ThreadHelperClass.SetText(this, lblStageStatus, "Waiting Delay " + waitIdx.ToString());
                            //    waitIdx = waitIdx + 1;
                            //    if (waitIdx > waitLim)
                            //    {
                            //        sendDelay(DelayVal); waitIdx = 0;
                            //    }
                            //    if (backgroundWorker1.CancellationPending)
                            //        return;
                            //}
                            //waitIdx = 0;


                            // ***************** Turn on Beam *****************
                            ThreadHelperClass.SetText(this, lblStageStatus, "Turning Beam ON");
                            responseTimeoutCom = TimeSpan.FromSeconds(3);
                            responseTimeoutMov = TimeSpan.FromSeconds(3);
                            Thread.Sleep(200);
                            while (true)
                            {
                                mreCom = new AutoResetEvent(false);
                                mreMov = new AutoResetEvent(false);
                                SendbeamOn();
                                if (!mreCom.WaitOne(responseTimeoutCom))
                                {
                                    continue;
                                }
                                if (!mreMov.WaitOne(responseTimeoutMov))
                                {
                                    continue;
                                }
                                Thread.Sleep(500);
                                if (isWhithinError(currentServo, beamOn, 5))
                                    break;
                            }
                            if (backgroundWorker1.CancellationPending)
                                return;
                            //SendbeamOn();  // Turn On beam
                            //while (currentServo != beamOn)
                            //{
                            //    ThreadHelperClass.SetText(this, lblStageStatus, "Waiting Beam On " + waitIdx.ToString() + currentServo.ToString());
                            //    waitIdx = waitIdx + 1;
                            //    if (waitIdx > waitLim)
                            //    {
                            //        SendbeamOn(); waitIdx = 0;
                            //    }
                            //    if (backgroundWorker1.CancellationPending)
                            //        return;
                            //}

                            // ******************************************
                            waitIdx = 0;

                            // Acquire Data

                            // Reset the stopwatch
                            stopwatch.Reset();
                            // Begin timing
                            stopwatch.Start();
                            while (stopwatch.ElapsedMilliseconds < deltaTime)
                            {
                                Thread.Sleep(50);
                                ThreadHelperClass.SetText(this, lblStageStatus, "ACQUIRING... "+ (stopwatch.ElapsedMilliseconds/1000).ToString() + " s");
                                if (backgroundWorker1.CancellationPending)
                                    return;
                                Thread.Sleep(50);
                            }
                            // Stop timing
                            stopwatch.Stop();
                            //// Write result
                            //Console.WriteLine("Time elapsed: {0}",
                            //    stopwatch.Elapsed);

                            //ThreadHelperClass.SetText(this, lblStageStatus, "ACQUIRING...");
                            //Thread.Sleep(deltaTime);


                            // ***************** Turn OFF Beam *****************
                            ThreadHelperClass.SetText(this, lblStageStatus, "Turning Beam OFF");
                            responseTimeoutCom = TimeSpan.FromSeconds(3);
                            responseTimeoutMov = TimeSpan.FromSeconds(3);
                            Thread.Sleep(200);
                            while (true)
                            {
                                mreCom = new AutoResetEvent(false);
                                mreMov = new AutoResetEvent(false);
                                SendbeamOff();
                                if (!mreCom.WaitOne(responseTimeoutCom))
                                {
                                    continue;
                                }
                                if (!mreMov.WaitOne(responseTimeoutMov))
                                {
                                    continue;
                                }
                                Thread.Sleep(1000);
                                if (isWhithinError(currentServo, beamOff, 5))
                                    break;
                            }
                            if (backgroundWorker1.CancellationPending)
                                return;
                            //SendbeamOff();  // Turn Off beam
                            // **************************************************

                            //waitIdx = 0;
                            //while (currentServo != beamOff)
                            //{
                            //    ThreadHelperClass.SetText(this, lblStageStatus, "Waiting Beam Off " + waitIdx.ToString());
                            //    waitIdx = waitIdx + 1;
                            //    if (waitIdx > waitLim)
                            //    {
                            //        SendbeamOff(); waitIdx = 0;
                            //    }
                            //    if (backgroundWorker1.CancellationPending)
                            //        return;
                            //}


                            writeToFile(text, fileName, "a");
                            
                            //Thread.Sleep(50);
                            if ((iterSweep % 2 == 0) && (iterConex % 2 == 0)) // even
                                iterPositions = iterPositions + 1;
                            if ((iterSweep % 2 == 0) && (iterConex % 2 == 1))
                                iterPositions = iterPositions - 1;
                            if ((iterSweep % 2 == 1) && (iterConex % 2 == 0))
                                iterPositions = iterPositions - 1;
                            if ((iterSweep % 2 == 1) && (iterConex % 2 == 1))
                                iterPositions = iterPositions + 1;
                        }
                        if (iterSweep % 2 == 0) // even
                            iterConex = iterConex + 1;
                        else
                            iterConex = iterConex - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //changePanelStaus("Off");
                MessageBox.Show(ex.Message);
            }

        }

        
        void writeToFile(string txt, string fileName, string writeMode)
        {
            if (writeMode=="a")
                File.AppendAllText(fileName, txt+Environment.NewLine);
            if (writeMode == "w")
                File.WriteAllText(fileName, txt);
        }
        static float[,] ConvertMatrix(float[] flat, int m, int n)
        {
            if (flat.Length != m * n)
            {
                throw new ArgumentException("Invalid length");
            }
            float[,] ret = new float[m, n];
            // BlockCopy uses byte lengths: a double is 8 bytes
            Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * sizeof(float));
            return ret;
        }
        void addLog(string text)
        {
            text = DateTime.Now.ToShortTimeString() +"   "+ text;
            string txt;
            if (txtBxLog.Text=="")
                txt = text;
            else
                txt = txtBxLog.Text + Environment.NewLine + text;
            ThreadHelperClass.SetText(this, txtBxLog, txt);
        }
        void clearLog()
        {
            ThreadHelperClass.SetText(this, txtBxLog, "");
        }
        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //changePanelStaus("Off");
            ThreadHelperClass.SetText(this, lblexpStatus, "Completed");
        }

        private void groupBoxStage_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBxConexPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbBxConexPort_Click(object sender, EventArgs e)
        {
            cmbBxConexPort.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();

            for (int i = 0; i < portNames.Length; i++)
            {
                cmbBxConexPort.Items.Add(portNames[i]);
            }
        }

        private void btnConexConnect_Click(object sender, EventArgs e)
        {
            connectConex();
            // Home 
            String s;
            conex.OR(1, out s);
            // Start conex timer
            timerConex.Start();
        }
        void connectConex()
        {
            try {
                conex.OpenInstrument(cmbBxConexPort.Text);
                btnConexDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConexDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                conex.CloseInstrument();
                btnConexDisconnect.Enabled = false;
                timerConex.Stop();
            }
            catch(Exception ex)
            {

            }
        }

        private void timerConex_Tick(object sender, EventArgs e)
        {
            
            string errStr;
            conex.TP(1, out conexCurrentPos, out errStr);
            txtBxConexCurrentPos.Text = conexCurrentPos.ToString();
        }

        private void btnConexMoveAbs_Click(object sender, EventArgs e)
        {
            try {
                double target = float.Parse(txtBxConexMoveAbs.Text);
                conexMoveAbs(target);
            }
            catch(Exception ex)
            {

            }
        }
        void conexMoveAbs(double target)
        {
            string errStr;
            conex.PA_Set(1, target, out errStr);
        }

        private void txtBxConexMoveAbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConexMoveAbs.PerformClick();
            }
        }

        private void button1btnConexMoveRel_Click(object sender, EventArgs e)
        {
            try
            {
                double displacement = float.Parse(txtBxConexMoveRel.Text);
                conexMoveRel(displacement);
            }
            catch (Exception ex)
            {

            }
        }
        void conexMoveRel(double displacement)
        {
            string errStr;
            conex.PR_Set(1, displacement, out errStr);
        }

        private void txtBxConexMoveRel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1btnConexMoveRel.PerformClick();
            }
        }

        private void btnConexStop_Click(object sender, EventArgs e)
        {
            try {
                stopConex();
            }
            catch (Exception ex)
            {

            }
        }
        void stopConex()
        {
            string errStr;
            conex.ST(1, out errStr);
        }

        private void txtBxLog_TextChanged(object sender, EventArgs e)
        {
            //txtBxLog.SelectionStart = txtBxLog.Text.Length;
            //txtBxLog.SelectionLength = 0;
            txtBxLog.Select(); // to Set Focus
            txtBxLog.Select(txtBxLog.Text.Length, 0); //to set cursor at the end of textbox
            txtBxLog.ScrollToCaret();
        }

        private void txtBxStop_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;
            choofdlog.CheckFileExists = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                txtBxFileName.Text = sFileName;
            }
        }

        private void txtBxFileName_TextChanged(object sender, EventArgs e)
        {
            saveFileName = txtBxFileName.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtBxConexCurrentPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}