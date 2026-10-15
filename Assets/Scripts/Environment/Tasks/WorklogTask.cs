using UnityEngine;

namespace Environment.Tasks {
    public abstract class WorklogTask : Task {
        protected void RefreshDisplay(Computer computer) {
            GameObject[] icons = computer.WorklogIcons;
            TMPro.TextMeshProUGUI[] labels = computer.WorklogLabels;
            if(icons == null || labels == null) {
                Debug.LogWarning("Przypisz tablice ikon i tekstów logów w komponencie Computer.", computer);
                return;
            }

            int count = Mathf.Min(computer.LogsPerPage, icons.Length, labels.Length);
            for(int i = 0; i < count; i++) {
                int dataIndex = computer.CurrentLogPage * computer.LogsPerPage + i;
                bool hasEntry = dataIndex < computer.WorklogEntries.Count;
                if(icons[i] != null)
                    icons[i].SetActive(hasEntry);
                else if(hasEntry)
                    Debug.LogWarning($"Brak przypisanego GameObjectu ikony dla logu nr {i + 1}.", computer);

                if(hasEntry && labels[i] != null)
                    labels[i].text = computer.WorklogEntries[dataIndex].lastEntranceInEngineRoom;
                else if(hasEntry)
                    Debug.LogWarning($"Brak przypisanego pola tekstowego dla logu nr {i + 1}.", computer);
            }
        }
    }
}
