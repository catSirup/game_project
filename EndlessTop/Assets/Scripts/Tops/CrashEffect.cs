using UnityEngine;
using System.Collections;

public class CrashEffect : MonoBehaviour {
    public Animator animator;
    public PlayerControl player;

	void Start () {
        gameObject.SetActive(false);
	    animator = GetComponent<Animator>();
        player = GameObject.Find("MyTop").GetComponent<PlayerControl>();
	}
	
	void Update () {
        if (player.crashEffect && !player.bCanCrashEffect)
        {
            this.transform.position = new Vector2(player.centerX, player.centerY);
            animator.SetBool("crash", true);
        }

        else
        {
            animator.SetBool("crash", false);
            gameObject.SetActive(false);
        }
	}
}
