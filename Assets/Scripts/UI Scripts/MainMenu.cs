using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private Dictionary<GameObject, TMP_Text>ButtonTexts = new Dictionary<GameObject, TMP_Text>();

    public TMP_Text playBtnTxt;
    public TMP_Text optionsBtnTxt;
    public TMP_Text quitBtnTxt;

    public GameObject playBtn;
    public GameObject optionsBtn;
    public GameObject quitBtn;

    private void Start()
    {
        ButtonTexts.Add(playBtn, playBtnTxt);
        ButtonTexts.Add(optionsBtn, optionsBtnTxt);
        ButtonTexts.Add(quitBtn, quitBtnTxt);
    }

    public void onClick()
    {
        Debug.Log("You just clicked a btn");
        //Play Sounds maybe
    }

    public void PlayBtn()
    {
        Debug.Log("Playbtn clicked");
        //Change later
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsBtn()
    {
        Debug.Log("Optionsbtn clicked");
    }

    public void QuitBtn()
    {
        Debug.Log("Quitbtn clicked, quitting game");
        Application.Quit();
    }

    public void onHover(GameObject button)
    {
        //Add hover sounds maybe
        Debug.Log("Hover on: " + button.name);
        ButtonTexts[button].fontStyle |= FontStyles.Underline;
    }

    public void ExitHover(GameObject button)
    {
        ButtonTexts[button].fontStyle &= ~FontStyles.Underline;
    }
}
