using Environment.Tasks;
using UnityEngine;
using Utilities;

namespace Environment 
{
    public class Computer : MonoBehaviour, IInteractable 
    {
        [SerializeField] GenericQueue<Task> QueuedTasks = new GenericQueue<Task>();

        public void OnInteract() 
        {
            if (QueuedTasks.Queue.Count > 0)
            {
                Task MyTask = QueuedTasks.Dequeue();
                MyTask.Execute();
            }
        }
    }
}
