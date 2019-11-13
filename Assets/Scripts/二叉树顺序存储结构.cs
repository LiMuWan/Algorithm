using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 二叉树顺序存储结构 : MonoBehaviour
{
    private void Start()
    {
        char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };//这个是我们要存储的数据
        BiTree<char> tree = new BiTree<char>(10);
        for (int i = 0; i < data.Length; i++)
        {
            tree.Add(data[i]);
        }
        //先序遍历
        tree.FirstTraversal();
        //中序遍历
        tree.MiddleTraversal();
        //后序遍历
        tree.LastTraversal();
        //层级遍历
        tree.LastTraversal();
    }
}

//如果一个节点是空的话，那么这个节点所在的数组位置，设置为-1
public class BiTree<T>
{
    private T[] data;
    private int count = 0;

    public BiTree(int capacity)//这个参数是当前二叉树的容量，容量就是最多可以存储的数据个数，数量count代表当前保存了多少数据
    {
        data = new T[capacity];
    }

    public bool Add(T item)
    {
        if (count >= data.Length)
            return false;
        data[count] = item;
        count++;
        return true;
    }

    public void FirstTraversal()
    {
        FirstTraversal(0);
    }

    private void FirstTraversal(int index)
    {
        if (index >= count) return;

        //得到要遍历的这个节点的编号
        int number = index + 1;
        if (data[index].Equals(-1)) return;
        Debug.Log(data[index] + " ");
        //得到搭配左子节点的编号
        int leftNumber = number * 2;
        int rightNumber = number * 2 + 1;
        FirstTraversal(leftNumber - 1);
        FirstTraversal(rightNumber - 1);
    }

    public void MiddleTraversal()
    {
        MiddleTraversal(0);
    }

    private void MiddleTraversal(int index)
    {
        if (index >= count) return;

        //得到要遍历的这个节点的编号
        int number = index + 1;
        if (data[index].Equals(-1)) return;
        //得到搭配左子节点的编号
        int leftNumber = number * 2;
        Debug.Log(data[index] + " ");
        int rightNumber = number * 2 + 1;
        MiddleTraversal(leftNumber - 1);
        MiddleTraversal(rightNumber - 1);
    }

    public void LastTraversal()
    {
        LastTraversal(0);
    }

    private void LastTraversal(int index)
    {
        if (index >= count) return;

        //得到要遍历的这个节点的编号
        int number = index + 1;
        if (data[index].Equals(-1)) return;
        //得到搭配左子节点的编号
        int leftNumber = number * 2;
        int rightNumber = number * 2 + 1;
        LastTraversal(leftNumber - 1);
        LastTraversal(rightNumber - 1);
        Debug.Log(data[index] + " ");
    }

    public void LayerTraversal()
    {
        for (int i = 0; i < count; i++)
        {
            if (data[i].Equals(-1)) continue;
            Debug.Log(data[i] + " ");
        }
    }
}