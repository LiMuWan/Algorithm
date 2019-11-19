using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 背包问题穷举法 : MonoBehaviour
{
    private void Start()
    {
        int m;
        int[] w = { 0, 3, 4, 5 };
        int[] p = { 0, 4, 5, 6 };
        Debug.Log(Exhaustivity(10, w, p));
        Debug.Log(Exhaustivity(3, w, p));
        Debug.Log(Exhaustivity(4, w, p));
        Debug.Log(Exhaustivity(5, w, p));
        Debug.Log(Exhaustivity(7, w, p));
    }

    public int Exhaustivity(int m,int[] w,int[] p)
    {
        int i = w.Length - 1;//物品的个数

        int maxPrice = 0;
        for (int j = 0; j < Mathf.Pow(2,m); j++)
        {
            //取得 j 上某一个位的二进制值
            int weightTotal = 0;
            int priceTotal = 0;
            for (int number = 1; number <= i; number++)
            {
                int result = Get2(j, number);
                if(result == 1)
                {
                    weightTotal += w[number];
                    priceTotal += p[number];
                }
            }

            if(weightTotal <= m && priceTotal > maxPrice)
            {
                maxPrice = priceTotal;
            }
        }
        return maxPrice;
    }

    public int Get2(int j,int number)
    {
        int A = j;
        int B = (int)Mathf.Pow(2, number - 1);
        int result = A & B;
        if (result == 0)
            return 0;
        return 1;
    }
}
