using Environment.Tasks;
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "SearchTask", menuName = "SearchTask")]
public class SearchTask : Task {
    [SerializeField] EmployeeData employeeData;
    public static int BinarySearch(Employee[] employees, DateTime x) {
        int low = 0;
        int high = employees.Length - 1;
        while(low <= high) {
            int median = low + (high - low) / 2;
            if(employees[median].entered == x)
                return median;
            if(employees[median].entered < x)
                low = median + 1;
            else
                high = median - 1;
        }
        return -1;
    }
    public override void Execute() {
        DateTime Start = DateTime.Now;
        int low = BinarySearch(employeeData.employees, new DateTime(2234, 9, 9, 21, 0, 0));
        int high = BinarySearch(employeeData.employees, new DateTime(2234, 9, 9, 22, 0, 0));
        Debug.Log("Low high: " + low);
        for(int i = low; i <= high; i++) {
            Debug.Log("lastEntranceInEngineRoom: " + employeeData.employees[i].lastEntranceInEngineRoom);
        }
        DateTime Stop = DateTime.Now;
        TimeSpan ElapsedTime = Stop - Start;
        Debug.Log("ElapsedTime: " + ElapsedTime.TotalMilliseconds + " ms");
    }
}
