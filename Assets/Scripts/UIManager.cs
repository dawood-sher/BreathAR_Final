using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

    public GameObject mainMenuUI;
    public GameObject inGameMenuUI;
    public GameObject gameOverMenuUI;
    public GameObject player;
    [SerializeField] private Bloodbox bloodbox;
    [SerializeField] private BattleScript battlescript;
    public TextMeshProUGUI gameResult_txt;
   





    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
        mainMenuUI.gameObject.SetActive(true);
        inGameMenuUI.gameObject.SetActive(false);
        gameOverMenuUI.gameObject.SetActive(false);
        battlescript = GameObject.Find("Player").GetComponent<BattleScript>();
        bloodbox = GameObject.Find("bloodbox").GetComponent<Bloodbox>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GameLogic();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // loads current scene
    }

    public void GameLogic()
    {
        if (battlescript.pollutantWon == true)
        {
            gameResult_txt.text = "You Won";
            GameOver();
            Debug.Log("you won");
        }
        else if (bloodbox.pollutantDeath == true)
        {
            gameResult_txt.text = "You Lose";
            GameOver();
            Debug.Log("You Lose");
        }

    }
    public void GameOver()
    {
        PauseGame();
        mainMenuUI.gameObject.SetActive(false);
        inGameMenuUI.gameObject.SetActive(false);
        gameOverMenuUI.gameObject.SetActive(true);
    }

    public void PlayButton()
    {
        ResumeGame();
        StartCoroutine(StartGame(1.0f));
    }

    public void PauseGameButton()
    {
        PauseGame();
        mainMenuUI.gameObject.SetActive(true);
        inGameMenuUI.gameObject.SetActive(false);
        gameOverMenuUI.gameObject.SetActive(false);

    }

    IEnumerator StartGame(float waitTime)
    {
        
        mainMenuUI.gameObject.SetActive(false);
        inGameMenuUI.gameObject.SetActive(true);
        gameOverMenuUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);     
    }




    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
