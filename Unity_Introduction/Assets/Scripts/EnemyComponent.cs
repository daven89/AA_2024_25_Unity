using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{

    [SerializeField]
    private float hp;
    [SerializeField]
    private float damage;

    [SerializeField]
    private SpriteRenderer visual;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            visual.enabled = !visual.enabled;
        }
    }

}
