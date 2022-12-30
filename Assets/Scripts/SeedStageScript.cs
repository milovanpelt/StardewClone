using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStageScript : MonoBehaviour
{
    public Sprite[] stages;
    public int currentSprite = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetSprite();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentSprite < stages.Length - 1)
        {
            currentSprite++;
            SetSprite();
        }
    }

    public void SetSprite() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stages[currentSprite];
    }
}
