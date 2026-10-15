using System;
using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Load Employees Task", menuName = "Tasks/Computer/Load Employees")]
    public sealed class LoadEmployeesTask : WorklogTask {
        public override IEnumerator Execute(Computer computer) {
            if(computer.EmployeesJsonFile == null) {
                Debug.LogWarning("Nie przypisano pliku JSON z pracownikami w polu employeesJsonFile!", computer);
                yield break;
            }

            EmployeeListWrapper data = null;
            string parseError = null;
            try {
                data = JsonUtility.FromJson<EmployeeListWrapper>(computer.EmployeesJsonFile.text);
            }
            catch(ArgumentException exception) {
                parseError = exception.Message;
            }

            if(parseError != null) {
                Debug.LogError($"Błąd podczas parsowania pliku JSON z pracownikami: {parseError}", computer);
                yield break;
            }
            if(data == null || data.employees == null) {
                Debug.LogError("Błąd podczas parsowania pliku JSON z pracownikami.", computer);
                yield break;
            }

            computer.WorklogEntries.Clear();
            computer.WorklogEntries.AddRange(data.employees);
            computer.CurrentLogPage = 0;
            Debug.Log($"Wczytano pomyślnie {computer.WorklogEntries.Count} pełnych logów pracowników.", computer);
            RefreshDisplay(computer);
        }
    }
}
