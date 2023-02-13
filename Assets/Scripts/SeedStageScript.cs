using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct SeedStage
{
    public Sprite seedSprite_Default;
    public Sprite seedSprite_Watered;
    public int GrowDays;
}

public class SeedStageScript : MonoBehaviour
{
    public SeedStage[] seedStage;
    private int currentStageIndex = 0;
    private int lastStageIndex = 0;

    private bool isWatered = false;
    private int daysPassed = 0;

    void Start()
    {
        // Set current sprite (default)
        SetSprite(seedStage[currentStageIndex].seedSprite_Default);

        // Set last stage index
        lastStageIndex = seedStage.Length - 1;
    }

    public void WaterSeed() 
    {
        // Only water if the last stage has not been reached
        if (currentStageIndex != lastStageIndex)
        {
            isWatered = true;
            SetSprite(seedStage[currentStageIndex].seedSprite_Watered);
        }
    }
    public void NextStage() 
    {
        // Do nothing if seed is not watered
        if (!isWatered) 
        {
            return;
        }

        // Check if days that passed equals the days of growth for each stage
        daysPassed++;
        if (daysPassed == seedStage[currentStageIndex].GrowDays) 
        {

            currentStageIndex++;

            // Reset daysPassed 
            daysPassed = 0;
        }

        // Reset seeds being watered
        isWatered = false;
        SetSprite(seedStage[currentStageIndex].seedSprite_Default);
    }

    private void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}