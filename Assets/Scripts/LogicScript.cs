using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum Seasons 
{ 
    Spring,
    Summer,
    Fall,
    Winter
}

public class LogicScript : MonoBehaviour
{
    public Seasons seasons;
    public Text dayText;
    private int dayCount = 0;
    private int maxDays = 0;
   

    private GameObject[] seedTags;
    private SeedSpawnScript seedspawner;

    void Start()
    {
        maxDays = 28;

        seedTags = GameObject.FindGameObjectsWithTag("Seed");
        seedspawner = GameObject.FindGameObjectWithTag("SeedSpawner").GetComponent<SeedSpawnScript>();
    }
    void Update()
    {

        seedTags = GameObject.FindGameObjectsWithTag("Seed");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Increase the day
            dayCount++;

            // Set text UI to current dayCount
            dayText.text = dayCount.ToString();

            // Set next stage for each seed
            foreach (GameObject item in seedTags)
            {
                item.GetComponent<SeedStageScript>().NextStage();
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            foreach (GameObject item in seedTags)
            {
                item.GetComponent<SeedStageScript>().WaterSeed();
            }
        }

        if (Input.GetMouseButton(0))
        {
            // Ray cast from mouse to screen in 2D
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // Water seed when clicking it
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<SeedStageScript>().WaterSeed();
            }
        }

        if (dayCount == maxDays) 
        {
            foreach (GameObject item in seedTags)
            {
                if (item.GetComponent<SeedStageScript>().seasons.ToString() == seasons.ToString()) 
                {
                    Destroy(item);
                }
            }
        }
    }
}
