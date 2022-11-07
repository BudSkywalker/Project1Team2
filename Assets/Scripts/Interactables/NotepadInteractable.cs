using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadInteractable : UIPanelInteractable
{
    public override void OnInteract(PlayerController sender)
    {
        base.OnInteract(sender);
        FindObjectOfType<PlayerController>().notebookCollected = true;
        Destroy(gameObject);
    }

    public override void OnReleased(PlayerController sender)
    {
    }

    public override void WhileHeld(PlayerController sender)
    {
    }
}
