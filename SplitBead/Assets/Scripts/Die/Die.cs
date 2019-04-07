using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "BasicBall" || coll.gameObject.tag == "FastBall" || coll.gameObject.tag == "SeperationBall")
        {
            DieBoolValue.isDie = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}
