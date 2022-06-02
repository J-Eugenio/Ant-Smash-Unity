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
    // Start is called before the first frame update
    void Start()
    {
        highScore = 0;
        enemyCount = 0;
        uIController = FindObjectOfType<UIController>();
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
}
