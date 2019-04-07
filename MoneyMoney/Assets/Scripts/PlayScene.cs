using UnityEngine;
using System.Collections;

namespace PS
{
    public enum SceneState { QUIZ, LIFE, GAMEOVER };
}

public class PlayScene : MonoBehaviour {
    public QuizManager quizMgr;
    public LifeAnimation lifeAnim;
    public GameObject gameOver;
    public SceneManager sceneMgr;
    public PS.SceneState curState;
    public static bool callAnimation;
    public static int score;

    void OnEnable()
    {
        curState = PS.SceneState.QUIZ;
        ChangeScene(curState);
        quizMgr.SelectQuiz();
    }

    public void Initialize()
    {
        callAnimation = false;
        quizMgr.gameObject.SetActive(true);
        lifeAnim.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        ChangeScene(PS.SceneState.QUIZ);
    }


    // 씬 변경
    public void ChangeScene(PS.SceneState state)
    {
        curState = state;

        if (curState == PS.SceneState.QUIZ)
        {
            quizMgr.gameObject.SetActive(true);
            lifeAnim.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
            
        }

        else if (curState == PS.SceneState.LIFE)
        {
            quizMgr.gameObject.SetActive(false);
            lifeAnim.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(false);
        }

        else if (curState == PS.SceneState.GAMEOVER)
        {
            quizMgr.gameObject.SetActive(false);
            lifeAnim.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
        }
    }
}
