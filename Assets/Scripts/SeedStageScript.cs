using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStageScript : MonoBehaviour
{
    public Sprite[] stages;
    public int totalGrowDays = 0;
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
        if (value < stages.Length - 1)
        {
            currentStageID = value;
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[currentStageID];
        }
        else if (value == totalGrowDays)
        {
            currentStageID = stages.Length - 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = stages[currentStageID];
        }
    }
}
