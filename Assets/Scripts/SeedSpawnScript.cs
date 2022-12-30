using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawnScript : MonoBehaviour
{
    public int colums = 0;
    public int rows = 0;
    public GameObject tileObject;

    void Awake()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < colums; y++)
            {
                Vector3 position = new Vector3(x + transform.position.x, y - 2, transform.position.z);
                Instantiate(tileObject, position, transform.rotation);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
