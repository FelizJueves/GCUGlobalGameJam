using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum LevelEnum {Level1, Level2, Level3, Level4, HubWorld}
    public LevelEnum Level;

    public GameObject level1Mesh;
    public GameObject level2Mesh;
    public GameObject level3Mesh;
    public GameObject level4Mesh;

    public Mesh getEnemyMesh() {
        Mesh[] meshes = new Mesh[]{
            level1Mesh.GetComponent<MeshFilter>().mesh,
            level2Mesh.GetComponent<MeshFilter>().mesh,
            level3Mesh.GetComponent<MeshFilter>().mesh,
            level4Mesh.GetComponent<MeshFilter>().mesh,
            null
        };
        return meshes[(int) Level];
    }

    // Start is called before the first frame update
    void Start()
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
