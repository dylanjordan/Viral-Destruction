using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    
    //we can incorporate TMP elements later here

    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            //you can incorporate TMPro elements here
        }
    }

    public string GetProfileId()
    {
        return this.profileId;
    }
}
