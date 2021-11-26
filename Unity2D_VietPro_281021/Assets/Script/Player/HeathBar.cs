using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    Slider slider;
    public int maxHeath;
    public int heath;

    // Start is called before the first frame update
    void Start()
    {
        slider = transform.GetChild(0).GetComponent<Slider>();
        slider.maxValue = maxHeath;
        slider.value = maxHeath;
        heath = maxHeath;
    }

    public void SetHeath(int damge)
    {
        heath -= damge;
        slider.value = heath;
    }
}
