using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {
    public MainManager mainMgr;
    public SceneManager sceneMgr;

    public GameObject[] go_Tips;
    int i_RandomIndex;

    void OnEnable()
    {
        StartCoroutine(StartGame());

        i_RandomIndex = Random.Range(0, go_Tips.Length);

        for (int i = 0; i < go_Tips.Length; i++)
        {
            if (i == i_RandomIndex)
                go_Tips[i].SetActive(true);
            else
                go_Tips[i].SetActive(false);
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(ReinforceManager.i_CurLoadingTime - (ReinforceManager.i_CurLoadingLevel * 1f));
        mainMgr.curState = MainManager.MainState.START;
        sceneMgr.curState = SceneManager.SceneState.PLAY;
    }
}
