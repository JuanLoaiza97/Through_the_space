using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public Image progressIndicator;

    public TextMeshProUGUI progressText;

    public void UpdateBar(float currentValue, float totalValue)
    {
        float progressValue = currentValue / totalValue;
        progressIndicator.fillAmount = progressValue > 1 ? 1 : progressValue;
        if (progressText != null) 
        {
            progressText.text = Mathf.Round(progressIndicator.fillAmount * 100) + "%";
        }
    }
}
