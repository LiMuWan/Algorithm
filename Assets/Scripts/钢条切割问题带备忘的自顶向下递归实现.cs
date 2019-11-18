using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 钢条切割问题带备忘的自顶向下递归实现 : MonoBehaviour
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

        Debug.Log(UpDown(0, p, result));
        Debug.Log(UpDown(1, p, result));
        Debug.Log(UpDown(2, p, result));
        Debug.Log(UpDown(3, p, result));
        Debug.Log(UpDown(4, p, result));
        Debug.Log(UpDown(5, p, result));
        Debug.Log(UpDown(6, p, result));
        Debug.Log(UpDown(7, p, result));
        Debug.Log(UpDown(8, p, result));
        Debug.Log(UpDown(9, p, result));
    }

    private int UpDown(int n, int[] p,int[] result)//求得长度为n的最大收益
    {
        if (n == 0) return 0;
        int tempMaxPrice = 0;
        if (result[n] != 0) return result[n];
        for (int i = 1; i < n + 1; i++)
        {
            //p[i] + （n-i）的最大收益
            int maxPrice = p[i] + UpDown(n - i, p,result);
            if (maxPrice > tempMaxPrice)
            {
                tempMaxPrice = maxPrice;
            }
        }
        result[n] = tempMaxPrice;
        return tempMaxPrice;
    }
}
