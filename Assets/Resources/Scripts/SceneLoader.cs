using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public GameObject CanvaseSceneLoader;//ScreenLoader
    private string SceneName;//Name scene which one is being
    void Start() 
    {
        SceneManager.OnLoadScene.AddListener(load);//subscribe to event   
    }
    public void load(string name)
    {
        SceneName=name;//Set name for load scene
        CanvaseSceneLoader.SetActive(true);//On ScreenLoader
        StartCoroutine(AsyncLoad());
    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);
        asyncOperation.allowSceneActivation=false; 
        while(!asyncOperation.isDone)
        {
            if(asyncOperation.progress>=.9f && !asyncOperation.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                asyncOperation.allowSceneActivation=true;
                CanvaseSceneLoader.SetActive(false);

            }
            yield return null;
        }
    }

}
