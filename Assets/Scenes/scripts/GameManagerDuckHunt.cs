using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class GameManagerDuckHunt : MonoBehaviour
{
    private int score;
    public TMP_Text scoreText;
    public Button startButton;
    public TMP_Text buttonLabel;
    public TMP_Text highScoreText;
    public TMP_Text timeText;

    public TMP_Text label;

    public Player player;
    private bool gameIsRunning = false;
    private float maxGameTime = 50f;
    private int highScore = 0;

    private float currentGameTime;
    [SerializeField] private SpawnDucks spawnDucks;
    public AudioClip[] audioClips;


    public void Start()
    {
        highScoreText.enabled = false;
        label.enabled = true;
        label.text = "Welcome to the game, faster dog worth more points.";
        player.gameObject.SetActive(false);
        scoreText.enabled = false;
        buttonLabel.text = "Start Game";


        startButton.onClick.AddListener(OnButtonClick);

    }
    private void OnButtonClick()
    {
        if (!gameIsRunning)
        {
            startButton.gameObject.SetActive(false);
            StartGame();
        }
        else
        {
            EndGame(); // optional: make it restart when clicked during game
        }
    }
    void Update()
    {
        if (!gameIsRunning) return;

        // countdown timer

        timeText.text = "Time Left: " + Mathf.Max(0, (int)currentGameTime);
        currentGameTime -= Time.deltaTime;
        if (currentGameTime <= 0)
        {
            EndGame();
        }
    }
    private void StartGame()
    {
        //starting all the buttons and the scoreboard.
        currentGameTime = maxGameTime;
        label.enabled = false;
        player.gameObject.SetActive(true);
        player.isStarted = true;
        gameIsRunning = true;
        score = 0;
        player.StartGame();

        spawnDucks.gameIsRunning = true;
        spawnDucks.StartGame();
        scoreText.enabled = true;
        scoreText.text = "Your Score is: " + score.ToString();
        highScoreText.enabled = false;
        startButton.interactable = false;
    }
    private void EndGame()
    {
        //closing the score and activate the button again.
        gameIsRunning = false;
        player.isStarted = false;
        player.gameObject.SetActive(false);
        spawnDucks.EndGame();
        scoreText.enabled = false;


        if (score > highScore)
            highScore = score;

        highScoreText.text = "High Score: " + highScore;
        highScoreText.enabled = true;

        startButton.gameObject.SetActive(true);
        startButton.interactable = true;
        buttonLabel.text = "Restart Game";

    }
    // increases score and is called by the Duck script
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = "Your Score is: " + score.ToString();
    }

    public int GetScore() => score;


}
