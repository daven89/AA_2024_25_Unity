using UnityEngine;
using UnityEngine.InputSystem;
using System;

public enum PlayerState {
    Normal,
    Freezed
}

public class PlayerController : MonoBehaviour, IDamageble
{

    public Action<float, float, float> onPlayerHealthChanged;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private PlayerVisual visual;
    [SerializeField]
    private Collider2D groundDetector;
    [SerializeField]
    private HealthModule healthModule;
    [SerializeField]
    private float invTime;

    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float jumpSpeed = 5;
    [SerializeField]
    private LayerMask groundMask;

    #region NonDiscutereConIlProf
    static int HORIZONTAL_VELOCITY_HASH = Animator.StringToHash("HorizontalVelocity");
    static int VERTICAL_VELOCITY_HASH = Animator.StringToHash("VerticalVelocity");
    static int JUMP_HASH = Animator.StringToHash("Jump");
    static int ISGROUND_HASH = Animator.StringToHash("IsGround");
    static int HIT_HASH = Animator.StringToHash("Hit");
    #endregion

    private PlayerState currentState;
    private bool isGround;
    private float lastUpdateFrame;
    public bool IsGround {
        get {
            if (lastUpdateFrame != Time.time) {
                isGround = groundDetector.IsTouchingLayers(groundMask);
                lastUpdateFrame = Time.time;
            }
            return isGround;
        }
    }
    private DamageContainer lastDamageContainer;
    private float currentInvTime;
    private float freezeTime;

    private void Reset() {
        speed = 3;
        rb = GetComponent<Rigidbody2D>();
        visual = GetComponentInChildren<PlayerVisual>();
        groundDetector = GameObject.Find("GroundDetector").GetComponent<Collider2D>();
        healthModule = GetComponent<HealthModule>();
    }

    void Start () {
        healthModule.ResetMe();
    }

    private void OnEnable() {
        healthModule.onHPChanged += InternalPlayerHealthChanged;
        InputManager.PlayerMap.Enable();
        InputManager.PlayerJumpAction.performed += OnPlayerJump;
    }

    private void OnDisable() {
        healthModule.onHPChanged -= InternalPlayerHealthChanged;
        InputManager.PlayerMap.Disable();
        InputManager.PlayerJumpAction.performed -= OnPlayerJump;
    }

    private void FixedUpdate() {
        Move();
        UpdateVisual();
        if (Mathf.Approximately(rb.velocity.x, 0)) return;
        if (currentState == PlayerState.Freezed) return;
        visual.UpdatePlayerOrientation(rb.velocity.x < 0);
    }

    private void Update() {
        currentInvTime -= Time.deltaTime;
        switch(currentState) {
            case PlayerState.Freezed:
                FreezedUpdate();
                break;
        }
    }

    private void FreezedUpdate () {
        freezeTime -= Time.deltaTime;
        if (freezeTime > 0) return;
        currentState = PlayerState.Normal;
    }


    private void Move() {
        if (currentState == PlayerState.Freezed) return;
        float xDirection = InputManager.Player_Horizontal;
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
    }

    private void OnPlayerJump (InputAction.CallbackContext context) {
        if (currentState == PlayerState.Freezed) return;
        if (!IsGround) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        visual.SetParameter(JUMP_HASH);
    }

    private void UpdateVisual () {
        visual.SetParameter(HORIZONTAL_VELOCITY_HASH, Mathf.Abs(rb.velocity.x));
        visual.SetParameter(VERTICAL_VELOCITY_HASH, rb.velocity.y);
        visual.SetParameter(ISGROUND_HASH, IsGround);
    }

    public void TakeDamage(DamageContainer damage, out DamageReaction reaction) {
        if (currentInvTime > 0) return;
        lastDamageContainer = damage;
        freezeTime = damage.freezeTime;
        healthModule.TakeDamage(damage.damage);
    }

    private void InternalPlayerHealthChanged (float current_HP, float max_HP, float lastHP) {
        currentState = PlayerState.Freezed;
        rb.velocity = new Vector2(0, rb.velocity.y);
        currentInvTime = invTime;
        Vector2 pushForce = lastDamageContainer.pushForce;
        if (lastDamageContainer.hitPoint.x > transform.position.x) {
            pushForce.x *= -1;
        }
        rb.AddForce(pushForce, ForceMode2D.Impulse);
        visual.SetParameter(HIT_HASH);
        onPlayerHealthChanged?.Invoke(current_HP, max_HP, lastHP);
    }
}
