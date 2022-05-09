using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{

    private string sceneNameToBeLoaded;
   public void LoadScene(string _sceneName)
    {
        sceneNameToBeLoaded = _sceneName;

        StartCoroutine(InitializeSceneLoading());
    }


    IEnumerator InitializeSceneLoading()
    {
        // First load the loading scene herre

        yield return SceneManager.LoadSceneAsync("Scene_Loading");

        // LoAD ACTUAL SCENE  

        StartCoroutine(LoadActualScene());
    }


    IEnumerator LoadActualScene()
    {
        var asyncSceneLoading = SceneManager.LoadSceneAsync(sceneNameToBeLoaded);

        // this value stops the scene from displaying when it is still loading...

        asyncSceneLoading.allowSceneActivation = false;

        // wait while scene is fully loaded
        while (!asyncSceneLoading.isDone)
        {
            Debug.Log(asyncSceneLoading.progress);

            if (asyncSceneLoading.progress >= 0.9f)
            {
                // Finally , show the scene
                asyncSceneLoading.allowSceneActivation = true;
            }


            yield return null;
        }

    }

}
