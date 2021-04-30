using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NicolasPage
{
    class GraphReader
    {
        const string path = "C:\\Users\\miste\\source\\repos\\NicolasPage\\Graph.table";
        public Graph ReadGraphFromTable()
        {
            Graph graph = new Graph();
            StreamReader file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var nums = line.Split(' ');
                Vertex v = new Vertex();
                v.n = int.Parse(nums[0]);
                for (int i = 1; i < nums.Length; i++)
                {
                    v.incidents.Add(int.Parse(nums[i]));
                }
                graph.vertexes.Add(v);
            }
            return graph;
        }
    }
}
