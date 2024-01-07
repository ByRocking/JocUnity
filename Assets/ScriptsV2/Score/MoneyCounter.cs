using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public static MoneyCounter instance;
    public TextMeshProUGUI text;
    int count;

    void Start()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void ChangeCurrency(int moneyValue)
    {
        count += moneyValue;
        text.text = "x" + count.ToString();
    }
}
