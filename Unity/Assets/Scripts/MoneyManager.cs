using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int cointCount;
    public TMP_Text coinText;

    private void Update()
    {
        coinText.text=cointCount.ToString();
    }
}
