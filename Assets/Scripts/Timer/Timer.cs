using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;


    private DateTime currentTime;
    private float timer = 0f;



    void Start()
    {
        currentTime = GameManager.Instance.currentTime;
        UpdateTimerText();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.transitionActive) return;
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            currentTime = currentTime.AddMinutes(1);
            UpdateTimerText();
            timer = 0f;
        }

    }

    void UpdateTimerText()
    {
        timerText.text = currentTime.ToString("HH:mm");
    }

    public DateTime GetCurrentTime()
    {
        return currentTime;
    }
    public void SetCurrentTime(DateTime time)
    {
        currentTime = time;
    }
}
