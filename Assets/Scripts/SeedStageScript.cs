using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStageScript : MonoBehaviour
{
    public Sprite[] stages;
    private int currentStageID = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetSprite(currentStageID);
    }

    void Update()
    {
        
    }
    public void SetSprite(int value) 
    {
        currentStageID = value;
        if (currentStageID < stages.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[currentStageID];
        }
    }
}
