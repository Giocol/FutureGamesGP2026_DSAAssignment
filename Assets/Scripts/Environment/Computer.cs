using Environment.Tasks;
using System;
using UnityEngine;
namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] GenericQueue<Task> taskQueue = new();
        public void OnInteract()
        {
            taskQueue.Dequeue().Execute();
        }
    }
}
