using Environment.Tasks;
using System;
using UnityEngine;
using Utilities;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "BinaryTreeTask", menuName = "Binary Tree Task")]
    public class BinaryTreeTask : Task
    {
        [SerializeField] DataReader ReadData;
        BST BinarySearchTree;
        public override void Execute()
        {
            BinarySearchTree = new BST();
            BinarySearchTree.Tree = BinarySearchTree.BinaryTreeMaker(ReadData.PLEASEWORK, 0, ReadData.PLEASEWORK.employees.Length - 1);
            BinarySearchTree.BFS(BinarySearchTree.Tree);
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
                Debug.Log(Node.Value);

                if (Node.Left != null)
                {
                    Queue.Enqueue(Node.Left);
                }

                if (Node.Left != null)
                {
                    Queue.Enqueue(Node.Left);
                }
            }
        }
        public BSTNode BinaryTreeMaker(EmployeeList Employees, int Lowest, int Highest)
        {
            BSTNode Result = new BSTNode();

            int Median = Lowest + (Highest - Lowest) / 2;

            Result.Employee = Employees.employees[Median];

            Result.Value = Employees.employees[Median].EnteredEngineRoom;

            if (!(Lowest >= Highest - 1))
            {
                Result.Right = BinaryTreeMaker(Employees, Median + 1, Highest);
                Result.Left = BinaryTreeMaker(Employees, Lowest, Median - 1);
            }

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
