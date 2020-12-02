using System;
using System.Windows.Forms;
using NationalInstruments.ModularInstruments.NIRfsg;
using NationalInstruments.RFmx.InstrMX;
using NationalInstruments.ModularInstruments.SystemServices.DeviceServices;
using System.Collections.Generic;
using NationalInstruments;

namespace L2CapstoneProject
{

    public partial class frmBeamformerPavtController : Form
    {
        NIRfsg _rfsgSession;
        RFmxInstrMX instr;
        List<PhaseAmplitudeOffset> offsets;

        public frmBeamformerPavtController()
        {
            InitializeComponent();
            LoadDeviceNames();
            offsets = new List<PhaseAmplitudeOffset>();
        }

        private void LoadDeviceNames()
        {
            ModularInstrumentsSystem rfsgSystem = new ModularInstrumentsSystem("NI-Rfsg");
            foreach (DeviceInfo device in rfsgSystem.DeviceCollection)
                rfsgNameComboBox.Items.Add(device.Name);
            if (rfsgSystem.DeviceCollection.Count > 0)
                rfsgNameComboBox.SelectedIndex = 0;

            ModularInstrumentsSystem rfmxSystem = new ModularInstrumentsSystem("NI-Rfsa");
            foreach (DeviceInfo device in rfmxSystem.DeviceCollection)
                rfsaNameComboBox.Items.Add(device.Name);
            if (rfsgSystem.DeviceCollection.Count > 0)
                rfsaNameComboBox.SelectedIndex = 0;
        }
        #region UI Events
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGeneration();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AbortGeneration();
        }
        
