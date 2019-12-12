using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
    class Clusters
    {
        public void generateClusters(List<KeyValuePair<KeyValuePair<int, int>, double>> edges, ref int[,] resClusters, int length)
        {
            edges = edges.OrderBy(x => x.Value).ToList();
        }

        public void result(int[] clusters, int length, List<RGBPixel>colors)
        {
            RGBPixelD[] newColors = new RGBPixelD[length + 1];
            double[] numofColor = new double[length + 1];

            for (int i = 0; i < length + 1; i++)
            {
                if (clusters[i] == 0) {
                    clusters[i] = i;
                }
                newColors[clusters[i]].blue += colors[i].blue;
                newColors[clusters[i]].green += colors[i].green;
                newColors[clusters[i]].red += colors[i].red;
                numofColor[clusters[i]]++;
            }
            for (int i=0; i<length+1; i++) {
                newColors[i].red /= numofColor[i];
                newColors[i].green /= numofColor[i];
                newColors[i].blue /= numofColor[i];

            }

        }
    }
}
