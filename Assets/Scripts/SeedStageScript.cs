using System.Collections;
using System.Collections.Generic;
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
    private bool isWatered = false;
    private int currentStageID = 0;
    private int lastSpriteIndex = 0;

    private List<int> growNumbers = new List<int>();
    private int totalStages = 0;
    private int count = 0;
    void Start()
    {
        int currentGrowNumber = 0;

        // Total stages is equal to the length of the SeedStage array
        totalStages = seedStage.Length;

        // Set currentStage to 0
        SetSprite(currentStageID);

        for (int i = 0; i < seedStage.Length; i++)
        {
            // Create list of the growNumbers
            if (i >= 0 && i < seedStage.Length - 1)
            {
                if (seedStage[i].GrowDays == 0) 
                { 
                    currentGrowNumber += 1;
                }
                else 
                { 
                    currentGrowNumber += seedStage[i].GrowDays; 
                }
                
                growNumbers.Add(currentGrowNumber);
            }
        }

        lastSpriteIndex = totalStages - 1;
    }

    public void WaterSeed() 
    {
        if (currentStageID != lastSpriteIndex)
        {
            isWatered = true;
            SetSprite(currentStageID);
        }
    }
    public void NextStage() 
    {
        if (currentStageID < growNumbers.Count)
        {
            if (!isWatered)
            {
                Debug.Log("Plant: " + gameObject.name + " not watered");
                return;
            }

            count++;
            if (count == growNumbers[currentStageID])
            {
                currentStageID++;
            }
            else if (currentStageID == lastSpriteIndex)
            {
                currentStageID = lastSpriteIndex;
            }

            isWatered = false;
            SetSprite(currentStageID);
            
        }
    }

    private void SetSprite(int value)
    {
        Sprite newSprite = null;
        if (isWatered) 
        {
            newSprite = seedStage[value].seedSprite_Watered;
        }
        else
        {
            newSprite = seedStage[value].seedSprite_Default;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}