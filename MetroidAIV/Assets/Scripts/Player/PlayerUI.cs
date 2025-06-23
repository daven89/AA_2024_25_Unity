using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    private Image fillbar;

    private void Awake() {
        PlayerController pc = GameObject.Find("Player").GetComponent<PlayerController>();
        pc.onPlayerHealthChanged += OnPlayerHealthChanged;
    }

    private void OnDestroy() {
        PlayerController pc = GameObject.Find("Player")?.GetComponent<PlayerController>();
        if (pc == null) return;
        pc.onPlayerHealthChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(float current_HP, float max_HP, float previousHP) {
        fillbar.fillAmount = current_HP / max_HP;
    }
}
