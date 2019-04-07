using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour {
    SideMenu sMenu;

    Animator animator;
    void Start()
    {
        sMenu = GameObject.Find("Menu").GetComponent<SideMenu>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (sMenu.GetIndex() == 2)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (sMenu.GetIndex() == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            EndTime.endTime = 0;

            DieBoolValue.isDie = false;

            SetBallBoolValue.firstBall = true;

            DeadLineSetBoolValue.UpLeft = true;
            DeadLineSetBoolValue.UpMiddle = true;
            DeadLineSetBoolValue.UpRight = true;
            DeadLineSetBoolValue.DownLeft = true;
            DeadLineSetBoolValue.DownMiddle = true;
            DeadLineSetBoolValue.DownRight = true;

            SceneManager.LoadScene("Main");
        }
    }
}
