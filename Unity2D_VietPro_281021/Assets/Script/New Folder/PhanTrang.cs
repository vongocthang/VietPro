using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhanTrang : MonoBehaviour
{
    public Color color;//Màu sắc của level đã hoàn thành
    public Color lockColor;//Màu sắc của level đang bị khóa
    public Color unlockColor;//Màu sắc của level đã được mở khóa, nhưng chưa hoàn thành
    public GameObject sample;//Mẫu thiết kế level
    public int levelNumber;//Số level hiện có của game
    public int levelUnlock;//Level đã mở khóa

    public GameObject[] level;
    public int inPage;//Đang ở trang thứ mấy - 12 level / 1 trang

    // Start is called before the first frame update
    void Start()
    {
        level = new GameObject[50];
        for(int i=1; i<=levelNumber; i++)
        {
            level[i-1] =  Instantiate(sample, this.transform.GetChild(0).GetChild(0).transform, true);
            level[i-1].transform.GetChild(0).GetComponent<TMP_Text>().text = i.ToString();
            if (i < levelUnlock)
            {
                level[i - 1].GetComponent<Image>().color = color;
            }
            if (i == levelUnlock)
            {
                level[i - 1].GetComponent<Image>().color = unlockColor;
            }
            if (i > levelUnlock)
            {
                level[i - 1].GetComponent<Image>().color = lockColor;
            }
        }

        Destroy(sample);

        ShowPageHaveLevelUnlcok();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPageHaveLevelUnlcok()
    {
        int pageNumberBefor = (levelUnlock / 12);
        //Debug.Log(pageNumberBefor);
        inPage = pageNumberBefor + 1;
        for(int i = 0; i < pageNumberBefor * 12; i++)
        {
            level[i].SetActive(false);
        }
    }

    public void NextPage()
    {
        if (inPage < levelNumber / 12 + 1)
        {
            Debug.Log("Buoc 1");
            for (int i = (inPage - 1) * 12; i < (inPage - 1) * 12 + 12; i++)
            {
                Debug.Log("Buoc 2");
                level[i].SetActive(false);
                
                //this.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);
            }
            inPage++;
        }
    }

    public void BackPage()
    {
        if (inPage > 1)
        {
            Debug.Log("Buoc 1");
            for (int i = (inPage - 2) * 12; i <= (inPage - 1) * 12; i++)
            {
                Debug.Log("Buoc 2");
                level[i].SetActive(true);
                
            }
            inPage--;
        }
    }
}
