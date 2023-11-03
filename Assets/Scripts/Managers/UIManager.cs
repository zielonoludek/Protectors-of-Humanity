using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    //Menu references
    //public GameObject mainMenu;
    public GameObject inGameOptionsMenu;
    public GameObject PauseMenu;
    public InputField input;

    private InputActions _inputActions;
    
    private bool isPaused;
    
    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.UI.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputActions.UI.PauseBtn.triggered)
        {
            PausedToggled();
        }
        
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadOptionsMenu()
    {
        Debug.Log("OptionsMenu Open");
    }

    public void ResumeGame()
    {
        if (isPaused == true)
        {
            Debug.Log("Game Resumed");
            PauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        isPaused = false;
    }

    public void PausedToggled()
    {
        Debug.Log("PauseMenu toggled");
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        PauseMenu.gameObject.SetActive(isPaused);
    }
}
