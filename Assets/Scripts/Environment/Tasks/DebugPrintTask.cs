using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "DebugPrint Task", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task {
        [SerializeField]
        private string textToPrint = "Hi, I'm a test task!";

        public override IEnumerator Execute(Computer computer) {
            Debug.Log(textToPrint);
            yield break;
        }
    }
}