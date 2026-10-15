using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    // Kept only so older assets can still deserialize; new computer behavior uses dedicated task assets.
    [System.Obsolete("Use the dedicated Computer task assets instead.")]
    public sealed class ComputerActionTask : Task {
        public override IEnumerator Execute(Computer computer) {
            Debug.LogWarning("ComputerActionTask is obsolete. Assign a dedicated Computer task asset.", computer);
            yield break;
        }
    }
}