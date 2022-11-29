using System.Collections;
using UnityEngine;

public class Code : Interactable
{
    [SerializeField] private GameObject CodeUI;

    public override void OnInteract()
    {
        StartCoroutine(ShowUI());
    }

    private IEnumerator ShowUI()
    {
        CodeUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        CodeUI.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public override void OnFocus() { }
    public override void OnLoseFocus() { }
}