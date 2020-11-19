using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2CapstoneProject
{
    interface IBeamformer
    {
        void Connect();

        void Disconnect();
    }

    interface ISequencedBeamformer : IBeamformer
    {
        void LoadSequence(string sequenceName);

        void LoadSequence(string sequenceName, List<PhaseAmplitudeOffset> offsets);

        void InitiateSequence(string sequenceName);

        void AbortSequence();
    }

    interface ISteppedBeamformer : IBeamformer
    {
        void LoadOffset(PhaseAmplitudeOffset offset);
    }

}

