using UnityEngine;
using System.Collections;

public class ProtectTop : MonoBehaviour {
    [HideInInspector]
    public bool destroy = false;
    
    public float time = 0.0f;
    public UI ui;

    public Animator animator;
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        ui = GameObject.Find("UI").GetComponent<UI>();
        time = Time.time;
	}

	void Update () {
        if (destroy)
        {
         	animator.SetBool("Destroy", true);
            ResetTimer();
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!TimerValueManager.closeTimer)
        {
            if (col.tag == "Enemy")
            {
				ui.gameover = true;
                destroy = true;
            }
        }
    }

    public void ResetTimer()
    {
        if (Time.time - time > 3.0f)
        {
            time = Time.time;
        }
    }
}
