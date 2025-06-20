using System;
using UnityEngine;

public class DetectPlayerTrigger : MonoBehaviour
{

    public Action playerTriggerEnter;
    public Action playerTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        playerTriggerEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        playerTriggerExit?.Invoke();
    }

}
