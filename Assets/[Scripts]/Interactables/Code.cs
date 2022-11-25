using UnityEngine;

public class Code : Interactable
{
    public override void OnFocus()
    {
        //print("LOOKING AT " + gameObject.name);
    }

    public override void OnInteract()
    {
        GlobalInventory.codePieces++;

        this.gameObject.SetActive(false);
    }

    public override void OnLoseFocus()
    {
        //print("STOPPED LOOKING AT " + gameObject.name);
    }
}