using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunkontrol : MonoBehaviour
{
    public GameObject zombie;
    public Text puanText;
    private int puan;
    private float zamanSayaci;
    private float olusumSureci = 5f;
    // Start is called before the first frame update
    void Start()
    {
        zamanSayaci = olusumSureci;
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci <0)
        {
            Vector3 pos = new Vector3(Random.Range(198, 341), -48f, Random.Range(258, 102));
            Instantiate(zombie, pos, Quaternion.identity);
            zamanSayaci = olusumSureci; 
        }
    }
    public void PuanArttir(int p)
    {
        puan += p;
        puanText.text = "" + puan;
    }

    public void Oyunbitti()
    {
        PlayerPrefs.SetInt("puan", puan);
        SceneManager.LoadScene("Oyunbitti");
    }
}
