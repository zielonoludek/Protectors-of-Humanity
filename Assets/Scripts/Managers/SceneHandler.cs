using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour 
{
    public List<string> sceneList = new List<string>();
    private int numberOfScenes;
    private bool LastScene = false;

    public void LoadNextScene()
    {
        LastScene = false;
        numberOfScenes = sceneList.Count;
        for (int i = 0; i < numberOfScenes; i++)
        {
            Debug.Log(i + ": " + sceneList[i]);
            if (i == (numberOfScenes - 1)) LastScene = true;
            else if (sceneList[i] == CurrentScene() && !LastScene)
            {
                SceneManager.LoadScene(i + 1);
            }
            else if (LastScene) Debug.LogWarning("No more scenes to load");
        }
    }
    public string CurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
    public void LoadSceeneByName(string name)
    {
        for (int i = 0; i < numberOfScenes; i++)
        {
            if (sceneList[i] == name) SceneManager.LoadScene(sceneList[i]);
        }
    }
}