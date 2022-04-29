using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;

    public Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;//decrease by 1 second
        countdownText.text = "Time: " + currentTime.ToString("0");//format string to show whole number
        if(currentTime <= 0)
        {
            Loadgame();
        }
    }

    public void Loadgame()
    {
        SceneManager.LoadScene(2);
    }
}
