using Symulator1.Models.Comparators;
using Symulator1.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator1.Models.HDDscheduling
{
    class FDSCAN : HddAlg
    {
        public FDSCAN(string name, int maxlen) : base(name, maxlen)
        {
        }
        public override int evaluate()
        {
            return AdvEvaluate(delegate (HddAlg alg, List<HDDRequest> queue)
            {
                List<HDDRequest> prioritylist = new List<HDDRequest>();
                prioritylist.AddRange(List.FindAll(e => e.Realtime && e.EntryTime == CurrentTime));
                queue.Sort(new HddEntryComparator());
                


            });
            return base.evaluate();
        }
    }
}
