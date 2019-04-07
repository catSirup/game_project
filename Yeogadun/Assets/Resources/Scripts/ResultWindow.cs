using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultWindow : MonoBehaviour {
    public Text score;
    
    public void Init(int _score)
    {
        score.text = _score.ToString("");
    }


    public void Button_Restart()
    {
        SceneManager.sceneMgr.SetPrevState(SceneManager.sceneMgr.GetCurState());
        SceneManager.sceneMgr.ChangeScene(SceneState.TEMP);
        gameObject.SetActive(false);
    }

    public void Button_GotoMenu()
    {
        SceneManager.sceneMgr.ChangeScene(SceneState.MAIN);
        gameObject.SetActive(false);
    }
}
