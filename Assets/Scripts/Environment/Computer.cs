using System.Collections.Generic;
using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        private void Awake()
        {
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            int value = myQueue.Dequeue();

            Queue<bool> myBoolQueue = new Queue<bool>();
            myBoolQueue.Enqueue(true);
            myBoolQueue.Enqueue(false);
            bool boolValue = myBoolQueue.Dequeue();
        }

        public void OnInteract()
        {
            testTask.Execute();
        }
    }
}
