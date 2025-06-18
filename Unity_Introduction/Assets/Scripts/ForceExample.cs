using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceExample : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;


    public void Reset() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            rb.AddForce(new Vector2(20, 0), ForceMode2D.Impulse);
        } else if (Input.GetMouseButton(1)) {
            rb.AddTorque(50);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Entrato in collisione con: " + collision.collider.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        Debug.Log("Stay in collisione con: " + collision.collider.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("Exit gianfranco in collisione con: " + collision.collider.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("CinematicTrigger")) return;
        Debug.Log("Trigger Enter con: " + collision.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (!collision.CompareTag("CinematicTrigger")) return;
        Debug.Log("Trigger Stay con: " + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("CinematicTrigger")) return;
        Debug.Log("Trigger Exit con: " + collision.gameObject.name);
    }


}
