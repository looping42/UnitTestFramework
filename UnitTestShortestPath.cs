﻿using Framework.ShortestPath;
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

            string result = "";
            bool okNoCyleNeg = newShortPath.BellmanFordWork();
            if (okNoCyleNeg)
            {
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
            Assert.AreEqual("085098505070", result);
        }

        [TestMethod]
        public void UnitFloydWarshall()
        {
            FloydWarshall newFloyd = new FloydWarshall();
            newFloyd.MaxValue = 9999;
            newFloyd.TwoDimensionArray = new int[5, 5] { { 0, 3, 8, 9999, -4 },
                                            { 9999, 0, 9999, 1, 7 },
                                            { 9999, 4, 0, 9999, 9999 },
                                            { 2, 9999, -5, 0, 9999 },
                                            { 9999, 9999,9999, 6, 0 } };
            //newFloyd.dist = new int[5, 5] { { 0, int.MaxValue, int.MaxValue, 2, int.MaxValue }, { 3, 0, 4, int.MaxValue, int.MaxValue }, { 8, int.MaxValue, 0, -5, int.MaxValue }, { int.MaxValue, 1, int.MaxValue, 0, 6 }, { -4, 7, int.MaxValue, int.MaxValue, 0 } };
            //newFloyd.dist = new int[5, 5] { { 0, int.MaxValue, 3, int.MaxValue, 1 },
            //                                { 5, 0, int.MaxValue, int.MaxValue, 3 },
            //                                { int.MaxValue, 2, 0, 4, int.MaxValue },
            //                                { 2, int.MaxValue, int.MaxValue, 0, 0 },
            //                                { int.MaxValue, int.MaxValue, 7, 1, 0 } };
            //newFloyd.dist = new int[5, 5] { { 0, 5, int.MaxValue, 2, int.MaxValue },
            //                                { int.MaxValue, 0, 2, int.MaxValue, int.MaxValue },
            //                                { 3, int.MaxValue, 0, int.MaxValue, 7 },
            //                                { int.MaxValue, int.MaxValue, 4, 0, 1 },
            //                                { 1, 3, int.MaxValue, int.MaxValue, 0 } };

            //newFloyd.dist = new int[4, 4] { {0,   5,  9999, 10},
            //                                {9999,  0,  3,  9999},
            //                                {9999, 9999, 0,   1},
            //                                {9999, 9999, 9999, 0} };
            newFloyd.NumberOfNodes = 5;
            newFloyd.Floyd_warshallWork();
            List<int> rez = new List<int>();
            newFloyd.GetPath(2, 4, ref rez);

            string result = "";
            foreach (var item in rez)
            {
                result += item;
            }
            Assert.AreEqual("21304", result);
        }
    }
}