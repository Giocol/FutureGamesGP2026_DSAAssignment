using Environment.Tasks;
using System;
using System.Linq;
using UnityEngine;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "SortDataTask", menuName = "Sort Data Task")]
    public class SortingTask : Task
    {
        [SerializeField] DataReader ReadData;
        Data[] ListOfEmployees;
        Data TempEmployee;
        int PivotPoint;
        int Pivot;
        public override void Execute()
        {
            ListOfEmployees = ReadData.PLEASEWORK.employees;
            QuickSort(ReadData.PLEASEWORK.employees, 0, ListOfEmployees.Length - 1);
        }

        //COMMENTS ARE PSEUDO CODE SINCE I WAS CONFUSED ABOUT THIS AND FOR THE FUTURE I WANNA KEEP MYSELF NOTTT CONFUSED

        // Function that takes in the array, the most left element and most right element
        public void QuickSort(Data[] MyEmployees, int MyLeft, int MyRight)
        {
            // If the Leftmost element is smaller than the Rightmost AKA while its bigger then 1
            if (MyLeft < MyRight)
            {
                //Use the Partition function
                PivotPoint = Partition(MyEmployees, MyLeft, MyRight);

                //Sort the left SubArray
                QuickSort(MyEmployees, MyLeft, PivotPoint - 1);

                //Sort the right SubArray
                QuickSort(MyEmployees, PivotPoint + 1, MyRight);
            }
            //Return the finished product
            return;
        }

        // Function that takes in the array, the leftmost element and mostright element
        public int Partition(Data[] MyEmployees, int MyLeft, int MyRight)
        {
            // Selects the median as the pivot point
            Pivot = MyEmployees[MyLeft + ((MyRight - MyLeft) / 2)].employeeId;

            // Put the median at the end of the array
            TempEmployee = MyEmployees[MyLeft + ((MyRight - MyLeft) / 2)];
            MyEmployees[MyLeft + ((MyRight - MyLeft) / 2)] = MyEmployees[MyRight];
            MyEmployees[MyRight] = TempEmployee;

            // Lags the i variable
            int i = MyLeft - 1;

            // For Loop that goes through the Array
            for (int j = MyLeft; j <= MyRight - 1; j++)
            {
                // If the element is less than the pivot
                if (MyEmployees[j].employeeId < Pivot)
                {
                    // Unlag the i and add 1 to mark it as sorted
                    i = i + 1;

                    // Swap it with ???
                    TempEmployee = MyEmployees[i];
                    MyEmployees[i] = MyEmployees[j];
                    MyEmployees[j] = TempEmployee;
                }
            }

            // Swap it with the element thats higher than pivot with the rightmost element
            TempEmployee = MyEmployees[i + 1];
            MyEmployees[i + 1] = MyEmployees[MyRight];
            MyEmployees[MyRight] = TempEmployee;

            //Return the solved element
            return i + 1;
        }
    }
}
