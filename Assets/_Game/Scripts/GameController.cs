using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}