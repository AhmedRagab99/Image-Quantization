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

        private void Merge(List<KeyValuePair<KeyValuePair<int, int>, double>> input, int left, int middle, int right)
        {
            KeyValuePair<KeyValuePair<int, int>, double>[] leftArraytmp = new KeyValuePair<KeyValuePair<int, int>, double>[middle - left + 1];
            KeyValuePair<KeyValuePair<int, int>, double>[] rightArraytmp = new KeyValuePair<KeyValuePair<int, int>, double>[right - middle];
            
            input.CopyTo(left, leftArraytmp, 0, middle - left + 1);
            input.CopyTo(middle + 1, rightArraytmp, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArraytmp.Length)
                {
                    input[k] = rightArraytmp[j];
                    j++;
                }
                else if (j == rightArraytmp.Length)
                {
                    input[k] = leftArraytmp[i];
                    i++;
                }
                else if (leftArraytmp[i].Value <= rightArraytmp[j].Value)
                {
                    input[k] = leftArraytmp[i];
                    i++;
                }
                else
                {
                    input[k] = rightArraytmp[j];
                    j++;
                }
            }
        }

        private void MergeSort(List<KeyValuePair<KeyValuePair<int, int>, double>> input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }

        public double ComputeMSTPath(List<KeyValuePair<KeyValuePair<int, int>, double>> edges, ref List<KeyValuePair<KeyValuePair<int, int>, double>> res)
        {

            MergeSort(edges, 0, edges.Count - 1);
            //edges = edges.OrderBy(x => x.Value).ToList();
            double treeSum = 0;
            for (int i = 0; i < edges.Count(); i++)
            {
                KeyValuePair<int, int> r = new KeyValuePair<int, int>(edges[i].Key.Key, edges[i].Key.Value);
                KeyValuePair<KeyValuePair<int, int>, double> r1 = new KeyValuePair<KeyValuePair<int, int>, double>(r, edges[i].Value);

                if (dsu.FindParent(edges[i].Key.Key) != dsu.FindParent(edges[i].Key.Value))
                {
                    res.Add(r1);
                    dsu.connect(edges[i].Key.Key, edges[i].Key.Value);
                    treeSum += edges[i].Value;
                }

            }

            return treeSum;
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
