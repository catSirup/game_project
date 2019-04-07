using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour
{
    BigBang BB;
    Animator animator;

    private float time = 0.0f;

    void Start()
    {
        BB = gameObject.GetComponent<BigBang>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (BB.GetIsBigBang() && !BB.GetIsCanBigBang())
        {
            animator.SetBool("On", true);
            
            if (Time.time - time > 1.2f)
            {
                Debug.Log("D");
                BB.SetIsBigBang(false);
            }
        }

        else
        {
            time = Time.time;
            animator.SetBool("On", false);
        }
    }
}
