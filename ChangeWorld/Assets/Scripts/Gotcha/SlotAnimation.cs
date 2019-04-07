using UnityEngine;
using System.Collections;

public class SlotAnimation : MonoBehaviour {
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Animation()
    {
        if (GotchaButton.isPushButton)
            animator.SetBool("isPush", true);

        else
            animator.SetBool("isPush", false);
    }
}
