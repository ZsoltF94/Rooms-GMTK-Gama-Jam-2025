using TMPro;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endText;

    void Start()
    {
        UpdateText();
        LoopCounter.Instance.loopCounterTMP.text = "";
    }

    public void UpdateText()
    {
        endText.text = "Thank you for playing!\nYou made it out in " + LoopCounter.Instance.GetCounter() + " days.\n \nBy FSF Games";
    }
}
