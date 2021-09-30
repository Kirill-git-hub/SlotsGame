using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private List<string> scenes = new List<string>();
    [SerializeField] private string scene1 = null;
    [SerializeField] private string scene2 = null;

    // Start is called before the first frame update
    void Start()
    {
        foreach(string sceneName in scenes)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }

    public static void Unload(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
