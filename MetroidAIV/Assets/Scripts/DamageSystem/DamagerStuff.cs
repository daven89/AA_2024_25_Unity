using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerStuff : MonoBehaviour
{

    [SerializeField]
    private DamageContainer damageInfo;
    [SerializeField]
    private Collider2D myCollider;

    private void OnTriggerStay2D(Collider2D collision) {
        IDamageble damageble = collision.GetComponent<IDamageble>();
        if (damageble == null) return;
        damageInfo.hitPoint = myCollider.ClosestPoint(collision.transform.position);
        damageble.TakeDamage(damageInfo, out DamageReaction reaction);
    }

}
