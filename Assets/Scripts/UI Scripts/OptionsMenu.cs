using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    private Dictionary<GameObject, TMP_Text> ButtonTexts = new Dictionary<GameObject, TMP_Text>();

    public TMP_Text backBtnTxt;
    public TMP_Text saveBtnTxt;

    public GameObject backBtn;
    public GameObject saveBtn;

    private void Start()
    {
        ButtonTexts.Add(backBtn, backBtnTxt);
        ButtonTexts.Add(saveBtn, saveBtnTxt);
    }
    

    public void onHover(GameObject button)
    {
        Debug.Log("Hover on: " + button.name);
        ButtonTexts[button].fontStyle |= FontStyles.Underline;
    }

    public void ExitHover(GameObject button)
    {
        ButtonTexts[button].fontStyle &= ~FontStyles.Underline;
    }
}
