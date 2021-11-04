using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuanLyPhong : MonoBehaviour
{
    public Transform contentTransform;
    public GameObject tempplateContent;
    public int countRoom = 1;
    public int quantilyRoom;

    public string inputRoomName;
    public string inputPassWord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateRoom(quantilyRoom);
    }

    public void CreateRoom(int quantily)
    {
        while (countRoom <= quantily)
        {
            GameObject phong = Instantiate(tempplateContent, contentTransform);
            phong.SetActive(true);
            if (countRoom < 10)
            {
                phong.transform.GetChild(0).GetComponent<TMP_Text>().text = "ID: 0" + (countRoom).ToString();
            }
            else
            {
                phong.transform.GetChild(0).GetComponent<TMP_Text>().text = "ID: " + (countRoom).ToString();
            }
            phong.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => 
            JoinRoom(int.Parse(phong.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(4, 2))));

            countRoom++;
        }
    }

    public void JoinRoom(int idRoom)
    {
        Debug.Log("Vao phong: " + idRoom);
    }

    public void ReadStringInputRoomName(string s)
    {
        inputRoomName = s;
    }

    public void ReadStringInputPassWord(string s)
    {
        inputPassWord = s;
    }

    public void ShowStringInput()
    {
        Debug.Log("Ten phong: " + inputRoomName);
        Debug.Log("Mat khau: " + inputPassWord);

        GameObject phong = Instantiate(tempplateContent, contentTransform);
        phong.SetActive(true);
        if (countRoom < 10)
        {
            phong.transform.GetChild(0).GetComponent<TMP_Text>().text = "ID: 0" + (countRoom).ToString() + " Ten Phong: " + inputRoomName;
        }
        else
        {
            phong.transform.GetChild(0).GetComponent<TMP_Text>().text = "ID: " + (countRoom).ToString() + "Ten Phong: " + inputRoomName;
        }
        phong.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => 
        JoinRoom(int.Parse(phong.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(4, 2))));

        countRoom++;
    }
}
