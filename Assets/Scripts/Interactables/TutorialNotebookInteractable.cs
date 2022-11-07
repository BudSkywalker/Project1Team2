using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNotebookInteractable : NotepadInteractable
{
    public override void OnInteract(PlayerController sender)
    {
        TutorialGM.Instance.SetTrigger(4);

        base.OnInteract(sender);
    }
}
