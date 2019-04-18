using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private bool load_scene = false;

    //This field should be set in the editor for the scene number to load, number can be found in build settings
    [SerializeField]
    private int scene;

    // Returns false if already loading a scene, true if scene has been successfully loaded.
    public bool Load()
    {
		print(Results.reasons[Results.reasons.Count - 1].Key);
        if (load_scene)
        {
            print("Scene " + scene + " already loading");
            return false;
        }
        load_scene = true;
        StartCoroutine(LoadNewScene());
        return true;
    }

    IEnumerator LoadNewScene()
    {
        
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return null;
        }
    }
	
}
