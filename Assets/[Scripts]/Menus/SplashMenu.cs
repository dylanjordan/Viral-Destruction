using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashMenu : MonoBehaviour
{
    [SerializeField] private float waitTime;

    private void Start()
    {
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}