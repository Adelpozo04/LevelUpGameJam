using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] int min, sec;
    [SerializeField] TextMeshProUGUI time;

    private float timeLeft;
    private bool onGoing1;


    private void Awake()
    {
        timeLeft = (min * 60) + sec;
        onGoing1 = true;
    }

    void Update()
    {
        if (onGoing1)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 1)
            {
                onGoing1 = true;
                Time.timeScale = 0;
            }
            int timeMin = Mathf.FloorToInt(timeLeft / 60);
            int timeSec = Mathf.FloorToInt(timeLeft % 60);
            time.text = string.Format("{00:00}:{01:00}", timeMin, timeSec);
        }
    }
}
