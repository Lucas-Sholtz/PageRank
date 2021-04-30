using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace NicolasPage
{
    class Vertex
    {
        public int n;
        public List<int> incidents;
        public Vertex()
        {
            incidents = new List<int>();
        }
    }
    class Graph
    {
        public List<Vertex> vertexes;
        public Graph()
        {
            vertexes = new List<Vertex>();
        }
        public Matrix<double> CreateTransitionMatrix()
        {
            var m = Matrix<double>.Build.Dense(vertexes.Count, vertexes.Count, 0.0);

            foreach(var vertex in vertexes)
            {
                var j = vertex.n;
                double value = CalculateCellValue(j);
                foreach(var i in vertex.incidents)
                {
                    m[i, j] = value;
                }
            }

            return m;
        }
        public double CalculateCellValue(int id)
        {
            int count = 0;

            foreach(var v in vertexes)
            {
                if (v.n == id)
                    count = v.incidents.Count;
            }

            if (count == 0)
            {
                return 0.0;
            }
            else
            {
                return 1.0 / count;
            }
        }
    }
}
