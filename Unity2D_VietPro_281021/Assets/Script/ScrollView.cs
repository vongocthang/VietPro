using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollView : MonoBehaviour
{
    public class item
    {
        public string anh;
        public string ten;
    }
    public GameObject btnDan;
    public ScrollRect scrollMenu;
    public Object[] mangAnh;

    // Start is called before the first frame update
    void Start()
    {
        List<item> danhSach = new List<item>();
        item _item;

        _item = new item();
        _item.anh = "1";
        _item.ten = "Dan loai 1";
        danhSach.Add(_item);

        _item = new item();
        _item.anh = "2";
        _item.ten = "Dan loai 2";

        danhSach.Add(_item);

        mangAnh = Resources.LoadAll("Textures", typeof(Texture2D));

        GameObject newbtnDan;
        Texture2D anhTimThay = null;
        foreach (item pt in danhSach)
        {
            newbtnDan = Instantiate(btnDan, scrollMenu.transform.GetChild(0).GetChild(0).transform, true) as GameObject;
            newbtnDan.SetActive(true);
            newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text = pt.ten;
            Debug.Log("OK");
            for(int i=0; i < mangAnh.Length; i++)
            {
                Debug.Log("Ten anh: " + mangAnh[i].name);
                Debug.Log("pt: " + pt.anh);
                if (mangAnh[i].name == pt.anh)
                {
                    anhTimThay = mangAnh[i] as Texture2D;
                    Rect rec = new Rect(0, 0, anhTimThay.width, anhTimThay.height);
                    Debug.Log("button: " + newbtnDan.transform.GetChild(1).name);
                    newbtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(anhTimThay, rec, new Vector2(0.5f, 0.5f), 100);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
