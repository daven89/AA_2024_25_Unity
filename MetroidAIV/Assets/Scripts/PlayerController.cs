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


    static int HORIZONTAL_VELOCITY_HASH = Animator.StringToHash("HorizontalVelocity");
    static int VERTICAL_VELOCITY_HASH = Animator.StringToHash("VerticalVelocity");
    static int JUMP_HASH = Animator.StringToHash("Jump");
    static int ISGROUND_HASH = Animator.StringToHash("IsGround");


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
        UpdateVisual();
        if (Mathf.Approximately(rb.velocity.x, 0)) return;
    }


    private void Move() {
        float xDirection = InputManager.Player_Horizontal;
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
        visual.UpdatePlayerOrientation(rb.velocity.x < 0);
    }

    private void OnPlayerJump (InputAction.CallbackContext context) {
        if (!IsGround) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        visual.SetParameter(JUMP_HASH);
    }

    private void UpdateVisual () {
        visual.SetParameter(HORIZONTAL_VELOCITY_HASH, Mathf.Abs(rb.velocity.x));
        visual.SetParameter(VERTICAL_VELOCITY_HASH, rb.velocity.y);
        visual.SetParameter(ISGROUND_HASH, IsGround);
    }
}
