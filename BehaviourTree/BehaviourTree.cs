using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree :Node
{


    /// <summary>
    /// ��Ϊ��
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


        //��ӡ�ڵ�����ж��� �������
        //�ж� ��û���ӽڵ�
        //�ж��ӽڵ���û�� ����
        
        do
        {
            while (currentVisit.children.Count > currentVisit.currentChild)
                
            {
                
                visitNodeStack.Add(currentVisit);//��õ�ǰ��currentChild

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
            currentVisit = visitNodeStack[currentDepath];//���ڵ�û�к���  �ص����ڵ�
            if (currentVisit.children.Count > currentVisit.currentChild)//������һ��������ľ������  ����� ��ʼ�µķ���
            {
                 
                currentVisit.currentChild = currentVisit.currentChild + 1;
                currentVisit = currentVisit.children[currentChild - 1];
                currentDepath = currentDepath + 1;
                visitNodeStack[currentDepath] = currentVisit; //���µ�ǰ��ķ���


            }
            else
            {
                //���ж��Ӷ�û������ ��������һ�� �����ֵ�
                continue;
            } 
        } while (currentDepath ==0);//û�и����� ��������

    }
}
