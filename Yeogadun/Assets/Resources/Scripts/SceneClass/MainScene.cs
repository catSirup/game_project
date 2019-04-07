using UnityEngine;
using System.Collections;

public class MainScene : Scene
{
    [SerializeField]
    private GameObject mainText;

    public override void Initialize()
    {
        if (SoundManager.soundMgr.GetAudioSource().clip != SoundManager.soundMgr.clip["MainBGM"])
        {
            SoundManager.soundMgr.StopBGM();
            SoundManager.soundMgr.PlayBGM("MainBGM");
        }

        mainText.SetActive(true);
    }

    public override void Updated()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.sceneMgr.ChangeScene(SceneState.TITLE);
    }

    public override void Exit()
    {
        mainText.SetActive(false);
    }

    #region MainScene Button
    public void Button_WordGame()
    {
        SceneManager.sceneMgr.ChangeScene(SceneState.WORDGAME);
    }

    public void Button_YabaweeGame()
    {
        SceneManager.sceneMgr.ChangeScene(SceneState.YABAWEE);
    }

    public void Button_CardGame()
    {
        SceneManager.sceneMgr.ChangeScene(SceneState.COLOR);
    }

    public void Button_CatchMindGame()
    {
        SceneManager.sceneMgr.ChangeScene(SceneState.CATCHMAIND);
    }
    #endregion
}
