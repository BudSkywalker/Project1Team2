using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovableInteractable : MoveableInteractable
{
    public override void OnInteract(PlayerController sender)
    {
        TutorialGM.Instance.SetTrigger(5);

        base.OnInteract(sender);
    }
}
