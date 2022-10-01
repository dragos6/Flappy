using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private bool playerActive = false;
    private bool gameOver = false;

    public bool PlayerActive { get { return playerActive; } }
    public bool GameOver { get { return gameOver; } }

    private void Awake()
    {
        
        Singleton();

    }
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Singleton !!!
    /// </summary>
    private void Singleton()
    {
        if (instance == null) { instance = this; }  //Singleton
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerCollided()
    {
        gameOver = true;
    }

    public void PlayerStartGame()
    {
        playerActive = true;
    }
}
