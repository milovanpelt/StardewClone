using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SeedStage
{
    public Sprite seedSprite;
    public int GrowDays;
}

public class SeedStageScript : MonoBehaviour
{
    public SeedStage[] seedStage;
    private int currentStageID = 0;
    private int totalGrowDay = 0;
    private int lastSprite = 0;

    void Start()
    {
        SetSprite(currentStageID);

        // Set totalGrowDay for each seed
        for (int i = 0; i < seedStage.Length; i++)
        {
            totalGrowDay += seedStage[i].GrowDays;
        }

        lastSprite = seedStage.Length - 1;
    }

    public void NextStage() 
    { 
        currentStageID++;
        SetSprite(currentStageID);
    }

    private void SetSprite(int value) 
    {
        if (value < lastSprite)
        {
            currentStageID = value;
            gameObject.GetComponent<SpriteRenderer>().sprite = seedStage[currentStageID].seedSprite;
        }
        else if (value == totalGrowDay)
        {
            currentStageID = lastSprite;
            gameObject.GetComponent<SpriteRenderer>().sprite = seedStage[currentStageID].seedSprite;
        }
    }
}