using TMPro;
using UnityEngine;

public class LoopCounter : Singleton<LoopCounter>
{
    [SerializeField] public TextMeshProUGUI loopCounterTMP;

    int loopcounter = 1;

    void Start()
    {
        UpdateText();
    }

    public void IncreaseLoopCounter()
    {
        loopcounter++;
        UpdateText();
    }

    void UpdateText()
    {
        loopCounterTMP.text = "Day " + loopcounter.ToString();
    }

    public int GetCounter()
    {
        return loopcounter;
    }

}
