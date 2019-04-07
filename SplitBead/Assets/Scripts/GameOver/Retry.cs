using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {
    GameOver GO;
    Animator animator;
	void Start () 
    {
        animator = GetComponent<Animator>();
        GO = GameObject.Find("Button").GetComponent<GameOver>();
	}
	
	void Update () {
        if (GO.GetIndex() == 0)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (GO.GetIndex() == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Stage");
        }
	}
}
