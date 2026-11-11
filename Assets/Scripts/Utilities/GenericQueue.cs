using System; using System.Collections.Generic; using UnityEngine;  namespace Utilities {     [Serializable]     class GenericQueue <Thing>     {         public List<Thing> Queue = new List<Thing>();          public void Enqueue(Thing MyThing)
        {
            Queue.Add(MyThing);
            return;
        }         public Thing Dequeue()         {
            if (Queue.Count == 0) 
            {
                throw new Exception("GeneralQueue is Empty, Cannot Dequeue");
            }

            Thing MyThing = Queue[0];
            Queue.RemoveAt(0); 
            return MyThing;
        }         public Thing Peek()
        {
            if (Queue.Count == 0)
            {
                throw new Exception("GeneralQueue is Empty, Cannot Peek");
            }

            return Queue[0];
        }     } } 