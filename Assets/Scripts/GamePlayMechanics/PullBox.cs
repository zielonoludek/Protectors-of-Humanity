using UnityEngine;

public class PullBox : MonoBehaviour
{
    public float pullingSpeed;
    public float maxPullingDist;
    public bool isPulling;

    private Rigidbody boxRb;
    private InputActions inputActions;
    
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Enable();

        boxRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (inputActions.Player.Move.triggered && !isPulling)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxPullingDist) &&
                hit.collider.CompareTag("Pullable"))
            {
                isPulling = true;
                boxRb = hit.collider.GetComponent<Rigidbody>();
            }
        }else if (inputActions.Player.Move.triggered && isPulling)
        {
            isPulling = false;
            boxRb = null;
        }
        if (isPulling)
        {
            Vector2 verticalInput = inputActions.Player.Move.ReadValue<Vector2>();
            Vector3 pullDirection = transform.forward * verticalInput.y;
            boxRb.velocity = pullDirection * pullingSpeed;
        }
    }
}
