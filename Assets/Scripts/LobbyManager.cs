using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

// This script is responsible for lobby operations like connecting to servers and loading player selection
public class LobbyManager : MonoBehaviourPunCallbacks
{
    [Header("Login UI")]  
    public InputField playerNameInputField;
    public GameObject ui_LoginGameObject;

    [Header("Lobby UI")]
    public GameObject ui_LobbyGameObject;
    public GameObject ui_CarbonBallGameObject;

    [Header("Connection Status UI")]
    public GameObject ui_ConnectionStatusGameObject;
    public Text connectionStatusText;
    public bool showConnectionStatus = false;


    #region UNITY Methods

    // Start is called before the first frame update
    void Start()
    {


        if (PhotonNetwork.IsConnected)
        {
            //Activating only lobby UI
            ui_LobbyGameObject.SetActive(true);
            ui_CarbonBallGameObject.SetActive(true);
            ui_ConnectionStatusGameObject.SetActive(false);
            ui_LoginGameObject.SetActive(false);
        }

        else
        {
            // activating only Login UI since we did not connect to photon yet

            ui_LobbyGameObject.SetActive(false);
            ui_CarbonBallGameObject.SetActive(false);
            ui_ConnectionStatusGameObject.SetActive(false);
            ui_LoginGameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
       if (showConnectionStatus)
        {
            connectionStatusText.text = "Connection Status" + " " + PhotonNetwork.NetworkClientState;
        }
        
    }


    #endregion


    #region UI Callback Methods
    
  /// <summary>
  /// This method is called on enter game button
  /// </summary>
    public void OnEnterGameButtonClicked()
    {
        


        string playerName = playerNameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            ui_LobbyGameObject.SetActive(false);
            ui_CarbonBallGameObject.SetActive(false);
            ui_ConnectionStatusGameObject.SetActive(true);
            ui_LoginGameObject.SetActive(false);
            showConnectionStatus = true;

            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
            }

        }

        else
        {
            Debug.Log("Player name is invalid");
        }
    }


    public void OnQuickMatchButtonClicked()
    {
        // SceneManager.LoadScene("Scene_Loading");
        SceneLoader.Instance.LoadScene("Scene_PlayerSelection");
            
    }

    #endregion

    #region PHOTON Callback Methods
    // first method call when we oress enter game
    public override void OnConnected()
    {
        Debug.Log("We connected to internet");
       // base.OnConnected();
    }

    // This method is called when player is successfully connected to photon server
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName +" " +"Is connnected to photon Server");
        ui_LobbyGameObject.SetActive(true);
        ui_CarbonBallGameObject.SetActive(true);
        ui_ConnectionStatusGameObject.SetActive(false);
        ui_LoginGameObject.SetActive(false);

        // base.OnConnectedToMaster();

    }

    #endregion



}
