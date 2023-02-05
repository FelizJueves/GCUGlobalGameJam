using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public enum LevelEnum {Level1, Level2, Level3, Level4, HubWorld}
    public LevelEnum Level;

    int enemiesRemaining;
    int Score;

    public void setEnemiesRemaining(int enemiesRemaining) {
        this.enemiesRemaining = enemiesRemaining;
    }

    public void decrementEnemies() {
        this.enemiesRemaining--;
    }

    public int getScore() {
        return Score;
    }

    void Update() {
        Debug.Log(this.enemiesRemaining);
        if(this.enemiesRemaining == 0) {
            SceneController.sceneController.gameObject.SetActive(true);
        }
    }

    void Start() {
        SceneController.sceneController.gameObject.SetActive(false);
    }

    void Awake()
    {
        gameController = this;
        Score = 0;
        Scene CurrentScene = SceneManager.GetActiveScene();
        
        if (CurrentScene.name == "Level1")
        {
            Level = LevelEnum.Level1;
            Debug.Log(Level);
        }
        else if (CurrentScene.name == "Level2")
        {
            Level = LevelEnum.Level2;
            Debug.Log(Level);
        }
        else if (CurrentScene.name == "Level3")
        {
            Level = LevelEnum.Level3;
            Debug.Log(Level);
        }
        else if (CurrentScene.name == "Level4")
        {
            Level = LevelEnum.Level4;
        }
        else if (CurrentScene.name == "HubWorld")
        {
            Level = LevelEnum.HubWorld;
            Debug.Log(Level);
        }
    }

    public void UpdateScore(int KillScore)
    {
        Score = Score + KillScore;
        Debug.Log(Score);
    }
}
