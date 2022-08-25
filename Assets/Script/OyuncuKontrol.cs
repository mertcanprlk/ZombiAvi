using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrol : MonoBehaviour
{
    public AudioClip atisSesi, olmeSesi, canAlmaSesi, yaralanmaSesi;
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject Patlama;
    public Image canImaj;
    private float canDegeri = 100f;
    public oyunkontrol oKontrol;
    private AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Mouse0))
        {
            aSource.PlayOneShot(atisSesi, 1f);
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(Patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 50f;
            Destroy(go.gameObject, 2f);
            Destroy(goPatlama.gameObject, 2f);
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            aSource.PlayOneShot(yaralanmaSesi, 1f);
            Debug.Log("Zombie saldırıda");
            canDegeri -= 10f;
            float x = canDegeri / 100f;
            canImaj.fillAmount = canDegeri / 100f;
            canImaj.color = Color.Lerp(Color.red, Color.green, x);

            if (canDegeri <= 0)
            {
                aSource.PlayOneShot(olmeSesi, 1f);
                oKontrol.Oyunbitti();
            }
        }
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("Kalp"))
        {
            aSource.PlayOneShot(canAlmaSesi, 1f);
            if (canDegeri<100f)
            canDegeri += 10f;
                float x = canDegeri / 100f;
            canImaj.fillAmount = canDegeri / 100f;
            canImaj.color = Color.Lerp(Color.red, Color.green, x);
            Destroy(c.gameObject);
        }
    }
}
