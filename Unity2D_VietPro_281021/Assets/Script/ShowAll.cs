using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowAll : MonoBehaviour
{
    public TMP_Text showCoin;


    // Start is called before the first frame update
    void Start()
    {
        showCoin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
