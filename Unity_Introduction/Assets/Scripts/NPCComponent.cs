using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCComponent : MonoBehaviour
{


    [SerializeField]
    private bool canInteract;
    [SerializeField]
    private GameObject prompt;
    [SerializeField]
    private DetectPlayerTrigger detectPlayerTrigger;

    private void Reset() {
        detectPlayerTrigger = GetComponentInChildren<DetectPlayerTrigger>();
    }

    private void OnEnable() {
        detectPlayerTrigger.playerTriggerEnter += OnPlayerEnter;
        detectPlayerTrigger.playerTriggerExit += OnPlayerExit;
    }

    private void OnDisable() {
        detectPlayerTrigger.playerTriggerEnter -= OnPlayerEnter;
        detectPlayerTrigger.playerTriggerExit -= OnPlayerExit;
    }

    public virtual void OnPlayerEnter () {
        if (!canInteract) return;
        prompt.SetActive(true);
    }

    public virtual void OnPlayerExit () {
        prompt.SetActive(false);
    }

}
