using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

// player selection Manager
public class PlayerSelection : MonoBehaviour
{
    public Transform playerSwitcherTransform;
    public int playerSelectionNumber;
    public GameObject[] pollutantPlayerModels;


    [Header("UI")]
    public Button next_Button;
    public Button previous_Button;
    public TextMeshProUGUI playerPollutantType_Text;
    public GameObject ui_Selection;
    public GameObject ui_AfterSelection;










    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        ui_Selection.SetActive(true);
        ui_AfterSelection.SetActive(false);

        playerSelectionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region UI Callback Methods

    public void NextPlayer()
    {
        
        next_Button.enabled = false;
        previous_Button.enabled = false;

        playerSelectionNumber += 1;
        
        if (playerSelectionNumber >= pollutantPlayerModels.Length)
        {
            playerSelectionNumber = 0;
            
        }
        
        Debug.Log(playerSelectionNumber);
        pollutantnameTexthandler(playerSelectionNumber);
        StartCoroutine(Rotate(Vector3.up, playerSwitcherTransform, 90, 1.0f));
        


    }



    public void PreviousPlayer()
    {
        
        next_Button.enabled = false;
        previous_Button.enabled = false;
        playerSelectionNumber -= 1;

       
        
        if (playerSelectionNumber < 0)
        {
            playerSelectionNumber = pollutantPlayerModels.Length - 1;
            
        }
        
        Debug.Log(playerSelectionNumber);
        pollutantnameTexthandler(playerSelectionNumber);
        StartCoroutine(Rotate(Vector3.up, playerSwitcherTransform, -90, 1.0f));
        

        /* if (playerSelectionNumber == 0)
         {
             // pollutant 1 Carbon Mono Oxide

             playerPollutantType_Text.text = "CarbonMonoOxide";
         }
         else if (playerSelectionNumber == 1)
         {
             // pollutant 2 NitrogenOxide

             playerPollutantType_Text.text = "NitrogenOxide";
         }

         else if (playerSelectionNumber == 2)
         {
             // pollutant 3 SulfurDixide

             playerPollutantType_Text.text = "SulfurDixide";
         }
         else
         {
             // pollutant 4 ozone

             playerPollutantType_Text.text = "Ozone";
         }
        */

    }

    public void OnSelectButtonClicked()
    {
        ui_Selection.SetActive(false);
        ui_AfterSelection.SetActive(true);

        ExitGames.Client.Photon.Hashtable playerSelectionProp = new ExitGames.Client.Photon.Hashtable { {MultiplayerBreathARGame.PLAYER_POLLUTANT_SELECTION_NUMBER, playerSelectionNumber } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerSelectionProp);
    }

    public void OnReselectButtonClicked()
    {
        ui_Selection.SetActive(true);
        ui_AfterSelection.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_Lobby");
    }


   
    public void PlayButtonClicked()
    {
        // SceneManager.LoadScene("BreathARscene");
        SceneLoader.Instance.LoadScene("BreathARscene");
    }

    #endregion

    #region  Privatte Methods

    IEnumerator Rotate (Vector3 axis, Transform transformToRotate, float angle, float duration = 1.0f)
    {

        Quaternion originalRotation = transformToRotate.rotation;
        Quaternion finalRotation = transformToRotate.rotation * Quaternion.Euler(axis * angle);

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transformToRotate.rotation = Quaternion.Slerp(originalRotation, finalRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;

        }

        transformToRotate.rotation = finalRotation;
        next_Button.enabled = true;
        previous_Button.enabled = true;

    }


    private void pollutantnameTexthandler(int x)
    {
        if (x == 0)
        {
            // pollutant 1 Carbon Mono Oxide

            playerPollutantType_Text.text = "CarbonMonoOxide";
        }
        else if (x == 1)
        {
            // pollutant 2 NitrogenOxide

            playerPollutantType_Text.text = "NitrogenOxide";
        }

        else if (x == 2)
        {
            // pollutant 3 SulfurDixide

            playerPollutantType_Text.text = "SulfurDixide";
        }
        else
        {
            // pollutant 4 ozone

            playerPollutantType_Text.text = "Ozone";
        }
    } 


    #endregion


}
