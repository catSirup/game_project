using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {
    public enum MainState { SET, LOGO, TITLE, MAIN, GOTCHA, CHARACTERSELECT, STORE, START };
    public MainState curState;

    public Transform t_Logo;
    public Transform t_Title;
    public Transform t_Main;
    public Transform t_Gotcha;
    public Transform t_CharacterStoreWindow;
    public Transform t_Store;

    public SceneManager sceneMgr;
    public CharacterManager characterMgr;

    bool isSet = false;
    bool isPlayingLogo = false;

    void Awake()
    {
        curState = MainState.SET;
    }

    void OnEnable()
    {
        if (!Application.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Application.isPlaying)
        {
            switch (curState)
            {
                case MainState.SET:
                    t_Logo.gameObject.SetActive(false);
                    t_Title.gameObject.SetActive(false);
                    t_Main.gameObject.SetActive(false);
                    t_Gotcha.gameObject.SetActive(false);
                    t_CharacterStoreWindow.gameObject.SetActive(false);
                    t_Store.gameObject.SetActive(false);

                    if (!isSet)
                    {
                        StartCoroutine(Setting());
                        isSet = true;
                    }
                    
                    break;

                case MainState.LOGO:
                    t_Logo.gameObject.SetActive(true);
                    t_Title.gameObject.SetActive(false);
                    t_Main.gameObject.SetActive(false);
                    t_Gotcha.gameObject.SetActive(false);
                    t_CharacterStoreWindow.gameObject.SetActive(false);
                    t_Store.gameObject.SetActive(false);

                    if (!isPlayingLogo)
                    {
                        StartCoroutine(Logo());
                        isPlayingLogo = true;
                    }

                    break;

                case MainState.TITLE:
                    t_Logo.gameObject.SetActive(false);
                    t_Title.gameObject.SetActive(true);
                    t_Main.gameObject.SetActive(false);
                    t_Gotcha.gameObject.SetActive(false);
                    t_CharacterStoreWindow.gameObject.SetActive(false);
                    t_Store.gameObject.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                        StartCoroutine(DelayTime(MainState.MAIN));

                    if (Input.GetKeyDown(KeyCode.Escape))
                        sceneMgr.curState = SceneManager.SceneState.EXIT;

                    break;

                case MainState.MAIN:
                    t_Logo.gameObject.SetActive(false);
                    t_Title.gameObject.SetActive(false);
                    t_Main.gameObject.SetActive(true);
                    t_Gotcha.gameObject.SetActive(false);
                    t_CharacterStoreWindow.gameObject.SetActive(false);
                    t_Store.gameObject.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.Escape))
                        StartCoroutine(DelayTime(MainState.TITLE));

                    break;

                case MainState.GOTCHA:
                    t_Logo.gameObject.SetActive(false);
                    t_Title.gameObject.SetActive(false);
                    t_Main.gameObject.SetActive(false);
                    t_Gotcha.gameObject.SetActive(true);
                    t_CharacterStoreWindow.gameObject.SetActive(false);
                    t_Store.gameObject.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.Escape))
                        curState = MainState.MAIN;

                    break;

                case MainState.CHARACTERSELECT:
                    t_Logo.gameObject.SetActive(false);
                    t_Title.gameObject.SetActive(false);
                    t_Main.gameObject.SetActive(false);
                    t_Gotcha.gameObject.SetActive(false);
                    t_CharacterStoreWindow.gameObject.SetActive(true);
                    t_Store.gameObject.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.Escape))
                        curState = MainState.MAIN;

                    break;

                case MainState.STORE:
                    t_Logo.gameObject.SetActive(false);
                    t_Title.gameObject.SetActive(false);
                    t_Main.gameObject.SetActive(false);
                    t_Gotcha.gameObject.SetActive(false);
                    t_CharacterStoreWindow.gameObject.SetActive(false);
                    t_Store.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Escape))
                        curState = MainState.MAIN;
                    break;

                case MainState.START:
                    StartCoroutine(DelayTime(SceneManager.SceneState.LOADING));
                    break;
            }

            MaximumPoint();
            MaximumScore();

        }
    }

    void MaximumPoint()
    {
        if (PointManager.i_CurHavePoint >= 9999)
        {
            PointManager.i_CurHavePoint = 9999;
        }
    }

    void MaximumScore()
    {
        if (CharacterManager.i_GainScore >= 99999)
        {
            CharacterManager.i_GainScore = 99999;
        }
    }

    IEnumerator DelayTime(SceneManager.SceneState state)
    {
        yield return new WaitForSeconds(0.2f);
        sceneMgr.curState = state;
    }

    IEnumerator DelayTime(MainManager.MainState state)
    {
        yield return new WaitForSeconds(0.2f);
        curState = state;
    }

    IEnumerator Setting()
    {
        yield return new WaitForSeconds(1);
        Screen.SetResolution(1280, 720, true);
        yield return new WaitForSeconds(1);
        curState = MainState.LOGO;
    }

    IEnumerator Logo()
    {
        yield return new WaitForSeconds(5.5f);
        curState = MainState.TITLE;
    }
}
