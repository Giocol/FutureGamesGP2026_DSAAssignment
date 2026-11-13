using System;
using System.Collections.Generic;
using UnityEngine;

public class BSTNode<T> {
    public T data;
    public BSTNode<T> leftChild = null;
    public BSTNode<T> rightChild = null;
    public T GetData() {
        return data;
    }
    public BSTNode(T inData) {
        this.data = inData;
    }
}
public class BinarySearchTree {
    public BSTNode<Employee> root;
    public BinarySearchTree(Employee rootData) {
        root = new BSTNode<Employee>(rootData);
    }
    public void Insert(Employee inData) {
        BSTNode<Employee> newNode = new BSTNode<Employee>(inData);
        BSTNode<Employee>? currentNode = root;
        BSTNode<Employee> lastParent = root;

        while(currentNode != null) {
            if(DateTime.ParseExact(inData.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) <
                DateTime.ParseExact(currentNode.GetData().lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) {
                lastParent = currentNode;
                currentNode = currentNode.leftChild;
            }
            else {
                lastParent = currentNode;
                currentNode = currentNode.rightChild;
            }
        }
        if(DateTime.ParseExact(inData.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) <
            DateTime.ParseExact(lastParent.GetData().lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) {
            lastParent.leftChild = newNode;
        }
        else {
            lastParent.rightChild = newNode;
        }
    }
    public void BFS() {
        Queue<BSTNode<Employee>> queue = new Queue<BSTNode<Employee>>();
        queue.Enqueue(root);

        while(queue.Count > 0) {
            BSTNode<Employee> node = queue.Dequeue();
            Debug.Log(node.GetData().name + " " + node.GetData().lastEntranceInEngineRoom + " Exit Time: " + node.GetData().lastExitFromEngineRoom);
            if(node.leftChild != null)
                queue.Enqueue(node.leftChild);
            if(node.rightChild != null)
                queue.Enqueue(node.rightChild);
        }
    }
}

