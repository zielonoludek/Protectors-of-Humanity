using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    KeyCode KeyRestart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyRestart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
