using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2CapstoneProject
{
    class PhaseAmplitudeOffset
    {

        public PhaseAmplitudeOffset() { }

        public PhaseAmplitudeOffset(decimal phase, decimal amplitude)
        {
            Phase = phase;
            Amplitude = amplitude;
        }
        // auto implemented properties
        public decimal Phase { get; set; }
        public decimal Amplitude { get; set; }
    }
}
