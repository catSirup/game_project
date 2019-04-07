using UnityEngine;
using System.Collections;

public class GotchaManager : MonoBehaviour {
    public GotchaButton gotchaButton;

    void OnEnable()
    {
        gotchaButton.Init();
    }

    void Update()
    {
        gotchaButton.Gotcha();
    }
}
