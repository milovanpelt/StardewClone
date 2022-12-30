using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SeedSpawnScript : MonoBehaviour
{
    public int rows = 0;
    public int colums = 0;
    public GameObject[] seeds;
    public Transform camera;

    void Awake()
    {
        GenerateField();
    }

    void GenerateField() 
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < colums; y++)
            {
                int randomSeedIndex = Random.Range(0, seeds.Length);

                float seedWidth = seeds[randomSeedIndex].GetComponent<SpriteRenderer>().sprite.rect.width;
                float seedHeight = seeds[randomSeedIndex].GetComponent<SpriteRenderer>().sprite.rect.height;

                float seedX = x;
                float seedY = y;

                Vector3 position = new Vector3(seedX, seedY, transform.position.z);

                var spawnedSeed = Instantiate(seeds[randomSeedIndex], position, Quaternion.identity);
            }
        }

        camera.transform.position = new Vector3((float)rows / 2 - 0.5f, (float)colums / 2 - 0.5f, -10);
    }
}
