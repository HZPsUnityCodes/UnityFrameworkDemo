using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAgent : MonoBase
{

    public BehaviourTree tree;

    public enum ActionState
    {
        IDLE,
        WORKING
    }

    WaitForSeconds waitForSeconds;
    ActionState action = ActionState.IDLE;
    Node.Status treeStatus = Node.Status.RUNING;

    public bool isFrontDoorOpen = true;
    public bool isBackDoorOpen = false;



    public void Start()
    {
        tree = new BehaviourTree();
        waitForSeconds = new WaitForSeconds(Random.Range(0.1f, 1f));
        StartCoroutine("Behave");
    } 
    IEnumerator Behave()
    {
        while (true)
        {
            treeStatus = tree.Process();
            yield return waitForSeconds;
        }
    }
    void Update()
    {
    }
}
