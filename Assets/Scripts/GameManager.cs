using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject restartMenu;
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    public bool PlayerActive { get { return playerActive; } }
    public bool GameOver { get { return gameOver; } }
    public bool GameStarted { get { return gameStarted; } }

    private void Awake()
    {
        
        Singleton();
        Assert.IsNotNull(mainMenu);
        Assert.IsNotNull(restartMenu);
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
        gameStarted = false;
        //restartMenu.SetActive(true);
    }

    public void PlayerStartGame()
    {
        playerActive = true;
    }
    public void EnterGame()
    {
        //restartMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameStarted = true;
    }

    /*public void EnterMainMenu()
    {
        restartMenu.SetActive(false);
        mainMenu.SetActive(true);
        gameStarted = true;
    }*/
}
