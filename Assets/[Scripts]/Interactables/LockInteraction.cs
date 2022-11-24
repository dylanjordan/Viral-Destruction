using System.Collections;
using UnityEngine;

public class LockInteraction : Interactable
{
    [SerializeField] private GameObject numPadUI;

    public override void OnFocus() { }

    public override void OnInteract()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        numPadUI.SetActive(true);
    }

    public override void OnLoseFocus() { }
}