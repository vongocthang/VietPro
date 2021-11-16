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
    List<item> danhSach = new List<item>();
    public item _item;

    public GameObject btnDan;
    
    public ScrollRect scrollMenu;
    public Object[] mangAnh;
    

    public Image showImage;
    public int countImageShow;
    //public GameObject btnShowImage;

    // Start is called before the first frame update
    void Start()
    {
        

        mangAnh = Resources.LoadAll("Textures", typeof(Texture2D));

        for(int i=0; i<mangAnh.Length; i++)
        {
            _item = new item();
            _item.anh = mangAnh[i].name.ToString();
            _item.ten = "Dan loai 0" + mangAnh[i].name.ToString();
            danhSach.Add(_item);
        }

        
        Texture2D anhTimThay = null;
        for (int i=0; i<2; i++)
        {
            GameObject newbtnDan;

            newbtnDan = Instantiate(btnDan, scrollMenu.transform.GetChild(0).GetChild(0).transform, true) as GameObject;
            newbtnDan.SetActive(true);
            newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text = danhSach[i].ten;
            //Debug.Log("OK");
            for(int j=0; j < mangAnh.Length; j++)
            {
                //Debug.Log("Ten anh: " + mangAnh[j].name);
                //Debug.Log("pt: " + danhSach[i].anh);
                if (mangAnh[j].name == danhSach[i].anh)
                {
                    anhTimThay = mangAnh[j] as Texture2D;
                    Rect rec = new Rect(0, 0, anhTimThay.width, anhTimThay.height);
                    //Debug.Log("button: " + newbtnDan.transform.GetChild(1).name);
                    newbtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(anhTimThay, rec, new Vector2(0.5f, 0.5f), 100);

                    newbtnDan.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
                    ZoomBigImage(int.Parse(newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(9, 2))));
                    Debug.Log(int.Parse(newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(9, 2)));

                    break;
                }
            }
        }
        countImageShow = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNew()
    {
        Texture2D anhTimThay = null;
        GameObject newbtnDan;

        newbtnDan = Instantiate(btnDan, scrollMenu.transform.GetChild(0).GetChild(0).transform, true) as GameObject;
        newbtnDan.SetActive(true);
        newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text = danhSach[countImageShow].ten;
        //Debug.Log("OK");
        for (int j = 0; j < mangAnh.Length; j++)
        {
            //Debug.Log("Ten anh: " + mangAnh[j].name);
            //Debug.Log("pt: " + danhSach[countImageShow].anh);
            if (mangAnh[j].name == danhSach[countImageShow].anh)
            {
                anhTimThay = mangAnh[j] as Texture2D;
                Rect rec = new Rect(0, 0, anhTimThay.width, anhTimThay.height);
                //Debug.Log("button: " + newbtnDan.transform.GetChild(1).name);
                newbtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(anhTimThay, rec, new Vector2(0.5f, 0.5f), 100);

                newbtnDan.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
                    ZoomBigImage(int.Parse(newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(9, 2))));
                Debug.Log(int.Parse(newbtnDan.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(9, 2)));

                break;
            }
        }
        countImageShow++;
    }

    public void RemoveButton()
    {
        for(int i=scrollMenu.transform.GetChild(0).GetChild(0).childCount-1; i>=0;i--)
        {
            Destroy(scrollMenu.transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
            break;
        }
       // GameObject[] mangButton;
       /* mangButton = GameObject.FindGameObjectsWithTag("Respawn");
        int max = 0;
        int location = 0;
        for(int i=0; i<mangButton.Length; i++)
        {
            int a = int.Parse(mangButton[i].transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(9, 2));
            if (a > max)
            {
                max = a;
                location = i;
            }
        }

        Destroy(mangButton[location]);

        countImageShow--;*/
    }

    public void ZoomBigImage(int idImage)
    {
        Debug.Log("Show anh " + mangAnh[idImage - 1].name);
        Texture2D anhCanShow = mangAnh[idImage - 1] as Texture2D;

        Rect rec = new Rect(0, 0, anhCanShow.width, anhCanShow.height);
        showImage.sprite = Sprite.Create(anhCanShow, rec, new Vector2(0.5f, 0.5f), 100);
        
    }
}
