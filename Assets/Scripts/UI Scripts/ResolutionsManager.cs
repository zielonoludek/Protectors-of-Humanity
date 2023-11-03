using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionsManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resDropDown;

    private Resolution[] resolution;
    private List<Resolution> resList;

    private float currentRefreshRate;
    private int currentResIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        resolution = Screen.resolutions;

        resList = new List<Resolution>();

        resDropDown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolution.Length; i++)
        {
            if (resolution[i].refreshRate == currentRefreshRate)
            {
                resList.Add(resolution[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < resList.Count; i++)
        {
            string resolutionOptions = resList[i].width + "x" + resList[i].height + " " + resList[i].refreshRateRatio + " hz";
            options.Add(resolutionOptions);
            if (resList[i].width == Screen.width && resList[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }


        resDropDown.AddOptions(options);
        resDropDown.value = currentResIndex;
        resDropDown.RefreshShownValue();
    }


    public void SetSelectedRes(int resIndex)
    {
        Resolution resolution = resList[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

}
