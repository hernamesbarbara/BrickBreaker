using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // configs
    [SerializeField] TextMeshProUGUI scoreText;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;
    [SerializeField] int pointsPerBrick = 10;

    // current game state variables
    [SerializeField] int currentScore = 0;

    void Awake() {
        int gameSessionsCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionsCount>1) {
            ResetGame();
        } 
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start() {
        gameSpeed = 1f;
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
    }

    public void UpdateCurrentScore() {
        currentScore += pointsPerBrick;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
