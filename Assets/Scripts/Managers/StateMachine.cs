using UnityEngine;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour
{
    [HideInInspector] public string cState;

    //possible Game states 
    [HideInInspector] public string LevelRunning = "LevelRunning";
    [HideInInspector] public string GamePaused = "GamePaused";
    [HideInInspector] public string GameInitialized = "GameInitialized";

    public void setState(string state)
    {
        switch (state)
        {
            case "LevelRunning":
                cState = LevelRunning;
                break;
            case "GamePaused":
                cState = GamePaused;
                break;
            case "GameInitialized":
                cState = GameInitialized;
                break;
            default:
                break;
        }
    }
    public void getState()
    {
        Debug.Log("current game state: " + cState);
    }
}
