using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameController gameController;
    private UIController uIController;
    private void Start() {
        gameController = FindObjectOfType<GameController>();
        uIController = FindObjectOfType<UIController>();
    }
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Enemy")){
            gameController.enemyCount++;

            if(gameController.enemyCount < 5){
                uIController.imageLifes[gameController.enemyCount - 1].gameObject.SetActive(false);
            }else {
                uIController.imageLifes[4].gameObject.SetActive(false);
                Debug.Log("Game Over");
            }
            Destroy(target.gameObject);
        }
    }
}
