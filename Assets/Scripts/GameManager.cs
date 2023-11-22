using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Screens
{
    IN_GAME,
    END_GAME,
    PAUSE_GAME
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject InGamePanel;
    [SerializeField] private GameObject PauseGamePanel;
    [SerializeField] private GameObject EndGamePanel;

    [SerializeField] private GameObject EndWinPanel;
    [SerializeField] private GameObject EndLosePanel;

    [SerializeField] private Text txtEndWin;
    [SerializeField] private Text txtRewardWin;

    [SerializeField] private Text txtEndLose;
    [SerializeField] private Text txtRewardLose;
    //[SerializeField] private GameObject PauseGamePanel;

    private GameObject currentScreen;

    [HideInInspector]
    public bool endgame;
    [HideInInspector]
    public bool isWin;

    private int countAllEnemy = 0;
    private int countEnemy = 0;
    private void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        countAllEnemy = GameObject.FindGameObjectsWithTag("Enemy").Count();
        endgame = false;
        isWin = false;
        currentScreen = InGamePanel;
    }

    // Update is called once per frame
    private void Update()
    {
        countEnemy = GameObject.FindGameObjectsWithTag("Enemy").Count();// số lượng enemy còn lại

        if (countEnemy == 0 && !isWin) {
            endgame= true;
        }

        if (endgame)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        endgame = false;


        if (countEnemy == 0)
        {
            int coinReward = (countAllEnemy * 10 + 50);
            txtEndWin.text += countAllEnemy;
            txtRewardWin.text += coinReward;
            PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") + coinReward));
            isWin = true;
        }
        else
        {
            int coinReward = ((countAllEnemy - countEnemy) * 5);
            txtEndLose.text += (countAllEnemy - countEnemy);
            txtRewardLose.text += coinReward;
            PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") + coinReward));
            isWin = false;
        }

        ChangeScreen(Screens.END_GAME);

    }
    public void ChangeScreen(Screens screen)
    {
        currentScreen.SetActive(false);
        switch (screen)
        {
            case Screens.IN_GAME:
                currentScreen = InGamePanel;
                break;
            case Screens.END_GAME:
                currentScreen = EndGamePanel;
                if (!isWin)
                {
                    EndLosePanel.SetActive(true);
                    EndWinPanel.SetActive(false);
                }
                else
                {
                    EndLosePanel.SetActive(false);
                    EndWinPanel.SetActive(true);
                }
                break;
            case Screens.PAUSE_GAME:
                currentScreen = PauseGamePanel;
                break;
        }
        currentScreen.SetActive(true);
    }

    public void PauseGame()
    {
        ChangeScreen(Screens.PAUSE_GAME);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        ChangeScreen(Screens.IN_GAME);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
