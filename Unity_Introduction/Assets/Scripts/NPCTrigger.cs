using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigge : MonoBehaviour
{
    [SerializeField]
    private GameObject prompt;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        prompt.SetActive(true);
    }

    //private void OnTriggerStay2D(Collider2D collision) {
    //    if (!collision.CompareTag("Player")) return;
    //}

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        prompt.SetActive(false);
    }
}
