using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData PD;
    //public bool[] AllSkins;
    //public int MySkin;
    public string NewSkins;
    public void OnEnable()
    {
        PD = this;
    }
    public void SkinsStringToData(string value)
    {
        Debug.Log("value skins:" + value);
        for(int i=0;i<value.Length;i++)
        {
            if(int.Parse(value[i].ToString())>0)
            {
                Debug.Log(value[i].ToString() + "---> true");
            }
            else
            {
                Debug.Log(value[i].ToString() + "---> false");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
