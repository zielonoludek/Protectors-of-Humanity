using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeMachine : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}