using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public Text dayText;
    public int dayCount = 0;
    private void Start()
    {
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dayCount++;
            dayText.text = dayCount.ToString();
        }
    }
}
