using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_SceneManager : MonoBehaviour
{
    /// <summary>
    /// Simple scene manager that at the moment is only capable to load the next scene.
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
