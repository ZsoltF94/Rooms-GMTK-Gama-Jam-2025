using UnityEngine;

public class GhostTalk : MonoBehaviour, IInteractable
{
    [SerializeField] DialogData dialogData;

    public void Interact()
    {
        DialogManager.Instance.StartDialog(dialogData.GetLines());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interact();
        }
    }
}
