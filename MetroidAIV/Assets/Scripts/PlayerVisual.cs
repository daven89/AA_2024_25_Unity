using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    private void Reset() {
        animator = GetComponent<Animator>();
    }

}
