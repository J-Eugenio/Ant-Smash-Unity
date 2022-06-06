using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{

    public TMP_Text txtScore, txtHighscore, txtFinalScore;
    public Image[] imageLifes;
    [SerializeField] private GameObject panelGame, panelPause, panelMainMenu, allLifes;
    public GameObject panelGameOver;
    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize(){
        panelMainMenu.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        txtHighscore.text = "Highscore: " + gameController.highScore.ToString();
    }

    public void ButtonStartGame(){
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonExitGame(){
        AndroidJavaObject activity = new AndroidJavaObject("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }
    public void UpdateScore(int score){
        txtScore.text = score.ToString();
    }

    public void ButtonPause(){
        Time.timeScale = 0f;
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
    }

    public void ButtonResume(){
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
    }

    public void ButtonBackMainMenu(){
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        gameController.BackMainMenu();
    }

    public void ButtonRestart(){
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        gameController.Restart();

        foreach (Transform child in allLifes.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
