using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
using UnityEngine.Windows;


#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct SeedStage
{
    public Sprite seedSprite_Default;
    public Sprite seedSprite_Watered;
    public int GrowDays;
}


[System.Serializable]
public enum Season
{
    Spring,
    Summer,
    Fall,
    Winter
}

public class SeedStageScript : MonoBehaviour
{
    public Season seasons;
    public SeedStage[] seedStage;

    // Regrow variables
    [HideInInspector]
    public bool canRegrow = false;
    
    [HideInInspector]
    public Sprite RegrowSprite_Default;

    [HideInInspector]
    public Sprite RegrowSprite_Watered;

    [HideInInspector]
    public int RegrowDays;

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

#if UNITY_EDITOR
[CustomEditor(typeof(SeedStageScript))]
public class RandomScript_Editor : Editor
{
    SerializedObject stage;

    public override void OnInspectorGUI()
    {
     

        DrawDefaultInspector(); // for other non-HideInInspector fields

        SeedStageScript script = (SeedStageScript)target;

        // draw checkbox for the bool
        script.canRegrow = EditorGUILayout.Toggle("Can regrow", script.canRegrow);
        if (script.canRegrow) // if bool is true, show other fields
        {
            // (Default) Regrow sprite field
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("RegrowSprite_Default");
            script.RegrowSprite_Default = (Sprite)EditorGUILayout.ObjectField(script.RegrowSprite_Default, typeof(Sprite), allowSceneObjects: true);
            EditorGUILayout.EndHorizontal();

            // (Watered) Regrow sprite field
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("RegrowSprite_Watered");
            script.RegrowSprite_Watered = (Sprite)EditorGUILayout.ObjectField(script.RegrowSprite_Watered, typeof(Sprite), allowSceneObjects: true);
            EditorGUILayout.EndHorizontal();

            // Regrow days
            script.RegrowDays = EditorGUILayout.IntField("RegrowDays", script.RegrowDays);
        }
    }
}
#endif