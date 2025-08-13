using UnityEngine;

public class SpeechBubble : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject speechBubble;
    bool interacted = false;
    bool isActive = true;
    float blinkIntervall = 0.5f;
    float blinkTimer = 0.5f;

    void Update()
    {
        BubbleBlink();
    }



    public void Interact()
    {
        if (!interacted)
        {
            interacted = true;
            speechBubble.SetActive(false);            
        }
    }

    public void BubbleBlink()
    {
        if (interacted) return;

        blinkTimer -= Time.deltaTime;

        if (blinkTimer <= 0f)
        {
            speechBubble.SetActive(!isActive);
            isActive = !isActive;
            blinkTimer = blinkIntervall;
        }
    }




}
