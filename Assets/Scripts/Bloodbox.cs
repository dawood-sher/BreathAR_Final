using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bloodbox : MonoBehaviour
{
    private float starthealth = 100;
    private float currethealth = 100;
    public Image pollutantHealthBar_image;
    public TextMeshProUGUI pollutanthealth_txt;
    public bool pollutantDeath = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OxygeninBlood();
    }

    public void OxygeninBlood()
    {
        if (currethealth <= 0)
        {
            pollutantDeath = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="oxygen")
        {
            Destroy(other.gameObject);
            currethealth = currethealth - 10;
            pollutantHealthBar_image.fillAmount = currethealth / starthealth;
            pollutanthealth_txt.text = currethealth + "/" + starthealth;
        }
    }

}
