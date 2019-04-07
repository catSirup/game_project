using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
    public AudioClip ok;
    private Animator animator;
    ChoiceMenu CM;
    void Start()
    {
        animator = GetComponent<Animator>();
        CM = GameObject.Find("Menu").GetComponent<ChoiceMenu>();
    }

    void Update()
    {
        if (CM.GetIndex() == 3)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (CM.GetIndex() == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(ok, gameObject.transform.position);
            Application.Quit();
        }
    }
}
