using Environment.Tasks;
using System;
using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "SortingTask", menuName = "SortingTask")]
public class SortingTask : Task {
    [SerializeField] EmployeeData employeeData;
    public static Employee[] sortedEmployees;
    public static void mergeSort(Employee[] employees, int left, int right) {
        if(left < right) {
            int middle = left + ((right - left) / 2);
            mergeSort(employees, left, middle);
            mergeSort(employees, middle + 1, right);
            merge(employees, left, middle, right);
        }
    }
    public override void Execute() {
        Stopwatch sw = new();
        sw.Start();
        sortedEmployees = employeeData.employees;
        if(sortedEmployees != null && sortedEmployees.Length <= 0) {
            return;
        }
        foreach(Employee employee in sortedEmployees) {
            employee.entered = DateTime.ParseExact(employee.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
        employeeData.employees = sortedEmployees;
        mergeSort(sortedEmployees, 0, sortedEmployees.Length - 1);
        employeeData.employees = sortedEmployees;
        sw.Stop();
        UnityEngine.Debug.Log("It took: " + sw.ElapsedMilliseconds + " ms");
        //foreach(Employee employee in employees) {
        //    Debug.Log("lastEntranceInEngineRoom: " + employee.lastEntranceInEngineRoom);
        //}
    }
    public static void merge(Employee[] employees, int left, int middle, int right) {
        Employee[] tempLeft = employees[left..(middle + 1)];
        Employee[] tempRight = employees[(middle + 1)..(right + 1)];
        int i = 0;
        int j = 0;
        int k = left;
        while(i < (tempLeft.Length) && j < (tempRight.Length)) {
            if(tempLeft[i].entered <= tempRight[j].entered) {
                employees[k] = tempLeft[i];
                i++;
            }
            else {
                employees[k] = tempRight[j];
                j++;
            }
            k++;
        }
        while(i < (tempLeft.Length)) {
            employees[k] = tempLeft[i];
            i++;
            k++;
        }
        while(j < (tempRight.Length)) {
            employees[k] = tempRight[j];
            j++;
            k++;
        }
    }
}


