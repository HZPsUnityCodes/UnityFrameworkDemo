using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSelector :Node
{
    Node[] nodeArray;

    public PSelector(string n) {
        name = n;
    }

    void OrderNodes() {
        nodeArray = children.ToArray();

        Sort( 0,children.Count-1);

        children = new List<Node>(nodeArray);
    }

    public void printOrderNodesLeveal() {
        OrderNodes();
        while (currentChild<children.Count) {
            Debug.Log($"{children[currentChild].sortOrder}");
            currentChild++;
        }
        currentChild = 0;

    }

    public override Status Process()
    {
        OrderNodes();
        Status childStatus = children[currentChild].Process();

        if (childStatus == Status.RUNING)
        {
            return Status.RUNING;
        }

        if (childStatus == Status.SUCCES)
        {
            children[currentChild].sortOrder = 1;
            currentChild = 0;
            return Status.SUCCES;
        }
        else {
            children[currentChild].sortOrder = 10;
        }

        if (childStatus == Status.FAILURE)
            currentChild++;

        if (currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.FAILURE;
        }
        return Status.RUNING;
    }

    public void Sort(int initIndex, int endIndex)
    {
        Stack<int> stackQuickSet = new Stack<int>();
        int mid = 0;

        stackQuickSet.Push(initIndex);
        stackQuickSet.Push(endIndex);
        int left = initIndex;
        int right = endIndex;
        while (!(stackQuickSet.Count == 0))
        {
            right = stackQuickSet.Pop();
            left = stackQuickSet.Pop();
            mid = QuickOneSort(left, right);
            if (right > (mid + 1))
            {
                stackQuickSet.Push(mid + 1);
                stackQuickSet.Push(right);
            }

            if ((mid - 1) > left)
            {
                stackQuickSet.Push(left);
                stackQuickSet.Push(mid - 1);
            }
        }
    }

    public int QuickOneSort( int initIndex, int endIndex)
    {

        int keyIndex = initIndex;
        Node keyNode = nodeArray[initIndex];
        Node mid;
        while (initIndex < endIndex)
        {
            //   8 2 5 
            while (nodeArray[endIndex].sortOrder >= keyNode.sortOrder && initIndex < endIndex)
            {
                endIndex = endIndex - 1;
            }

            while (nodeArray[initIndex].sortOrder <= keyNode.sortOrder && initIndex < endIndex)
            {
                initIndex = initIndex + 1;
            }

            mid = nodeArray[initIndex];
            nodeArray[initIndex] = nodeArray[endIndex];
            nodeArray[endIndex] = mid;
        }
        nodeArray[keyIndex] = nodeArray[initIndex];
        nodeArray[initIndex] = keyNode;

        return initIndex;
    }

}
