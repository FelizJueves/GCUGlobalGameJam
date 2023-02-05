using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum LevelEnum {Level1, Level2, Level3, Level4, HubWorld}
    public LevelEnum Level;

    public GameObject[] enemies;

    public void setEnemyType(GameObject enemyObject) {
        int intLevel = (int) Level;
        enemyObject.GetComponent<MeshFilter>().mesh = enemies[intLevel].GetComponent<MeshFilter>().sharedMesh;
        enemyObject.GetComponent<MeshRenderer>().materials = enemies[intLevel].GetComponent<MeshRenderer>().sharedMaterials;
        enemyObject.GetComponent<MeshCollider>().sharedMesh = enemyObject.GetComponent<MeshFilter>().sharedMesh;
        enemyObject.transform.localScale = enemies[intLevel].transform.localScale;
    }

    void Awake()
    {
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
}
