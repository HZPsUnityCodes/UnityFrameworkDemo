using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberBehaviour : BTAgent
{
    //public bool isFrontDoorOpen = true;
    //public bool isBackDoorOpen = false;

    private int money=500;

    
    new void Start()
    {
        base.Start();
        Debug.Log("Tree is Init");
        Squence steal = new Squence("Steal Something");
        Leaf goToDiamond = new Leaf("go to diamond", GoToDiamond);
        Leaf goToVan = new Leaf("GO To Van", GoToVan);

        Leaf goToFrontDoor = new Leaf("go to FrontDoor", GoToFrontDoor);
        Leaf goToBackDoor = new Leaf("go to BackDoor", GoToBackDoor);

        Leaf hasGotMoney = new Leaf("has Got Money", HasGetMoney);

        Selector opendoor = new Selector("OpenDoor");

        Inverter invertMoney = new Inverter("Invert Money");



        Leaf testNode1 = new Leaf("test", printPLevel,3);

        Leaf testNode2 = new Leaf("test", printPLevel, 1);

        Leaf testNode3 = new Leaf("test", printPLevel, 7);
        Leaf testNode4 = new Leaf("test", printPLevel, 5);
        Leaf testNode5 = new Leaf("test", printPLevel, 2);

        PSelector test = new PSelector("test");
        test.AddChild(testNode1);
        test.AddChild(testNode2);
        test.AddChild(testNode3);
        test.AddChild(testNode4);
        test.AddChild(testNode5);

        test.printOrderNodesLeveal();
        opendoor.AddChild(goToFrontDoor);
        opendoor.AddChild(goToBackDoor);

        invertMoney.AddChild(hasGotMoney);
        steal.AddChild(invertMoney);
        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        steal.AddChild(opendoor);
        tree.AddChild(steal);
    }
    public Node.Status GoToDiamond()
    {
        Debug.Log("runing goToDiamond");
        return Node.Status.SUCCES;
    }

    public Node.Status GoToVan()
    {
        Debug.Log("runing goToVan");
        return Node.Status.RUNING;
    }
    public Node.Status GoToFrontDoor()
    {

        if (isFrontDoorOpen.Equals(true)) {
            Debug.Log("runing GoToFrontDoor");
            return Node.Status.SUCCES;
        }
        return Node.Status.FAILURE;
    }

    public Node.Status GoToBackDoor()
    {

        if (isBackDoorOpen.Equals(true))
        {
            Debug.Log("runing GoToBackDoor");
            return Node.Status.SUCCES;
        }
        
        return Node.Status.FAILURE;
    }

    public Node.Status HasGetMoney()
    {
        if (this.money <= 1000)
        {
            Debug.Log(" money is not enough");
            return Node.Status.FAILURE;
        }
        return Node.Status.SUCCES;
    }
    public Node.Status printPLevel() { 

        return Node.Status.SUCCES;
    }
}
