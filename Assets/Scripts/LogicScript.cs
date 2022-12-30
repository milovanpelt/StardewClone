using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public Text dayText;
    private int dayCount = 0;
    private GameObject[] seedTags;
    private SeedSpawnScript seedspawner;

    void Start()
    {
        seedTags = GameObject.FindGameObjectsWithTag("Seed");
        seedspawner = GameObject.FindGameObjectWithTag("SeedSpawner").GetComponent<SeedSpawnScript>();
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
