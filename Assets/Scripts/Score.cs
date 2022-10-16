using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreValue;
    private void Start()
    {
        scoreValue.text = "0";
    }

    public void UpdateIndicator(int value)
    {
        scoreValue.text = value.ToString();
    }
}
