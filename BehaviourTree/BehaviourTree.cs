using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree :Node
{


    /// <summary>
    /// 行为树
    /// </summary>
    public BehaviourTree()
    {
        name = "Tree";
    }

    public BehaviourTree(string n)
    {
        name = n;
    }


    public override Node.Status Process() {
        if (children.Count == 0) return Status.SUCCES;
        return children[currentChild].Process();
    }
    public void PrintTree()
    {
        List<Node> visitNodeStack = new List<Node>();
        


        Node currentVisit =this;
        int len;
        int currentDepath=0 ;


        //打印节点的所有儿子 深度搜索
        //判断 有没有子节点
        //判断子节点有没有 看完
        
        do
        {
            while (currentVisit.children.Count > currentVisit.currentChild)
                
            {
                
                visitNodeStack.Add(currentVisit);//获得当前层currentChild

                currentVisit.currentChild = currentVisit.currentChild + 1;
                currentVisit = currentVisit.children[currentChild-1];
                currentDepath = currentDepath + 1;

                len = currentVisit.children.Count;
                for (int i = 0; i < len; i++)
                {
                    Debug.Log($"{currentVisit.children[i].name}-");
                }
            }
           
            currentDepath = currentDepath - 1;
            currentVisit = visitNodeStack[currentDepath];//当节点没有孩子  回到父节点
            if (currentVisit.children.Count > currentVisit.currentChild)//看看下一个儿子有木有孙子  如果有 开始新的访问
            {
                 
                currentVisit.currentChild = currentVisit.currentChild + 1;
                currentVisit = currentVisit.children[currentChild - 1];
                currentDepath = currentDepath + 1;
                visitNodeStack[currentDepath] = currentVisit; //跟新当前层的访问


            }
            else
            {
                //所有儿子都没有孙子 ，返回上一层 看看兄弟
                continue;
            } 
        } while (currentDepath ==0);//没有父亲了 遍历结束

    }
}
