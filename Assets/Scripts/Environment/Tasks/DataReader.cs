using System;
using System.IO;
using UnityEngine;

namespace Environment.Tasks
{

    [Serializable]
    public class EmployeeList
    {
        public Data[] employees;
    }

    [Serializable]
    public class Data
    {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom;
        public DateTime EnteredEngineRoom;
        public DateTime ExitingEngineRoom;
    }

    [CreateAssetMenu(fileName = "ReadDataTask", menuName = "Read Data Task")]
    public class DataReader : Task
    {
        [SerializeField] string FileName;
        public EmployeeList PLEASEWORK;     //Change the name PERHAPS
        string Json;
        string FilePath;

        public override void Execute()
        {
            Read();
            Solve(Json);
            Convert();
        }

        public void Read()
        {
            FilePath = Path.Combine(Application.streamingAssetsPath, FileName);
            Debug.Log(FilePath);

            Json = File.ReadAllText(FilePath);
            Debug.Log(Json);
        }

        public string Solve(string MyString)
        {
            PLEASEWORK = new EmployeeList();
            JsonUtility.FromJsonOverwrite(MyString, PLEASEWORK);
            return MyString;
        }

        public void Convert()
        {
            foreach (Data Employee in PLEASEWORK.employees)
            {
                Employee.EnteredEngineRoom = DateTime.ParseExact(Employee.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                Employee.ExitingEngineRoom = DateTime.ParseExact(Employee.lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                Debug.Log(Employee.EnteredEngineRoom + "\n" + Employee.ExitingEngineRoom);
            }
        }
    }
}
