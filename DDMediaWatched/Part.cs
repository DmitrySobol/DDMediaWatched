using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMediaWatched
{
    public class Part
    {
        private string
            name;//Name of part (Season, Film ...)

        private int
            width,//Resolution width
            height;//Resolution height

        private long
            sizeD;//Size on disk in bytes

        private string
            path;//Path to part

        private bool
            isPathFile;//Is path file? Else directory

        private List<Series>
            series;//Series
    }
}
