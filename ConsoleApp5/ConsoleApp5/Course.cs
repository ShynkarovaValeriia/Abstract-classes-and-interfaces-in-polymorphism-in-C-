using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public abstract class Course
    {
        public string Title { get; set; }

        public string Instructor { get; set; }

        public int Duration { get; set; }

        public abstract void DisplayInfo();
    }

    // Інтерфейси для специфічних дій
    public interface IWatchable
    {
        void Watch();
    }

    public interface IReadable
    {
        void Read();
    }
}
