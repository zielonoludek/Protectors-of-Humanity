using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //managers accessible through game manager
    [HideInInspector] public StateMachine stateMachine;
    public SceneHandler sceneHandler;

    public string currentState { get { return stateMachine.cState; } }

    private void Awake() => Initialize();
    public void Initialize()
    {
        if (instance == null)
        {
            instance = this;

            LoadResources();
            LoadScene("MainMenu");
            stateMachine.setState(stateMachine.GameInitialized);
            return;
        }
        stateMachine.getState();
        Destroy(gameObject);
    }
    private void LoadResources()
    {
        stateMachine = gameObject.AddComponent<StateMachine>();
        sceneHandler = gameObject.AddComponent<SceneHandler>();
    }
    private void LoadScene(string name) => sceneHandler.LoadSceeneByName(name);
    public void LoadNextLevel() =>  sceneHandler.LoadNextScene();
}