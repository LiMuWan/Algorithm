using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 分治法解决最大子数组问题 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] priceArray = { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
        int[] priceFluctuationArray = new int[priceArray.Length - 1];

        for (int i = 1; i < priceFluctuationArray.Length; i++)
        {
            priceFluctuationArray[i] = priceArray[i] - priceArray[i - 1];
        }

        SubArray maxSubArray = GetMaxSubArray(0, priceFluctuationArray.Length - 1, priceFluctuationArray);
        Debug.Log(maxSubArray.startIndex);
        Debug.Log(maxSubArray.endIndex);
        Debug.Log("我们在第" + maxSubArray.startIndex + "天买入，在第" + (maxSubArray.endIndex + 1) + "天卖出");
    }

    struct SubArray
    {
        public int startIndex;
        public int endIndex;
        public int total;
    }

    private SubArray GetMaxSubArray(int low,int high,int[] array) //这个方法是用来取得array 这个数组从low到high之间的最大子数组
    {
        if(low == high)
        {
            SubArray subArray;
            subArray.startIndex = low;
            subArray.endIndex = high;
            subArray.total = array[low];
            return subArray;
        }

        int mid = (low + high) / 2; //低区间[low,mid],高区间[mid + 1,high]

        SubArray subArray1 = GetMaxSubArray(low, mid, array);
        SubArray subArray2 = GetMaxSubArray(mid + 1, high,array);

        //从[low,mid]找到最大子数组[i,mid]
        int total1 = array[mid];
        int startIndex = mid;
        int totalTemp = 0;
        for (int i = mid; i >= low; i--)
        {
            totalTemp += array[i];
            if(totalTemp > total1)
            {
                total1 = totalTemp;
                startIndex = i;
            }
        }
        //从[mid + 1,high]找到最大子数组[mid + 1,j]
        int total2 = array[mid + 1];
        int endIndex = mid + 1;
        for (int j = mid + 1; j <= high; j++)
        {
            totalTemp += array[j];
            if(totalTemp > total2)
            {
                total2 = totalTemp;
                endIndex = j;
            }
        }
        SubArray subArray3;
        subArray3.startIndex = startIndex;
        subArray3.endIndex = endIndex;
        subArray3.total = total1 + total2;
        if(subArray1.total >= subArray2.total && subArray1.total >= subArray3.total)
        {
            return subArray1;
        }
        else if(subArray2.total >= subArray1.total && subArray2.total >= subArray3.total)
        {
            return subArray2;
        }
        else
        {
           return subArray3;
        }
    }
}
