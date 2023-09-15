using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


        int currentDegVal;
        private void Form1_Load(object sender, EventArgs e)
        {
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
            txtBxStart.Text = "10";
            txtBxStop.Text = "20";
            txtBxNumber.Text = "2";
            txtBxIterations.Text = "1";
            txtBxACQseconds.Text = "10";

            //MessageBox.Show((2 % 2).ToString());
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
            int val;
            int.TryParse(data, out val);
            int valDeg = val/stepsPerDegree;

            ThreadHelperClass.SetText(this, txtBxCurrentPos, valDeg.ToString());
            currentDegVal = valDeg;
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

        public void moveRelative(int moveRelDeg)
        {
            //MessageBox.Show("Received Rel");

            //int steps = moveRelDeg * stepsPerDegree;
            //comboSerial1.com.DiscardInBuffer();
            //comboSerial1.com.DiscardInBuffer();

            //comboSerial1.sendSerial("r"+steps.ToString());
            //ThreadHelperClass.SetText(this, lblexpStatus, "Moved " + steps.ToString() + " steps");

            int target=currentDegVal + moveRelDeg;
            moveAbs(target);
        }

        private void btnMoveAbs_Click(object sender, EventArgs e)
        {
            try
            {
                int targetDeg = int.Parse(txtBxmoveAbs.Text);
                moveAbs(targetDeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void moveAbs(int targetDeg)
        {
            int steps = targetDeg * stepsPerDegree;
            comboSerial1.com.DiscardInBuffer();
            comboSerial1.com.DiscardInBuffer();

            comboSerial1.sendSerial("r" + steps.ToString());
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
                int relDeg = int.Parse(txtBxMoveRel.Text);
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
            float interval = (endval / Math.Abs(endval)) * Math.Abs(endval - startval) / (steps - 1);
            return (from val in Enumerable.Range(0, steps)
                    select startval + (val * interval)).ToArray();
        }

        private void btnStopExp_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                //changePanelStaus("On");
                int startDeg = int.Parse(txtBxStart.Text);
                int stopDeg = int.Parse(txtBxStop.Text);
                int N= int.Parse(txtBxNumber.Text);
                int iterations= int.Parse(txtBxIterations.Text);
                int ACQTime = int.Parse(txtBxACQseconds.Text);

                float [] positions=linspace(startDeg, stopDeg, N);
                float [] delays= linspace(0, 255, N);

                int deltaTime = ACQTime / (N * iterations) * 1000; // in milliseconds
                int iterPositions = 0;
                for (int iterSweep = 0; iterSweep < iterations; iterSweep++)
                {
                    ThreadHelperClass.SetText(this, lblSweepNum, (iterSweep + 1).ToString());
                    if (iterSweep % 2 == 0) // even
                        iterPositions = 0;
                    else
                        iterPositions = N - 1;
                    //MessageBox.Show(iterSweep.ToString()+","+iterPositions.ToString());
                    while (iterPositions>=0 && iterPositions < N)
                    {
                        
                        int position = (int)(Math.Round(positions[iterPositions]));
                        ThreadHelperClass.SetText(this, lblPositionNumber, (position).ToString());
                        Thread.Sleep(1000);
                        //int relPos = position - currentDegVal;
                        //comboSerial1.sendSerial("r"+ relPos.ToString()); Thread.Sleep(1000);
                        moveAbs(position);
                        int waitIdx = 0;
                        while (currentDegVal != position) // Wait for stage to reach
                        {
                            //if (comboSerial1.com)
                            //if (waitIdx > 10000)
                            //{
                            //    moveAbs(position);
                            //    waitIdx = 0;
                            //}
                            ThreadHelperClass.SetText(this, lblStageStatus, "Moving " + waitIdx.ToString());
                            waitIdx = waitIdx+1;
                            if (waitIdx>10000)
                            {
                                moveAbs(position); waitIdx = 0;
                            }
                            if (backgroundWorker1.CancellationPending)
                                return;
                        }
                        // Do your thing
                        // move servo To on Position
                        int delay= (int)(Math.Round(delays[iterPositions]));
                        sendDelay(delay);
                        Thread.Sleep(1000);
                        SendbeamOn();
                        Thread.Sleep(deltaTime);
                        SendbeamOff();

                        if (iterSweep%2 ==0) // even
                            iterPositions = iterPositions + 1;
                        else
                            iterPositions = iterPositions -1;
                        
                    }
                }
            }
            catch(Exception ex)
            {
                //changePanelStaus("Off");
                MessageBox.Show(ex.Message);
            }
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //changePanelStaus("Off");
        }
    }
}
