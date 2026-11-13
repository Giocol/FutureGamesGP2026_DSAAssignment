using UnityEngine;
using static Employee;
[CreateAssetMenu(fileName = "EmployeeData", menuName = "EmployeeData")]
public class EmployeeData : ScriptableObject
{
    [SerializeField] public Employee[] employees;
}
