using Environment.Tasks;
using JetBrains.Annotations;
using System;
using UnityEngine;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "SearchDataTask", menuName = "Search Data Task")]
    public class SearchingTask : Task
    {
        [SerializeField] DataReader ReadData;

        [Header("Desired Entrance Time")]
        [SerializeField] string Year;
        [SerializeField] string Month;
        [SerializeField] string Day;
        [SerializeField] string Hour;
        [SerializeField] string Minutes;
        [SerializeField] string Seconds;
        Data[] ListOfEmployees;
        DateTime DesiredData;
        int Result;
        public override void Execute()
        {
            string TempDate = ($"{Year}-{Month}-{Day}T{Hour}:{Minutes}:{Seconds}");
            DesiredData = DateTime.ParseExact(TempDate, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            ListOfEmployees = ReadData.PLEASEWORK.employees;
            Result = BinarySearch(ListOfEmployees, DesiredData);

            Debug.Log(DesiredData);
            Debug.Log(Result);
            Debug.Log(ListOfEmployees[Result].name);
        }
        public int BinarySearch(Data[] MyEmployees, DateTime MyDesire)
        {
            int Lowest = 0;
            int Highest = MyEmployees.Length - 1;

            while (Lowest <= Highest)
            {
                int Median = Lowest + (Highest - Lowest) / 2;
                
                if (MyEmployees[Median].EnteredEngineRoom == MyDesire)
                {
                    return Median;
                }

                if (MyEmployees[Median].EnteredEngineRoom < MyDesire)
                {
                    Lowest = Median + 1;
                }
                else
                {
                    Highest = Median - 1;
                }
            }

            return -1;
        }
    }
}
