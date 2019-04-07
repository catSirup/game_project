using UnityEngine;
using System.Collections;

namespace SS
{
    public enum SceneState { SET = -1, MAIN = 0, PLAY, DEVELOP };
}

public class SceneManager : MonoBehaviour {
    public GameObject[] scenes;
    public SS.SceneState curState;
    public SoundManager soundMgr;

    private int index;

    // 초기화
    public void Initialize()
    {
        index = 0;
        curState = SS.SceneState.SET;
        StartCoroutine(SetScreen(2.0f));
    }

    // 씬 변경
    public void ChangeScene(SS.SceneState state)
    {
        curState = state;
        for (index = 0; index < scenes.Length; index++)
        {
            if (index == (int)curState)
                scenes[index].SetActive(true);
            else
                scenes[index].SetActive(false);
        }
    }

    // 스크린 세팅
    IEnumerator SetScreen(float time)
    {
        if (curState == SS.SceneState.SET)
        {
            for (index = 0; index < scenes.Length; index++)
                scenes[index].SetActive(false);

            Screen.SetResolution(1280, 720, true);
            yield return new WaitForSeconds(time);
            ChangeScene(SS.SceneState.MAIN);
        }
    }
}
