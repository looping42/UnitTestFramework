using Framework.ShortestPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTestShortestPath
    {
        [TestMethod]
        public void UnitBellmanFord()
        {
            BellmanFord newShortPath = new BellmanFord();
            newShortPath.nodes = new List<Node>();
            newShortPath.edges = new List<Edge>();
            newShortPath.posNodeStart = 0;
            for (int i = 1; i < 6; i++)
            {
                Node a = new Node();
                a.Value = i;
                newShortPath.nodes.Add(a);
            }

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[0], B = newShortPath.nodes[1], Weight = 6 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[0], B = newShortPath.nodes[3], Weight = 7 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[1], B = newShortPath.nodes[2], Weight = 5 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[1], B = newShortPath.nodes[3], Weight = 8 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[1], B = newShortPath.nodes[4], Weight = -4 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[2], B = newShortPath.nodes[1], Weight = -2 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[4], B = newShortPath.nodes[2], Weight = 7 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[4], B = newShortPath.nodes[0], Weight = 2 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[3], B = newShortPath.nodes[4], Weight = 9 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[3], B = newShortPath.nodes[2], Weight = -3 });

            newShortPath.BellmanFordWork();

            string result = "";
            for (int i = 0; i < newShortPath.nodes.Count; i++)
            {
                result += newShortPath.nodes[i].Value;
                bool ok = true;
                while (ok)
                {
                    if (newShortPath.nodes[i].parent != null)
                    {
                        result += newShortPath.nodes[i].parent.Value;
                        newShortPath.nodes[i] = newShortPath.nodes[i].parent;
                    }
                    else
                    {
                        ok = false;
                    }
                }
            }
            Assert.AreEqual("0247047070-22470", result);
        }

        [TestMethod]
        public void UnitDjiskra()
        {
            Dijkstra newShortPath = new Dijkstra();
            newShortPath.nodes = new List<Node>();
            newShortPath.edges = new List<Edge>();
            newShortPath.posNodeStart = 0;
            for (int i = 1; i < 6; i++)
            {
                Node a = new Node();
                a.Value = i;
                newShortPath.nodes.Add(a);
            }

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[0], B = newShortPath.nodes[1], Weight = 10 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[0], B = newShortPath.nodes[3], Weight = 5 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[1], B = newShortPath.nodes[2], Weight = 1 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[1], B = newShortPath.nodes[3], Weight = 2 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[2], B = newShortPath.nodes[4], Weight = 4 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[3], B = newShortPath.nodes[1], Weight = 3 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[3], B = newShortPath.nodes[2], Weight = 9 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[3], B = newShortPath.nodes[4], Weight = 2 });

            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[4], B = newShortPath.nodes[2], Weight = 6 });
            newShortPath.edges.Add(new Edge() { A = newShortPath.nodes[4], B = newShortPath.nodes[0], Weight = 7 });

            newShortPath.DijkstraWork();

            string result = "";
            for (int i = 0; i < newShortPath.nodes.Count; i++)
            {
                result += newShortPath.nodes[i].Value;
                bool ok = true;
                while (ok)
                {
                    if (newShortPath.nodes[i].parent != null)
                    {
                        result += newShortPath.nodes[i].parent.Value;
                        newShortPath.nodes[i] = newShortPath.nodes[i].parent;
                    }
                    else
                    {
                        ok = false;
                    }
                }
            }
            Assert.AreEqual("0247047070-22470", result);
            //foreach (Node node in newShortPath.nodes)
            //{
            //    Console.WriteLine("Node value : " + node.Value);
            //    Console.WriteLine("Node parent : " + node.parent);
            //}
            Console.ReadLine();
        }
    }
}