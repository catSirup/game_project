using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour {
    GameOver GO;

    Animator animator;
    void Start ()
    {
        animator = GetComponent<Animator>();
        GO = GameObject.Find("Button").GetComponent<GameOver>();
    }
	
	void Update () {
        if (GO.GetIndex() == 1)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (GO.GetIndex() == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
            DieBoolValue.isDie = false;
        }
	}
}
