using System;
using UnityEngine;

[Serializable]
public struct DamageContainer {
    public float damage;
    public float freezeTime;
    public Vector2 hitPoint;
    public Vector2 pushForce;
}
[Serializable]
public struct DamageReaction {

}

public interface IDamageble {
    void TakeDamage(DamageContainer damage, out DamageReaction reaction);
   
}