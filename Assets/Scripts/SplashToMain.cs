using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMain : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(SplashSequence());
    }


    IEnumerator SplashSequence()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(1);
    }
}
