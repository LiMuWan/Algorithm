using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 求一段时间内的价格波动的最大值,计算应该在哪一天买入，哪一天卖出
/// </summary>
public class 暴力求解法 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        暴力求解();
    }

    private void 暴力求解()
    {
        int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
        int[] priceFluctuationArray = new int[priceArray.Length - 1];

        for (int i = 1; i < priceFluctuationArray.Length; i++)
        {
            priceFluctuationArray[i] = priceArray[i] - priceArray[i - 1];
        }
        //默认数组的第一个元素 是最大子数组
        int total = priceFluctuationArray[0];
        int startIndex = 0;
        int endIndex = 0;

        for (int i = 0; i < priceFluctuationArray.Length; i++)
        {
            //取得以i为子数组起点的所有子数组
            for (int j = i; j < priceFluctuationArray.Length; j++)
            {
                //由i,j确定了一个子数组
                int totalTemp = 0;//临时最大子数组的和
                for (int index = i; index < j + 1; index++)
                {
                    totalTemp += priceFluctuationArray[index];
                }
                if (totalTemp > total)
                {
                    total = totalTemp;
                    startIndex = i;
                    endIndex = j;
                }
            }
        }

        Debug.Log("startIndex : " + startIndex);
        Debug.Log("endIndex : " + endIndex);
        Debug.Log("购买日期是第" + startIndex + "天 ， 出售应该是第" + (endIndex + 1) + "天");
    }


}
