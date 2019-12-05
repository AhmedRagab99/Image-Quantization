using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{


    class MST
    {
        DSU dsu;

        public MST()
        {
            dsu = new DSU();
            dsu.init();

        }
        public List<KeyValuePair<KeyValuePair<int, int>, int>> ComputeMSTPath(List<KeyValuePair<KeyValuePair<int, int>, int>> edges, List<KeyValuePair<KeyValuePair<int, int>, int>> res)
        {

            edges = edges.OrderBy(x => x.Value).ToList();


            int treeSum = 0;

            for (int i = 0; i < edges.Count(); i++)
            {
                KeyValuePair<int, int> r = new KeyValuePair<int, int>(edges[i].Key.Key, edges[i].Key.Value);
                KeyValuePair<KeyValuePair<int, int>, int> r1 = new KeyValuePair<KeyValuePair<int, int>, int>(r, edges[i].Value);

                if (dsu.FindParent(edges[i].Key.Key) != dsu.FindParent(edges[i].Key.Value))
                {
                    res.Add(r1);
                    dsu.connect(edges[i].Key.Key, edges[i].Key.Value);
                    treeSum += edges[i].Value;
                }

            }
            return res;
        }

        public void printMST(List<KeyValuePair<KeyValuePair<int, int>, int>> resultMsT)
        {

            for (int i = 0; i < resultMsT.Count(); i++)
            {
                Console.WriteLine(resultMsT[i].Key.Key);
                Console.WriteLine(resultMsT[i].Key.Value);
                Console.WriteLine(resultMsT[i].Value);
            }
        }



    }
}
