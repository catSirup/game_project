using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Vertical") == 0)
        {
            animation.CrossFade("Idle");
        }
        else
        {
            animation.CrossFade("run");
        }
    }
}
