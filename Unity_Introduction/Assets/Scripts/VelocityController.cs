using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rigibody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpVelocity;

    private void FixedUpdate() {
        Vector2 velocity = rigibody.velocity;
        if (Input.GetKey(KeyCode.A)) {
            velocity.x = -speed;
        } else if (Input.GetKey(KeyCode.D)) {
            velocity.x = speed;
        } else {
            //velocity.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            velocity.y = jumpVelocity;
        }
        rigibody.velocity = velocity;
    }

}
