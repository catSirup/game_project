using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public bool isKeyDown;
    public bool isClick;

    public void Initialize()
    {
        isKeyDown = false;
        isClick = false;
    }

    public void InputButton()
    {
        // 백스페이스 버튼 누름
        if (Input.GetKeyDown(KeyCode.Escape))
            isKeyDown = true;
        else
            isKeyDown = false;

        // 마우스 버튼 누름
        if (Input.GetMouseButtonDown(0))
            isClick = true;
        else
            isClick = false;
    }
}
