using UnityEngine;
using System.Collections;

public class resume : MonoBehaviour {
    SideMenu sMenu;
    Transform menu;

    Animator animator;
	void Start () {
        sMenu = GameObject.Find("Menu").GetComponent<SideMenu>();
        animator = GetComponent<Animator>();
        menu = GameObject.Find("Menu").transform.Find("SideMenu");
	}
	
	void Update () {
        if (sMenu.GetIndex() == 0)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (sMenu.GetIndex() == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            menu.gameObject.SetActive(false);
        }
	}
}
