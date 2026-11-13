using Environment;
using Environment.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "CustomTask", menuName = "CustomTask")]
public class CustomTask : Task {
    [SerializeField] EmployeeData employeeData;
    [SerializeField] TextAsset jsonFile;
    public override void Execute() {
        if(jsonFile == null) {
            return;
        }
        Employee[] employees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;
        if(employees != null && employees.Length <= 0) {
            return;
        }

        employeeData.employees = employees;

        foreach(Employee employee in employees) {
            Debug.Log("Name: " + employee.name);
            Debug.Log("employeeID: " + employee.employeeID);
            Debug.Log("hasEngineRoomClearance: " + employee.hasEngineRoomClearance);
            Debug.Log("lastEntranceInEngineRoom: " + employee.lastEntranceInEngineRoom);
            Debug.Log("lastExitFromEngineRoom: " + employee.lastExitFromEngineRoom);
        }
    }
}
