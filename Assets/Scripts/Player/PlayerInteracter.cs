

using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] GameObject interactionBox;
    [SerializeField] LayerMask interactableLayer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) CheckInteractables();
    }

    public void CheckInteractables()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(interactionBox.transform.position, interactionBox.transform.localScale, interactableLayer);

        foreach (var hit in hits)
        {
            var interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }    
        }
        
    }
}