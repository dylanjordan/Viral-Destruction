using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Interactable
{
    public GameObject fpsController;
    public override void OnFocus()
    {
        print("LOOKING AT " + gameObject.name);
    }

    public override void OnInteract()
    {
        fpsController.GetComponentInChildren<Gun>().AddAmmo(30);
        Destroy(gameObject);
    }

    public override void OnLoseFocus()
    {
        print("STOPPED LOOKING AT " + gameObject.name);
    }
}