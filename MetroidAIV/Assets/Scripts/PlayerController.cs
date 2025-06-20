using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private PlayerVisual visual;
    [SerializeField]
    private Collider2D groundDetector;

    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float jumpSpeed = 5;
    [SerializeField]
    private LayerMask groundMask;


    public bool IsGround {
        get { return groundDetector.IsTouchingLayers(groundMask); }
    }

    private void Reset() {
        speed = 3;
        rb = GetComponent<Rigidbody2D>();
        visual = GetComponentInChildren<PlayerVisual>();
        groundDetector = GameObject.Find("GroundDetector").GetComponent<Collider2D>();
    }

    private void OnEnable() {
        InputManager.PlayerMap.Enable();
        InputManager.PlayerJumpAction.performed += OnPlayerJump;
    }

    private void OnDisable() {
        InputManager.PlayerMap.Disable();
        InputManager.PlayerJumpAction.performed -= OnPlayerJump;
    }

    private void FixedUpdate() {
        Move();
    }


    private void Move() {
        float xDirection = InputManager.Player_Horizontal;
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
    }

    private void OnPlayerJump (InputAction.CallbackContext context) {
        if (!IsGround) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
}
