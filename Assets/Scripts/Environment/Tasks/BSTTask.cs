using System;
using System.Diagnostics;
using UnityEngine;
namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "BTTask", menuName = "BTTask")]
    public class BSTTask : Task
    {
        [SerializeField] CustomTask Employees;
        [SerializeField] EmployeeData empData;
        public override void Execute()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BinarySearchTree BT = new BinarySearchTree(empData.employees[785]);
            for(int i = 785; i < empData.employees.Length; i++)
            {
                BT.Insert(empData.employees[i]);
            }
            BT.BFS();
            sw.Stop();
            UnityEngine.Debug.Log("It took: " + sw.ElapsedMilliseconds + " ms");
        }
    }
}
