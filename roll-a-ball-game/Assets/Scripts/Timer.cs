using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.AI;


public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float time;

    bool isRunning = false;
    void Update()
    {
        if (PlayerController.isGameEnded)
            isRunning = false;
        if (CountDownController.isGameStarted)
        {
            isRunning = true;
        }
        if (isRunning)
        {
            time += Time.deltaTime;

        }
        timerText.text = time.ToString("F2");
    }
}
