using Symulator1.Models;
using Symulator1.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator1
{
    class HddController
    {
        int procAmount;
        List<HDDRequest> list;
        Dictionary<string,RngControl> rngControls;


        public int ProcAmount { get => procAmount; set => procAmount = value; }

        public HddController(Dictionary<string, RngControl> rng_dict,int proc)
        {
            procAmount = proc;
            rngControls = rng_dict;
        }
        public void populateRandom()
        {
            list = new List<HDDRequest>();
            var cylinders = rngControls["cylinder"].AdvancedRandom(procAmount);
            var entry = rngControls["entry"].AdvancedRandom(procAmount);
            for (int i = 0; i < procAmount; i++)
            {
                HDDRequest temp = new HDDRequest(i, cylinders[i], entry[i]);
                list.Add(temp);
            }

        }
        public List<HDDResult> evaluateAlgorithm(HddAlg[] algs)
        {
            List < HDDResult > results = new List<HDDResult>();
            foreach (var item in algs)
            {
                item.List = copylist(list);
                results.Add(new HDDResult(item.evaluate(),item.Name));
            }
            return results;
        }
        internal class HDDResult
        {
            int value;
            string name;

            public HDDResult(int value, string name)
            {
                this.value = value;
                this.name = name;
            }

            public int Value { get => value; set => this.value = value; }
            public string Name { get => name; set => name = value; }
        }
        List<HDDRequest> copylist(List<HDDRequest> copy)
        {
            list = new List<HDDRequest>();
            if (copy == null) return null;
            foreach (var item in copy)
            {
                list.Add(item);
            }
            return list;
        }
        
    }
}
