using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu SaveSlotsMenu;

    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            //we can add a little popup saying that there is no game data saved
        }
    }

    public void OnNewGameClicked()
    {
        //SaveSlotsMenu.ActivateMenu(false);
        //this.DeactivateMenu();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnLoadGameClicked()
    {
        SaveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }

    public void OnContinueGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
