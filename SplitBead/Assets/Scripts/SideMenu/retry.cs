using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour {
    SideMenu sMenu;

    Animator animator;
    void Start()
    {
        sMenu = GameObject.Find("Menu").GetComponent<SideMenu>();
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        if (sMenu.GetIndex() == 1)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (sMenu.GetIndex() == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Stage");
        }
	}
}
