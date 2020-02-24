using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer
{
    public interface IIterator<T>
    {
        T First();

        T Next();

        bool IsDone { get; }

        T Current { get; }
    }
}
