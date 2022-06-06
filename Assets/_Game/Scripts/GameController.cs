using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore, enemyCount, highScore;
    private UIController uIController;
    public Transform allEnemiesParent;

    private Spawner spawner;
    private Destroyer destroyer;
    [SerializeField] private AudioSource music;
    // Start is called before the first frame update
    private void Awake() {
        uIController = FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
        destroyer = FindObjectOfType<Destroyer>();
        highScore = GetScore();
    }
    void Start()
    {
        totalScore = 0;
        enemyCount = 0;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        music.volume = 0.5f;
    }

    public void GameOver(){
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        uIController.txtFinalScore.text = "Score: " + totalScore.ToString();

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void DestroyEnemy(Collider2D target){
        enemyCount++;

        if(enemyCount < 5){
            uIController.imageLifes[enemyCount - 1].gameObject.SetActive(false);
        }else {
            uIController.imageLifes[4].gameObject.SetActive(false);
            uIController.panelGameOver.gameObject.SetActive(true);
            GameOver();
            SaveScore();
        }
        Destroy(target.gameObject);
    }
    public void Restart(){
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartGame(){
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
        music.volume = 0.25f;
    }

    public void BackMainMenu(){
        music.volume = 0.5f;
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;

        for (int i = 0; i < uIController.imageLifes.Length; i++)
        {
            uIController.imageLifes[i].gameObject.SetActive(true);
        }

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void  SaveScore(){
        if(totalScore > highScore){
            PlayerPrefs.SetInt("@HighScore", totalScore);
        }
    }

    public int  GetScore(){
        highScore = PlayerPrefs.GetInt("@HighScore");
        return highScore;
    }
}
