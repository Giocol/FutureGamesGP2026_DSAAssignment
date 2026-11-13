using Environment.Tasks;
using System;
using System.Diagnostics;
using UnityEngine;
using Utilities;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "BinaryTreeTask", menuName = "Binary Tree Task")]
    public class BinaryTreeTask : Task
    {
        [SerializeField] DataReader ReadData;
        BST BinarySearchTree;
        Stopwatch Stopwatch;
        public override void Execute()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            BinarySearchTree = new BST();
            BinarySearchTree.Tree = BinarySearchTree.BinaryTreeMaker(ReadData.PLEASEWORK, 0, ReadData.PLEASEWORK.employees.Length - 1);
            BinarySearchTree.BFS(BinarySearchTree.Tree);
            Stopwatch.Stop();
            UnityEngine.Debug.Log(Stopwatch.Elapsed);
        }
    }

    public class BST
    {
        public BSTNode Tree;

        public void BFS(BSTNode MyRoot)
        {
            GenericQueue<BSTNode> Queue = new GenericQueue<BSTNode>();
            Queue.Enqueue(MyRoot);

            while (Queue.Queue.Count > 0)
            {
                BSTNode Node = Queue.Dequeue();
                //Debug.Log(Node.Value);

                if (Node.Left != null)
                {
                    Queue.Enqueue(Node.Left);
                }

                if (Node.Right != null)
                {
                    Queue.Enqueue(Node.Right);
                }
            }
        }
        public BSTNode BinaryTreeMaker(EmployeeList Employees, int Lowest, int Highest)
        {
            if (Lowest > Highest)
            {
                return null;
            }

            BSTNode Result = new BSTNode();

            int Median = Lowest + (Highest - Lowest) / 2;

            Result.Employee = Employees.employees[Median];

            Result.Value = Employees.employees[Median].EnteredEngineRoom;
            Result.Right = BinaryTreeMaker(Employees, Median + 1, Highest);
            Result.Left = BinaryTreeMaker(Employees, Lowest, Median - 1);

            return Result;
        }
    }
    public class BSTNode
    {
        public Data Employee;
        public DateTime Value;
        public BSTNode Left;
        public BSTNode Right;

    }
}
