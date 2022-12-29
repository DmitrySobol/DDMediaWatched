using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMediaWatched
{
    public class Franchise
    {
        enum FranchiseType {A, C, F};

        private string
            name;

        private string[]
            otherNames;

        private List<Part>
            parts;

        private string
            path;

        private FranchiseType
            type;
    }
}
