﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.RFmx.InstrMX;
using NationalInstruments.RFmx.SpecAnMX;

namespace L2CapstoneProject
{
    public class PAVTMeasurement
    {
        RFmxInstrMX instrSession;
        RFmxSpecAnMX specAn;
        double timeout;
        int numSteps;
        
        public PAVTMeasurement(RFmxInstrMX session)
        {
            instrSession = session;
            specAn = instrSession.GetSpecAnSignalConfiguration();
            specAn.SelectMeasurements("", RFmxSpecAnMXMeasurementTypes.Pavt, true);
            specAn.Pavt.Configuration.ConfigureMeasurementLocationType("", RFmxSpecAnMXPavtMeasurementLocationType.Trigger);

        }

        //configure measurement settings
        public void StartMeasurement(int numberOfSteps, double centerFrequency, double referenceLevel, double measurementOffsetTime, double measurementTime)
        {
            numSteps = numberOfSteps;
            specAn.ConfigureRF("", centerFrequency, referenceLevel, 1.0);
            specAn.Pavt.Configuration.ConfigureNumberOfSegments("", numSteps);
            specAn.Pavt.Configuration.ConfigureMeasurementBandwidth("", 1E3);
            specAn.Pavt.Configuration.ConfigureMeasurementInterval("", measurementOffsetTime, measurementTime);
            timeout = ((double)numSteps * (measurementOffsetTime + measurementTime)) + 1.0;
            specAn.Initiate("", "r1");
        }

        public Tuple<double[], double[]> GetMeasurements()
        {
            double[] relativePhases = new double[numSteps];
            double[] relativeAmplitudes = new double[numSteps];
            double relativePhase = new double();
            double relativeAmplitude = new double();
            double meanAbsolutePhase = new double();
            double meanAbsoluteAmplitude = new double();

            for(var i=0; i<numSteps; i++)
            {
                specAn.Pavt.Results.FetchPhaseAndAmplitude($"segment({i})", timeout, out relativePhase, out relativeAmplitude, out meanAbsolutePhase, out meanAbsoluteAmplitude);
                relativePhases[i] = relativePhase;
                relativeAmplitudes[i] = relativeAmplitude;
            }

            return new Tuple<double[], double[]>(relativePhases, relativeAmplitudes);
            
        }

        /*
        public void Connect()
        {

        }

        public void Disconnect()
        {

        }
        beamformer.sendtrigger;
            offset
            trigger
            ...
        */
        
    }
}
