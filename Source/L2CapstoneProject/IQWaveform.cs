using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2CapstoneProject
{
    class IQWaveform
    {
        public IQWaveform(double[] iData, double[] qData)
        {
            IData = iData;
            QData = qData;
        }

        public double[] IData { get; set; }
        public double[] QData { get; set; }
    }
}
