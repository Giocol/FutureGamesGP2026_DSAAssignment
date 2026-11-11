using Environment.Tasks;
using System;
using UnityEngine;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "BinaryTreeTask", menuName = "Binary Tree Task")]
    public class BinaryTreeTask : Task
    {
        [SerializeField] DataReader ReadData;
        public override void Execute()
        {

        }
    }

    public class BST
    {
        BSTNode Tree;
    }

    public class BSTNode
    {
        public DateTime Value;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode BinaryTreeMaker(EmployeeList Employees, int Lowest, int Highest)
        {
            BSTNode Result = new BSTNode();

            int Median = Lowest + (Highest - Lowest) / 2;
            
            Result.Value = Employees.employees[Median].EnteredEngineRoom;

            if (Lowest != Highest)
            {
                Result.Right = BinaryTreeMaker(Employees, Median + 1, Highest);
                Result.Left = BinaryTreeMaker(Employees, Lowest, Median - 1);
            }

            return Result;
        }
    }
}
