using UnityEngine;
using System.Collections;

public class LifeAnimation : MonoBehaviour {
    public static int lifeCount;
    public PlayScene playScene;
    public GameObject[] lifes;
    private int index;

    void OnEnable()
    {
        StartCoroutine(ChangeScene());
    }

    public void Initialize()
    {
        lifeCount = 3;
        index = 0;
    }

    IEnumerator ChangeScene()
    {
        ShowLifeCount();
        yield return new WaitForSeconds(3.0f);

        if (lifeCount > 0)
            playScene.ChangeScene(PS.SceneState.QUIZ);
        else
            playScene.ChangeScene(PS.SceneState.GAMEOVER);
    }

    void ShowLifeCount()
    {
        for (index = 0; index < lifes.Length; index++)
        {
            if (index < lifeCount)
                lifes[index].SetActive(true);
            else
                lifes[index].SetActive(false);
        }
    }
}
