using UnityEngine;
using System.Collections;

public class TitleScene : Scene 
{
    [SerializeField]
    private GameObject titleText;

    public override void Initialize()
    {
        titleText.SetActive(true);

        if(SoundManager.soundMgr.GetAudioSource().clip != SoundManager.soundMgr.clip["MainBGM"])
            SoundManager.soundMgr.PlayBGM("MainBGM");
    }

    public override void Updated()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.QuitGame();

        if (Input.GetMouseButtonDown(0))
            SceneManager.sceneMgr.ChangeScene(SceneState.MAIN);
    }

    public override void Exit()
    {
        titleText.SetActive(false);
    }
}
