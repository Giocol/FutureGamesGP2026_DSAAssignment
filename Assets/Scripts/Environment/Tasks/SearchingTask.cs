using Environment.Tasks;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment.Tasks
{
    [CreateAssetMenu(fileName = "SearchDataTask", menuName = "Search Data Task")]
    public class SearchingTask : Task
    {
        [SerializeField] DataReader ReadData;

        [Header("Desired Earliest Entrance Time")]
        [SerializeField] string EarlyYear;
        [SerializeField] string EarlyMonth;
        [SerializeField] string EarlyDay;
        [SerializeField] string EarlyHour;
        [SerializeField] string EarlyMinutes;
        [SerializeField] string EarlySeconds;

        [Header("Desired Latest Entrance Time")]
        [SerializeField] string LateYear;
        [SerializeField] string LateMonth;
        [SerializeField] string LateDay;
        [SerializeField] string LateHour;
        [SerializeField] string LateMinutes;
        [SerializeField] string LateSeconds;

        [Header("Results")]
        [SerializeField] List<Data> ResultedEmployees = new List<Data>();

        Data[] ListOfEmployees;
        DateTime DesiredData;
        int EarlyResult;
        int LateResult;
        public override void Execute()
        {
            ResultedEmployees.Clear();

            ListOfEmployees = ReadData.PLEASEWORK.employees;
            string TempDate;

            TempDate = ($"{EarlyYear}-{EarlyMonth}-{EarlyDay}T{EarlyHour}:{EarlyMinutes}:{EarlySeconds}");
            DesiredData = DateTime.ParseExact(TempDate, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            
            EarlyResult = BinarySearch(ListOfEmployees, DesiredData);

            TempDate = ($"{LateYear}-{LateMonth}-{LateDay}T{LateHour}:{LateMinutes}:{LateSeconds}");
            DesiredData = DateTime.ParseExact(TempDate, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            LateResult = BinarySearch(ListOfEmployees, DesiredData);

            for (int i = EarlyResult; i <= LateResult; i++)
            {
                ResultedEmployees.Add(ListOfEmployees[i]);
            }
        }
        public int BinarySearch(Data[] MyEmployees, DateTime MyDesire)
        {
            int Lowest = 0;
            int Highest = MyEmployees.Length - 1;
            int Median = 0;

            while (Lowest <= Highest)
            {
                Median = Lowest + (Highest - Lowest) / 2;
                
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

            return Median;
        }
    }
}
