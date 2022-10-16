using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLife : MonoBehaviour
{
    public Image lifeIndicator;

    public void UpdateBarLife(float currentLife, float totalLife)
    {
        lifeIndicator.fillAmount = currentLife / totalLife;
    }
}
