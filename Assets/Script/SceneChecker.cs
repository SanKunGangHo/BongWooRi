using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    public void SceneRestart()
    {
        SceneManager.LoadScene(0);
    }
}
