using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Splash());
    }
    IEnumerator Splash()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}