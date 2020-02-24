using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BusinessLogicLayer
{
    public interface IAggregateCollection<T>
    {
        IIterator<T> GetIterator();
    }
}
