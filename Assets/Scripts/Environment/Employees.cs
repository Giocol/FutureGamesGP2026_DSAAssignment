using System;
using UnityEngine;
[Serializable] public class Employee
{
    public string name;
    public string employeeID;
    public string lastEntranceInEngineRoom;
    public string lastExitFromEngineRoom;
    public bool hasEngineRoomClearance;
    public DateTime entered;
    public DateTime exited;
}
[Serializable] public class EmployeeArray
{
    public global::Employee[] employees;
}
