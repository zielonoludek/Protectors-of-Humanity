using UnityEngine;

public class Player : MonoBehaviour
{
    public bool firstPersonCamera = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) firstPersonCamera = !firstPersonCamera;
    }
}