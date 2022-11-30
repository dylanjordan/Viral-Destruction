using UnityEngine;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string code = "130013";
    string num = null;

    [SerializeField] private Text uiText = null;
    [SerializeField] private GameObject fadeOutScreen;
    [SerializeField] private GameObject thankYouText;
    [SerializeField] private GameObject allUI;

    private InputManager input;

    void Start()
    {
        input = InputManager.Instance;
    }

    void Update()
    {
        if (input.GetEscape())
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void CodeFunction(string numbers)
    {
        num += numbers;
        uiText.text = num;
    }

    public void Enter()
    {
        if (num == code)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            this.gameObject.SetActive(false);
            Time.timeScale = 1;

            // Do important stuff like start an anim
            // Correct Code
            fadeOutScreen.SetActive(true);
            thankYouText.SetActive(true);
            allUI.SetActive(false);
        }
    }

    public void Delete()
    {
        num = null;
        uiText.text = num;
    }
}