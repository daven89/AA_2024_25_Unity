using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private PlayerVisual visual;

    [SerializeField]
    private float speed = 3;

    private void Reset() {
        speed = 3;
        rb = GetComponent<Rigidbody2D>();
        visual = GetComponentInChildren<PlayerVisual>();
    }

    private void OnEnable() {
        InputManager.PlayerMap.Enable();
    }

    private void OnDisable() {
        InputManager.PlayerMap.Disable();
    }

    private void FixedUpdate() {
        Move();
    }


    private void Move() {
        float xDirection = InputManager.Player_Horizontal;
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
    }

}
