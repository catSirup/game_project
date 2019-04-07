using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public InputManager inputMgr;
    public SceneManager sceneMgr;
    public SoundManager soundMgr;
    public PlayScene playScene;
    public LifeAnimation lifeAnim;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Initialize();
    }

    void Initialize()
    {
        sceneMgr.Initialize();
        inputMgr.Initialize();
        playScene.Initialize();
        lifeAnim.Initialize();
        soundMgr.Initialize();
    }

    void Update()
    {
        inputMgr.InputButton();
        // 버튼 입력에 따른 씬 변경 작성
        switch (sceneMgr.curState)
        {
            case SS.SceneState.MAIN:
                if (inputMgr.isClick)
                {
                    Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
              
                    if (hit.collider != null)
                    {
                        if (hit.collider.name == "Start")
                        {
                            StartCoroutine(StartGame());
                        }

                        else if (hit.collider.name == "Exit")
                            QuitGame();

                        else if (hit.collider.name == "Develop")
                        {
                            sceneMgr.ChangeScene(SS.SceneState.DEVELOP);
                        }
                    }
                }

                if (inputMgr.isKeyDown)
                    QuitGame();
                break;

            case SS.SceneState.PLAY:
                if (inputMgr.isKeyDown)
                    sceneMgr.ChangeScene(SS.SceneState.MAIN);

                // 애니메이션 씬을 호출했을 때
                if (PlayScene.callAnimation)
                {
                    playScene.ChangeScene(PS.SceneState.LIFE);
                    PlayScene.callAnimation = false;
                }

                if (PlayScene.score >= 9990)
                {
                    PlayScene.score = 9999;
                }

                if (playScene.curState == PS.SceneState.GAMEOVER && inputMgr.isClick)
                    sceneMgr.ChangeScene(SS.SceneState.MAIN);

                break;

            case SS.SceneState.DEVELOP:
                if(inputMgr.isClick)
                    sceneMgr.ChangeScene(SS.SceneState.MAIN);
                break;
        }
    }

    void QuitGame()
    {
        Destroy(gameObject.transform.parent.gameObject);
        Application.Quit();
    }

    IEnumerator StartGame()
    {
        PlayScene.score = 0;
        LifeAnimation.lifeCount = 3;
        yield return new WaitForSeconds(0.1f);
        sceneMgr.ChangeScene(SS.SceneState.PLAY);
    }
}
