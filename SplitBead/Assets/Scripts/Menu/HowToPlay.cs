using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour {
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
        if (CM.GetIndex() == 1)
        {
            animator.SetBool("On", true);
        }

        else
        {
            animator.SetBool("On", false);
        }

        if (CM.GetIndex() == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(ok, gameObject.transform.position);
            SceneManager.LoadScene("HowToPlay");
        }
    }
}
