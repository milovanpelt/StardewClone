using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStageScript : MonoBehaviour
{
    public Sprite[] stages;

    // Start is called before the first frame update
    void Start()
    {
        SetSprite(0);
    }

    public void Update()
    {
        
    }

    public void SetSprite(int value) 
    {
        if (value < stages.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[value];
        }
    }
}
