using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class LogicScript : MonoBehaviour
{
    public Text dayText;
    private int dayCount = 0;
    private GameObject[] seeds;

    void Start()
    {
        seeds = GameObject.FindGameObjectsWithTag("Seed");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dayCount++;
            dayText.text = dayCount.ToString();

            foreach (GameObject item in seeds)
            {
                item.GetComponent<SeedStageScript>().SetSprite(dayCount);
            }
        }
    }
}
