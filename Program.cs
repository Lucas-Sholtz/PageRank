using System;
using MathNet.Numerics.LinearAlgebra;

namespace NicolasPage
{
    class Program
    {
        static double VectorNorm(Vector<double> v)
        {
            double sum = 0;
            for(int i = 0; i < v.Count; i++)
            {
                sum += Math.Pow(v[i], 2);
            }
            return Math.Sqrt(sum);
        }
        static void Main(string[] args)
        {
            var eps = 0.00001;
            GraphReader gr = new GraphReader();
            var graph = gr.ReadGraphFromTable();

            var m = graph.CreateTransitionMatrix();
            Console.WriteLine(m);

            var bk = Vector<double>.Build.Dense(graph.vertexes.Count);
            for(int i=0;i<bk.Count;i++)
            {
                bk[i] = 1.0 / graph.vertexes.Count;
                //bk[i] = 1.0;
            }
            Console.WriteLine(bk);
            var bkp1 = m*bk;
            Console.WriteLine(bkp1);
            var norm = VectorNorm(bk);
            Console.WriteLine(norm);
            bkp1 = bkp1 / norm;
            Console.WriteLine(bkp1);
            Console.WriteLine();
            while (Math.Abs(VectorNorm(bk - bkp1)) > eps)
            {
                Console.ReadKey();
                Console.WriteLine(bkp1);
                bk = bkp1;
                bkp1 = m*bk;
                bkp1 = bkp1 / VectorNorm(bk);
            }

            Console.WriteLine(bkp1);

            var oneVector = Vector<double>.Build.Random(graph.vertexes.Count);
            for(int i = 0; i < oneVector.Count;i++)
            {
                oneVector[i] = 1.0;
            }
            var bsharp = 0.85 * m * bkp1 + (1 - 0.85) * oneVector / graph.vertexes.Count;

            Console.WriteLine(bsharp);
        }
    }
}
