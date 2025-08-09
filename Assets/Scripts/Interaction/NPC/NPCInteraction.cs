
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{

    [SerializeField] DialogData dialogData;

    public void Interact()
    {
        DialogManager.Instance.StartDialog(dialogData.GetLines());
    }
}