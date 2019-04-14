﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!flag) { 
            float t = Time.time - startTime;

            string minutes = ( (int)t / 60 ).ToString();
            string seconds = (t % 60).ToString("F0");


            float milisegundos;

            if (((t % 60) % 1 * 10 - 5) < 0)
            {
                milisegundos = 10 + ((t % 60) % 1 * 10 - 5);    
            }
            else
            {
                milisegundos = ((t % 60) % 1 * 10 - 5);
            }

            if (milisegundos > 9) milisegundos = 0;

            timerText.text = minutes + ":" + seconds + ":" + milisegundos.ToString("F0");

        }
    }
}