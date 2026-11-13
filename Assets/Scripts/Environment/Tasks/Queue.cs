using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
[Serializable] public class GenericQueue<T> {
[SerializeField] private List<T> queue;
    public GenericQueue() {
        queue = new List<T>();
    }
    public void Enqueue(T Task1) {
        queue.Add(Task1);
    }
    public T Dequeue() {
        if(queue.Count == 0) {
            throw new Exception("Queue is empty, cannot peek, bozo");
        }
        T topOfQueue = queue[0];
        queue.RemoveAt(0);
        return topOfQueue;
    }
}
