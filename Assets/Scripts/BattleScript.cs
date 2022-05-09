using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BattleScript : MonoBehaviour
{
  //  public OxygenLevel oxygenLevelScript;

    private float startOxygenLevel=100;
    private float currentOxygenLevel=100;
    public Image oxygenLevelBar_image;
    public TextMeshProUGUI oxygenlevelratio_txt;
    public bool pollutantWon=false;

    private void Awake()
    {

      //  startOxygenLevel = oxygenLevelScript.optimalOxygenQuantity;
     //   currentOxygenLevel = oxygenLevelScript.optimalOxygenQuantity;
     //   oxygenLevelBar_image.fillAmount = currentOxygenLevel / startOxygenLevel;
    }


    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NoOxygen();
    }

    public void NoOxygen()
    {
        if (currentOxygenLevel <= 0)
        {
            pollutantWon = true;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("oxygen"))
        {
            Destroy(collision.gameObject);
            currentOxygenLevel = currentOxygenLevel- 10;
            oxygenLevelBar_image.fillAmount = currentOxygenLevel / startOxygenLevel;
            oxygenlevelratio_txt.text = currentOxygenLevel + "/" + startOxygenLevel;
        }

    }

    
}
