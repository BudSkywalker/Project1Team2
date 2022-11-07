using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelInteractable : Interactable
{
    public bool autoEnable = false;
    [SerializeField]
    private GameObject uiPanel;

    void Start()
    {
        if(autoEnable) OnInteract(FindObjectOfType<PlayerController>());
    }

    public override void OnInteract(PlayerController sender)
    {
        uiPanel.SetActive(true);
        if(uiPanel.TryGetComponent(out Animator anim))
        {
            anim.SetTrigger("FadeIn");
            sender.uiAnim = anim;
        }

        sender.uiPanelOpen = true;
        PauseMenu.isPaused = true;

        if(TryGetComponent(out GuessableObject guess)) Lvl2GM.vistedPeople[guess.gmIndex] = true;
    }

    public override void OnReleased(PlayerController sender)
    {
        //throw new System.NotImplementedException();
    }

    public override void WhileHeld(PlayerController sender)
    {
        //throw new System.NotImplementedException();
    }
}
