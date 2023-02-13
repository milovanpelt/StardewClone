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

    public void NextStage() 
    {
        if (currentStageID < growNumbers.Count)
        {
            count++;
            if (count == growNumbers[currentStageID])
            {
                currentStageID++;
            }
            else if (currentStageID == lastSpriteIndex)
            {
                currentStageID = lastSpriteIndex;
            }

            SetSprite(currentStageID);
        }
    }

    private void SetSprite(int value)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = seedStage[value].seedSprite;
    }
}