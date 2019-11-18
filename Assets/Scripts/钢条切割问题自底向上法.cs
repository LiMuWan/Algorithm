using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 钢条切割问题自底向上法 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //int n = 5;//我们要切割售卖的钢条的长度
        //使用价格表，价格表有一个条件：价格表的长度不能小于n，就是说n有多少个，
        //价格表长度就得有多少个，因为n要使用下面的价格表，我们长度为n,那么我们
        //长度为n的价格表必须有，那小于n的这个价格表也必须有。
        int[] result = new int[11];
        int[] p = new int[] { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表钢条的长度,值代表价格 

        Debug.Log(BottomUp(0, p, result));
        Debug.Log(BottomUp(1, p, result));
        Debug.Log(BottomUp(2, p, result));
        Debug.Log(BottomUp(3, p, result));
        Debug.Log(BottomUp(4, p, result));
        Debug.Log(BottomUp(5, p, result));
        Debug.Log(BottomUp(6, p, result));
        Debug.Log(BottomUp(7, p, result));
        Debug.Log(BottomUp(8, p, result));
        Debug.Log(BottomUp(9, p, result));
    }

    private int BottomUp(int n,int[] p,int[] result)
    {
        for (int i = 1; i < n + 1; i++)
        {
            //下面取得 钢条长度为i的时候的最大收益
            int tempMaxPrice = -1;
            for (int j = 0; j <= i; j++)
            {
                int maxPrice = p[j] + result[i - j];
                if(maxPrice > tempMaxPrice)
                {
                    tempMaxPrice = maxPrice;
                }
            }
            result[i] = tempMaxPrice;
        }

        return result[n];
    }
}
