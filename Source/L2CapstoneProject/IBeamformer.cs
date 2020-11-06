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

    interface ISequencedBeamformer: IBeamformer
    {
        void LoadSequence();

        void InitiateSequence();

        void AbortSequence();
    }

    interface IDynamicBeamformer: IBeamformer
    {
        void LoadOffset(PhaseAmplitudeOffset offset);
    }

    interface IDynamicSequencedBeamformer : ISequencedBeamformer, IDynamicBeamformer { }
}
