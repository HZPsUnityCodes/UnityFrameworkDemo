using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{

    public enum Status { 
        SUCCES,RUNING,FAILURE
    }

    public Status status;
    public List<Node> children = new List<Node>();

    public int currentChild = 0;

    public string name;

    public int sortOrder;

    public Node() { }

    public  Node(string n)
    {
        name = n;
    }

    public Node(string n,int p) {
        sortOrder = p;
    }

    public virtual Status Process() 
    {
        return children[currentChild].Process();
    }

    public void AddChild(Node n) 
    {
        children.Add(n);
    }
}
