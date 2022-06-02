using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int highScore;
    [HideInInspector] public int enemyCount;
    private UIController uIController;
    public Transform allEnemiesParent;

    private Spawner spawner;
    // Start is called before the first frame update
    private void Awake() {
        uIController = FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
    }
    void Start()
    {
        highScore = 0;
        enemyCount = 0;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart(){
        highScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = highScore.ToString();

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartGame(){
        highScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = highScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
    }
}
