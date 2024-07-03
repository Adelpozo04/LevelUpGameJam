using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] int min, sec;
    [SerializeField] Text time;

    private float timeLeft;
    private bool onGoing1;
    //public Text loserText;
    //public Text escText;
    //private bool loser = false;


    private void Awake()
    {
        timeLeft = (min * 60) + sec;
        //loserText.gameObject.SetActive(false);
        //escText.gameObject.SetActive(false);
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
                //loserText.gameObject.SetActive(true);
                //escText.gameObject.SetActive(true);
                Time.timeScale = 0;
                //if (Input.GetKeyDown(KeyCode.Escape) && loser)
                //{
                //    SceneManager.LoadScene("MainMenu");
                //}
            }
            int timeMin = Mathf.FloorToInt(timeLeft / 60);
            int timeSec = Mathf.FloorToInt(timeLeft % 60);
            time.text = string.Format("{00:00}:{01:00}", timeMin, timeSec);
        }
    }
}
