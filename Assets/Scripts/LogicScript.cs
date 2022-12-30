using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class LogicScript : MonoBehaviour
{
    public Text dayText;
    private int dayCount = 0;
    private GameObject[] seedTags;

    void Start()
    {
        seedTags = GameObject.FindGameObjectsWithTag("Seed");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dayCount++;
            dayText.text = dayCount.ToString();

            foreach (GameObject item in seedTags)
            {
                item.GetComponent<SeedStageScript>().SetSprite(dayCount);
            }
        }
    }
}
