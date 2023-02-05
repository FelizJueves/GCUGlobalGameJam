using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform SpawnArea;
    public Plane MyArea;
    public GameObject Enemy;
    public int EnemyCount;

    public float WaveTimer = 60f;
    public int WavesRemaining = 3;

    public float MaxX;
    public float MinX;

    public float MaxZ;
    public float MinZ;

    // Start is called before the first frame update

    Vector3 Size;
    void Start()
    {
        Size = SpawnArea.GetComponent<Renderer>().bounds.size;
        Debug.Log(SpawnArea.localScale);
        MaxX = Size.x / 2;
        MinX = (Size.x / 2) * -1;

        MaxZ = Size.z / 2;
        MinZ = (Size.z / 2) * -1;

        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            float LocationX;
            float LocationZ;

            LocationX = Random.Range(MinX, MaxX);
            LocationZ = Random.Range(MinZ, MaxZ);
            Instantiate(Enemy, new Vector3(LocationX, 1, LocationZ), Quaternion.identity);
        }
    }
    private void Update()
    {
        WaveTimer -= Time.deltaTime;
        if (WaveTimer <= 0 && WavesRemaining > 1)
        {
            SpawnEnemies();
            WaveTimer = 60f;
        }
    }
}
