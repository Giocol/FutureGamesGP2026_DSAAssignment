using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Change Worklog Page Task", menuName = "Tasks/Computer/Change Worklog Page")]
    public sealed class ChangeWorklogPageTask : WorklogTask {
        [SerializeField] private int direction = 1;

        public override IEnumerator Execute(Computer computer) {
            int maxPage = Mathf.CeilToInt((float)computer.WorklogEntries.Count / computer.LogsPerPage) - 1;
            computer.CurrentLogPage = Mathf.Clamp(computer.CurrentLogPage + direction, 0, Mathf.Max(0, maxPage));
            RefreshDisplay(computer);
            yield break;
        }
    }
}
