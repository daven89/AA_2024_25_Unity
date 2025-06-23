using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer sr;

    private void Reset() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void UpdatePlayerOrientation (bool flipX) {
        sr.flipX = flipX;
    }

    public void SetParameter (int parameterID, bool value) {
        animator.SetBool(parameterID, value);
    }

    public void SetParameter (int parameterID, float value) {
        animator.SetFloat(parameterID, value);
    }

    public void SetParameter (int parameterID) {
        animator.SetTrigger(parameterID);
    }

    public bool FlipX () {
        return sr.flipX;
    }

}
