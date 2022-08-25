using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyunbitti : MonoBehaviour
{
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        puan.text ="Puanınız:" +PlayerPrefs.GetInt("puan");
    }

    // Update is called once per frame
    public void yenidenoyna()
    {
        SceneManager.LoadScene("oyun");
    }
}
