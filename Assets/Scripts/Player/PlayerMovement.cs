using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerParameters playerParameters;
    private InputActions inputActions;
    private Player player;
    private bool isCasting;

    Vector3 movement;
    Vector3 input; 

    private void Awake()
    {
        playerParameters = Resources.Load<PlayerParameters>("PlayerParameters");
        inputActions = new InputActions();
        inputActions.Player.Enable();
        inputActions.Player1.Enable();
        player = FindObjectOfType<Player>();    
    }
    private void FixedUpdate()
    {
        if (player.firstPersonCamera) 
        {
            Cursor.visible = false;
            input = inputActions.Player1.Move.ReadValue<Vector2>();
            var rotation = inputActions.Player1.Direction.ReadValue<Vector2>();
            var direction = new Vector3(rotation.x, 0, rotation.y);
            if (direction != Vector3.zero) transform.Rotate(0, 2*rotation.x, 0);
        }
        else
        {
            Cursor.visible = true;
            input = inputActions.Player.Move.ReadValue<Vector2>();
        }
        movement = new Vector3(input.x, 0, input.y);
        transform.Translate(movement * playerParameters.movementSpeed * Time.deltaTime);
        RotateFromMouseVector();
    }

 
    private void RotateFromMouseVector()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 30f) && !player.firstPersonCamera)
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            target.y = Mathf.Clamp(target.y, -180, 180);
            transform.LookAt(target);
        }
    }
}
