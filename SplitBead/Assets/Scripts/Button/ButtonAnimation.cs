using UnityEngine;
using System.Collections;

public class ButtonAnimation : MonoBehaviour {
    private bool keyDown = false;
    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        if (keyDown)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }
	}

    public void SetKeyDown(bool state)
    {
        this.keyDown = state;
    }

    public bool GetKeyDown()
    {
        return this.keyDown;
    }
}
