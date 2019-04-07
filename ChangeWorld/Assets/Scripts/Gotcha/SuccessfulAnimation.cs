using UnityEngine;
using System.Collections;

public class SuccessfulAnimation : MonoBehaviour {
    public static bool isAppear;

    void OnEnable()
    {
        isAppear = true;
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        isAppear = false;
    }
}