        private void btnAddOffset_Click(object sender, EventArgs e)
        {
            AddOffset();
        }
        private void EditListViewItem(object sender, EventArgs e)
        {
            if (CheckSelection(out int selected))
            {
                EditOffset(selected);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckSelection(out int selected))
            {
                RemoveOffset(selected);
            }
        }
        private void lsvOffsets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckSelection(out int _))
            {
                btnDeleteOffset.Enabled = btnEditOffset.Enabled = true;
            }
            else
            {
                btnDeleteOffset.Enabled = btnEditOffset.Enabled = false;
            }
        }
        private void lsvOffsets_KeyDown(object sender, KeyEventArgs e)
        {
            if (CheckSelection(out int selected))
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        EditOffset(selected);
                        break;
                    case Keys.Delete:
                        RemoveOffset(selected);
                        break;
                }
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TestSteppedBeamformer();
        }

        private void frmBeamformerPavtController_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseInstruments();
        }

        #endregion
        #region Program Functions


        private void TestSteppedBeamformer()
        {
            var beamformer = new SimulatedSteppedBeamformer();
            beamformer.Connect();
            foreach (var offset in offsets)
            {
                beamformer.LoadOffset(offset);
                //measure
                var result = MessageBox.Show($"Measure\n\nExpected Result:\nPhase: {offset.Phase}\nAmplitude: {offset.Amplitude}");

            }
            beamformer.Disconnect();
        }

        private void TestSequencedBeamformer()
        {
            var beamformer = new SimulatedSequencedBeamformer((double)((measurementLengthNumeric.Value + measurementOffsetNumeric.Value)/(decimal)1E6));
            beamformer.Connect();
            beamformer.LoadSequence("sequence1");
            //begin measurement
            beamformer.InitiateSequence("sequence1");
            beamformer.Disconnect();
        }

        void startMeasurements()
        {
            int numSteps = offsets.Count;
            double[] amplitudes = new double[numSteps];
            double[] phases = new double[numSteps];
            Tuple<double[], double[]> measurements;
            decimal amp;
            decimal phase;

            try
            {
                PAVTMeasurement pavtMeasure = new PAVTMeasurement(rfsaNameComboBox.Text);
                pavtMeasure.configureMeasurements(numSteps, (double)frequencyNumeric.Value, (double)powerLevelNumeric.Value, (double)measurementOffsetNumeric.Value, (double)measurementLengthNumeric.Value);

                foreach (var offset in offsets)
                {
                    measurements = pavtMeasure.GetMeasurements();
                    phase = Convert.ToDecimal(measurements.Item1);
                    amp = Convert.ToDecimal(measurements.Item2);
                    PhaseAmplitudeOffset newValues = new PhaseAmplitudeOffset(phase, amp);
                    lsvResults.Items.Add(CreateListViewItem(newValues)); // add results to results listview
                }
            }
            catch (Exception ex)
            {
                ShowError("startMeasurements()", ex);
            }
        }
        
       
        void StartGeneration()
        {
            //bool isMeasurementComplete = false; 

            try
            {
                
                SimulatedSteppedBeamformer simulatedSteppedBF = new SimulatedSteppedBeamformer(rfsgNameComboBox.Text, (double)frequencyNumeric.Value, (double)powerLevelNumeric.Value);
                simulatedSteppedBF.Connect();

                for(int i = 0; i < offsets.Count; i++)
                {
                    simulatedSteppedBF.LoadOffset(offsets[i]); // set phase offset and power level
                    ComplexWaveform<ComplexDouble> IQData = simulatedSteppedBF.createWaveform(offsets); //creates complex waveform data
                    simulatedSteppedBF.writeWaveform(IQData); //generate waveform
                    this.startMeasurements(); //take measurements
                    simulatedSteppedBF.Disconnect();
                }
                
                
            }
            catch(Exception ex)
            {
                ShowError("StartGeneration()", ex);
            }
        }

        //Function to create the waveform data to be generated
        /*
        ComplexWaveform<ComplexDouble> createWaveform(int numSamples)
        {
            //public static ComplexWaveform<TData> FromArray1D(TData[] array);
            ComplexWaveform<ComplexDouble> complexWaveform;
            ComplexDouble[] IQData = new ComplexDouble[numSamples];

            //IQData[0] = ComplexDouble.FromPolar((double)offsets[0].Amplitude, (double)offsets[0].Phase);
            for(int i = 0; i < numSamples; i++)
            {
                IQData[i] = ComplexDouble.FromPolar((double)offsets[i].Amplitude, (double)offsets[i].Phase);
            }

            complexWaveform = ComplexWaveform<ComplexDouble>.FromArray1D(IQData);

            return complexWaveform;
        }
        */

        //CW: numSamples = 100, amp = 1, phaseDegrees = 0, numCycles = 1
        static double[] sinePattern(int numSamples, double amplitude, double phaseDegrees, double numCycles)
        {
            double[] sineArray = new double[numSamples];
            for(int i = 0; i < numSamples; i++)
            {
                sineArray[i] = amplitude * Math.Sin(2 * Math.PI * i * numCycles / numSamples + Math.PI * phaseDegrees / 180); //m(t) = Asin(2*pi*f*t + theta)
            }
            return sineArray;
        }

        void DriverOperation_Warning(object sender, RfsgWarningEventArgs e)
        {
            errorTextBox.Text = e.Message;
        }
        

        private void AbortGeneration()
        {
            SetButtonState(false);

            if (_rfsgSession?.IsDisposed == false)
            {
                _rfsgSession.Abort();
            }
        }
        private void CloseInstruments()
        {
            AbortGeneration();
            _rfsgSession?.Close();

            instr?.Close();
        }
        private void SetButtonState(bool started)
        {
            btnStart.Enabled = !started;
            btnStop.Enabled = started;
        }
        void ShowError(string functionName, Exception exception)
        {
            AbortGeneration();
            errorTextBox.Text = "Error in " + functionName + ": " + exception.Message;
        }
        void SetStatus(string statusMessage)
        {
            errorTextBox.Text = statusMessage;
        }
        #endregion
        #region Offset Functions
        private void AddOffset()
        {
            frmOffset dialog = new frmOffset(frmOffset.Mode.Add);
            DialogResult r = dialog.ShowDialog();

            if (r == DialogResult.OK)
            {
                // Add the offset to the listview (lsvOffsets)

                // Create new variable to hold phase and amplitude values
                PhaseAmplitudeOffset newOffset = new PhaseAmplitudeOffset
                {
                    Phase = dialog.GetPhase(),
                    Amplitude = dialog.GetAmp()
                };

                offsets.Add(newOffset); //List<PhaseAmplitudeOffset> offset

                // create new listview item to store phase/amp values and add to list
                
                lsvOffsets.Items.Add(CreateListViewItem(newOffset));
                
            }
        }

        private ListViewItem CreateListViewItem(PhaseAmplitudeOffset newValue)
        {
            string[] itemText = new string[2];
            itemText[0] = newValue.Phase.ToString();
            itemText[1] = newValue.Amplitude.ToString();
            return new ListViewItem(itemText);
        }

        private void EditOffset(int selected)
        {
            // Will need to pass in the currently selected item
            frmOffset dialog = new frmOffset(frmOffset.Mode.Edit);
            dialog.SetAmp(offsets[selected].Amplitude);
            dialog.SetPhase(offsets[selected].Phase);
            DialogResult r = dialog.ShowDialog();

            if (r == DialogResult.OK)
            {
                var newPhase = dialog.GetPhase();
                var newAmp = dialog.GetAmp();
                offsets[selected].Phase = newPhase;
                offsets[selected].Amplitude = newAmp;


                lsvOffsets.Items[selected] = CreateListViewItem(offsets[selected]); //grabs selected items from offsets list, stores in listviewitem, adds to listview
            }
        }

        ///
        private void RemoveOffset(int selected)
        {
            lsvOffsets.Items.RemoveAt(selected);
            offsets.Remove(offsets[selected]);
        }
        #endregion
        #region Utility Functions

        /// <summary>
        /// Validates that the listview has at least one value selected. Optionally returns the selected index.
        /// </summary>
        /// <param name="selectedIndex">Current selected index in the list view.</param>
        /// <returns></returns>
        private bool CheckSelection(out int selectedIndex)
        {
            if (lsvOffsets.SelectedItems.Count == 1)
            {
                selectedIndex = lsvOffsets.SelectedIndices[0];
                return true;
            }
            else
            {
                selectedIndex = -1;
                return false;
            }
        }

        #endregion

    
    }
}