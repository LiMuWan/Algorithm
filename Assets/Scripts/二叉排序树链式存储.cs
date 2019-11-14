using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class 二叉排序树链式存储 : MonoBehaviour
{
    private void Start()
    {
        BSTree tree = new BSTree();
        int[] data = { 62, 58, 88, 47, 73, 99,35, 51, 93, 37 };
        for (int i = 0; i < data.Length; i++)
        {
            tree.Add(data[i]);
        }
        tree.MiddleTraversal();
        Debug.Log(tree.Find(99));
        Debug.Log(tree.Find(100));
    }
}

public class BSTree
{
    private BSNode root = null;
    private StringBuilder builder = new StringBuilder();

    public void Add(int item)
    {
        BSNode newNode = new BSNode(item);
        if (root == null)
        {
            root = newNode;
        }
        else
        {
            BSNode temp = root;
            while (true)
            {
                if(item >= temp.data)//放在temp的右边
                {
                    if(temp.RightChild == null)
                    {
                        temp.RightChild = newNode;
                        newNode.Parent = temp;
                        break;
                    }
                    else
                    {
                        temp = temp.RightChild;
                    }
                }
                else//放在temp的左边
                {
                    if(temp.LeftChild == null)
                    {
                        temp.LeftChild = newNode;
                        newNode.Parent = temp;
                        break;
                    }
                    else
                    {
                        temp = temp.LeftChild;
                    }
                }
            }
        }
    }

    public void MiddleTraversal()
    {
        builder.Clear();
        MiddleTraversal(root);
        Debug.Log(builder.ToString());
    }

    private void MiddleTraversal(BSNode node)
    {
        if (node == null) return;
        MiddleTraversal(node.LeftChild);
        builder.Append(node.data + " ");
        MiddleTraversal(node.RightChild);
    }

    public bool Find(int item)
    {
       return Find(item, root);
    }

    public bool Find1(int item)
    {
        BSNode temp = root;
        while (true)
        {
            if (temp == null) return false;
            if (temp.data == item) return true;
            if (item >= temp.RightChild.data)
                temp = temp.RightChild;
            else
                temp = temp.LeftChild;
        }
    }

    private bool Find(int item, BSNode node)
    {
        if (node == null) return false;
        if (node.data == item)
        {
            return true;
        }
        else
        {
           if(item >= node.data)
           {
               return Find(item, node.RightChild);
           }
           else
           {
                return Find(item, node.LeftChild);
           }
        }
    }
}

public class BSNode
{
    public BSNode LeftChild { get; set; }
    public BSNode RightChild { get; set; }
    public BSNode Parent { get; set; }
    public int data { private set; get; } 

    public BSNode(int item)
    {
        this.data = item;
    }
}