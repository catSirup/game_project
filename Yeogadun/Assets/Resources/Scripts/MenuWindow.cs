using UnityEngine;
using System.Collections;

public class MenuWindow : MonoBehaviour {
    public void Button_Restart()
    {
        SceneManager.sceneMgr.SetPrevState(SceneManager.sceneMgr.GetCurState());
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.sceneMgr.ChangeScene(SceneState.TEMP);
    }

    public void Button_Play()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Button_GotoMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.sceneMgr.ChangeScene(SceneState.MAIN);
    }
}
