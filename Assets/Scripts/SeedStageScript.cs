using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStageScript : MonoBehaviour
{
    public Sprite[] spriteStages;
    public int totalGrowDays = 0;
    private int currentStageID = 0;

    void Start()
    {
        SetSprite(currentStageID);
    }

    public void NextStage() 
    { 
        currentStageID++;
        SetSprite(currentStageID);
    }

    private void SetSprite(int value) 
    {
        int lastSprite = spriteStages.Length - 1;
        if (value < lastSprite)
        {
            currentStageID = value;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteStages[currentStageID];
        }
        else if (value == totalGrowDays)
        {
            currentStageID = lastSprite;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteStages[currentStageID];
        }
    }
}
