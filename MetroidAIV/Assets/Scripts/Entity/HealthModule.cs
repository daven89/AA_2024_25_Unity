using UnityEngine;
using System;

public class HealthModule : MonoBehaviour
{

    /// <summary>
    /// Current_HP, Max_HP and the previous Current_HP
    /// </summary>
    public Action<float, float, float> onHPChanged;

    [SerializeField]
    private float max_HP;

    private float current_HP;
    public float Current_HP {
        get { return current_HP; }
        private set {
            float previousHP = current_HP;
            current_HP = value;
            if (current_HP < 0) current_HP = 0;
            onHPChanged?.Invoke(current_HP, max_HP, previousHP);
        }
    }

    public void ResetMe () {
        current_HP = max_HP;
    }

    public bool TakeDamage (float damage) {
        Current_HP -= damage;
        return Current_HP <= 0;
    }



}
