using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    public static UnityEvent<string> OnLoadScene=new UnityEvent<string>();

    private List<string> _scenes = new List<string>();

    public void ReloadCurrent()
    {
        AsyncLoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        AsyncLoadScene(_scenes[0]);
    }

    public void LoadNext()
    {
        int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        int nextScene = 0;

        if (currentScene < _scenes.Count - 1)nextScene = currentScene + 1;
        AsyncLoadScene(_scenes[nextScene]);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void AsyncLoadScene(string name)
    {
        OnLoadScene?.Invoke(name);
    }

    private void Awake()
    {
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
            _scenes.Add(Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
    }
}
