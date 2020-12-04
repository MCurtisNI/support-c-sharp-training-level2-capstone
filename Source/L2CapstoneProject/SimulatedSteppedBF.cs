using NationalInstruments.ModularInstruments.NIRfsg;
using NationalInstruments;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2CapstoneProject
{
    class SimulatedSteppedBeamformer : ISteppedBeamformer
    {
        NIRfsg _rfsgSession;
        string resourceName;
        double frequency, power, frequencyOffset, actualIQRate;
        int numSamples = 100; //use waveform quantum to find num samples instead?

        public SimulatedSteppedBeamformer(NIRfsg Session, double Freq, double Power)
        {
            _rfsgSession = Session;
            frequency = Freq;
            power = Power;
        }

        public void Connect()
        {
            //string resourceName;
            //double frequency, frequencyOffset, power, actualIQRate;
            //decimal phase, phaseOffset, amplitude, amplitudeOffset;
            //double[] iData, qData;
            //double frequencyOffset, actualIQRate;
            //int numSamples = 100; //use waveform quantum to find num samples instead?

            ComplexWaveform<ComplexDouble> IQData = new ComplexWaveform<ComplexDouble>(numSamples);
            List<PhaseAmplitudeOffset> offsets = new List<PhaseAmplitudeOffset>();

            try
            {

                //initialize rfsg session
                //subscribe to rfsg warnings
                _rfsgSession.DriverOperation.Warning += new EventHandler<RfsgWarningEventArgs>(DriverOperation_Warning);

                //configure generator
                _rfsgSession.RF.Configure(frequency, power);
                _rfsgSession.Arb.GenerationMode = RfsgWaveformGenerationMode.ContinuousWave;
                _rfsgSession.Arb.IQRate = 50e6;
                actualIQRate = _rfsgSession.Arb.IQRate;
                frequencyOffset = actualIQRate / numSamples;
                _rfsgSession.Arb.SignalBandwidth = 2 * frequencyOffset;

                //stimulate w/ CW
                stimulateDUTwithCW(numSamples);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Connect()\n" + ex.Message);
            }
        }

        public void Disconnect()
        {
            _rfsgSession.Abort();
            
        }

        public void LoadOffset(PhaseAmplitudeOffset offset)
        {
            //get phase and amplitude
            _rfsgSession.RF.PhaseOffset = (double)offset.Phase;
            _rfsgSession.RF.PowerLevel = power + (double)offset.Amplitude;
        }

        void DriverOperation_Warning(object sender, RfsgWarningEventArgs e)
        {
            //errorTextBox.Text = e.Message;
            MessageBox.Show(e.Message);
        }

        static double[] sinePattern(int numSamples, double amplitude, double phaseDegrees, double numCycles)
        {
            double[] sineArray = new double[numSamples];
            for (int i = 0; i < numSamples; i++)
            {
                sineArray[i] = amplitude * Math.Sin(2 * Math.PI * i * numCycles / numSamples + Math.PI * phaseDegrees / 180); //m(t) = Asin(2*pi*f*t + theta)
            }
            return sineArray;
        }

        public ComplexWaveform<ComplexDouble> createWaveform(List<PhaseAmplitudeOffset> offsets)
        {
            ComplexWaveform<ComplexDouble> complexWaveform;
            ComplexDouble[] IQData = new ComplexDouble[offsets.Count];

            for (int i = 0; i < offsets.Count; i++)
            {
                IQData[i] = ComplexDouble.FromPolar((double)offsets[i].Amplitude, (double)offsets[i].Phase);
            }

            complexWaveform = ComplexWaveform<ComplexDouble>.FromArray1D(IQData);

            return complexWaveform;
        }

        void stimulateDUTwithCW(int numSamples)
        {
            //  double[] iData, qData;
            //  iData = new double[numSamples];
            //  qData = new double[numSamples]; 
            //   iData = sinePattern(numSamples, 1.0, 0.0, 1.0);
            //  qData = sinePattern(numSamples, 1.0, 0.0, 1.0);

            //generate a cw to stimulate dut 
            //  _rfsgSession.Arb.WriteWaveform("", iData, qData);
            _rfsgSession.RF.Configure(frequency, power);
            _rfsgSession.Initiate();
            //System.Threading.Thread.Sleep(100);
           // _rfsgSession.Abort();

        }

        public void writeWaveform(ComplexWaveform<ComplexDouble> IQdata) //input is complex waveform that was created using createWaveform(offsets);
        {
            //rest of code to write offsets
            ComplexWaveform<ComplexDouble> NewIQData = new ComplexWaveform<ComplexDouble>(numSamples);
            //List<PhaseAmplitudeOffset> offsetList = new List<PhaseAmplitudeOffset>();

            PrecisionTimeSpan dt = PrecisionTimeSpan.FromSeconds(1 / actualIQRate);
            IQdata.PrecisionTiming = PrecisionWaveformTiming.CreateWithRegularInterval(dt);
            _rfsgSession.Arb.WriteWaveform("", IQdata);
            _rfsgSession.Initiate();

            //ComplexWaveform<ComplexDouble> IQdata

        }

    }
}
