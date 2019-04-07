using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {
    public enum StoreState { CHARACTER = 0, SYSTEM };
    public StoreState curState;

    public Transform t_CharacterWindow;
    public Transform t_SystemWindow;

    void Start()
    {
        curState = StoreState.CHARACTER;
    }

    void Update()
    {
        if (curState == StoreState.CHARACTER)
        {
            t_CharacterWindow.gameObject.SetActive(true);
            t_SystemWindow.gameObject.SetActive(false);
        }

        else if (curState == StoreState.SYSTEM)
        {
            t_CharacterWindow.gameObject.SetActive(false);
            t_SystemWindow.gameObject.SetActive(true);
        }
    }
}
