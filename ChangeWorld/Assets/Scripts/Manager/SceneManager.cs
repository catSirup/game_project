using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    public enum SceneState { MAIN, LOADING, PLAY, EXIT };
    public SceneState curState;

    public Transform t_Main;
    public Transform t_Play;
    public Transform t_Loading;
    public MainManager mainMgr;
    public static int PlayCount;

    public CharacterSelectManager characterSelectMgr;

//    #region Hide SoftKey

#if UNITY_ANDROID
//    static AndroidJavaObject activityInstance;
//    static AndroidJavaObject windowInstance;
//    static AndroidJavaObject viewInstance;

//    const int SYSTEM_UI_FLAG_HIDE_NAVIGATION = 2;
//    const int SYSTEM_UI_FLAG_LAYOUT_STABLE = 256;
//    const int SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION = 512;
//    const int SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN = 1024;
//    const int SYSTEM_UI_FLAG_IMMERSIVE = 2048;
//    const int SYSTEM_UI_FLAG_IMMERSIVE_STICKY = 4096;
//    const int SYSTEM_UI_FLAG_FULLSCREEN = 4;


//    public delegate void RunPtr();

//    public static void Run()
//    {
//        if (viewInstance != null)
//        {
//            viewInstance.Call("setSystemUiVisibility",
//            SYSTEM_UI_FLAG_LAYOUT_STABLE
//            | SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
//            | SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
//            | SYSTEM_UI_FLAG_HIDE_NAVIGATION
//            | SYSTEM_UI_FLAG_FULLSCREEN
//            | SYSTEM_UI_FLAG_IMMERSIVE_STICKY);
//        }

//    }
#endif

    #region DisableNavUI
    //public static void DisableNavUI()
    //{
    //    if (Application.platform != RuntimePlatform.Android)
    //        return;
    //    using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    //    {
    //        activityInstance = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
    //        windowInstance = activityInstance.Call<AndroidJavaObject>("getWindow");
    //        viewInstance = windowInstance.Call<AndroidJavaObject>("getDecorView");

    //        AndroidJavaRunnable RunThis;
    //        RunThis = new AndroidJavaRunnable(new RunPtr(Run));
    //        activityInstance.Call("runOnUiThread", RunThis);
    //    }
    //}
    #endregion

    void OnEnable()
    {
        //DisableNavUI();
        if (Application.isPlaying)
        {
            curState = SceneState.MAIN;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("PlayCount") == 0)
        {
            InitData();
        }

        else
            GetData();

        // 화면 항상 켜지게
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        ManageScene();
    }

    void ManageScene()
    {
        if (curState == SceneState.MAIN)
        {
            t_Main.gameObject.SetActive(true);
            t_Play.gameObject.SetActive(false);
            t_Loading.gameObject.SetActive(false);
        }

        else if (curState == SceneState.LOADING)
        {
            t_Main.gameObject.SetActive(false);
            t_Play.gameObject.SetActive(false);
            t_Loading.gameObject.SetActive(true);
        }

        else if (curState == SceneState.PLAY)
        {
            t_Main.gameObject.SetActive(false);
            t_Play.gameObject.SetActive(true);
            t_Loading.gameObject.SetActive(false);
        }

        else if (curState == SceneState.EXIT)
        {
            PlayCount++;
            PlayerPrefs.SetInt("PlayCount", PlayCount);
            SaveData();

            mainMgr.curState = MainManager.MainState.SET;

            Destroy(gameObject);
            Application.Quit();
        }
    }

    public void InitData()
    {
        PointManager.i_CurHavePoint = 0;

        ReinforceManager.i_CurBulletDamageLevel = 0;
        ReinforceManager.i_CurBulletAreaLevel = 0;
        ReinforceManager.i_CurBulletCycleLevel = 0;
        ReinforceManager.i_CurCharacterGraphicsUpgradeLevel = 0;
        ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel = 0;
        ReinforceManager.i_CurObstacleGraphicsUpgradeLevel = 0;
        ReinforceManager.i_CurPlusPointLevel = 0;
        ReinforceManager.i_CurLoadingLevel = 0;
        ReinforceManager.i_CurLoadingTime = 5f;
        ReinforceManager.b_CanFire = false;
        ReinforceManager.isOpenCharacterSelect = false;
        ReinforceManager.isOpenGotcha = false;

        CharacterOpenValue.isOpenCube = false;
        CharacterOpenValue.isOpenRedBull = false;
        CharacterOpenValue.isOpenBrownOwl = false;
        CharacterOpenValue.isOpenSilverOwl = false;
        CharacterOpenValue.isOpenDragon = false;
        CharacterOpenValue.isOpenMoneybug = false;
        CharacterOpenValue.isOpenTobacco = false;
        CharacterOpenValue.isOpenHealingCat = false;
        CharacterOpenValue.isOpenLamp = false;
        CharacterOpenValue.isOpenEpic = false;
        CharacterOpenValue.isOpenOpticalDragon = false;
        CharacterOpenValue.isOpenYee = false;
        CharacterOpenValue.isOpenKC = false;

        CharacterManager.i_DeadCount = 0;
        characterSelectMgr.curState = CharacterSelectManager.CharacterState.BASIC;
        CharacterSelectManager.i_CurSelectCharacterNumber = 0;

        Ranking.HighScore = 0;
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("i_CurBulletDamageLevel", ReinforceManager.i_CurBulletDamageLevel);
        PlayerPrefs.SetInt("i_CurBulletAreaLevel", ReinforceManager.i_CurBulletAreaLevel);
        PlayerPrefs.SetInt("i_CurBulletCycleLevel", ReinforceManager.i_CurBulletCycleLevel);
        PlayerPrefs.SetInt("i_CurCharacterGraphicsUpgradeLevel", ReinforceManager.i_CurCharacterGraphicsUpgradeLevel);
        PlayerPrefs.SetInt("i_CurBackgroundGraphicsUpgradeLevel", ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel);
        PlayerPrefs.SetInt("i_CurObstacleGraphicsUpgradeLevel", ReinforceManager.i_CurObstacleGraphicsUpgradeLevel);
        PlayerPrefs.SetInt("i_CurPlusPointLevel", ReinforceManager.i_CurPlusPointLevel);
        PlayerPrefs.SetInt("i_CurLoadingLevel", ReinforceManager.i_CurLoadingLevel);
        PlayerPrefs.SetFloat("i_CurLoadingTime", ReinforceManager.i_CurLoadingTime);

        SetBool("isSaveFirst", ReinforceManager.isSaveFirst);
        SetBool("b_CanFire", ReinforceManager.b_CanFire);
        SetBool("isOpenCharacterSelect", ReinforceManager.isOpenCharacterSelect);
        SetBool("isOpenGotcha", ReinforceManager.isOpenGotcha);

        SetBool("isOpenCube", CharacterOpenValue.isOpenCube);
        SetBool("isOpenRedBull", CharacterOpenValue.isOpenRedBull);
        SetBool("isOpenBrownOwl", CharacterOpenValue.isOpenBrownOwl);
        SetBool("isOpenSilverOwl", CharacterOpenValue.isOpenSilverOwl);
        SetBool("isOpenDragon", CharacterOpenValue.isOpenDragon);
        SetBool("isOpenMoneybug", CharacterOpenValue.isOpenMoneybug);
        SetBool("isOpenTobacco", CharacterOpenValue.isOpenTobacco);
        SetBool("isOpenHealingCat", CharacterOpenValue.isOpenHealingCat);
        SetBool("isOpenLamp", CharacterOpenValue.isOpenLamp);
        SetBool("isOpenEpic", CharacterOpenValue.isOpenEpic);
        SetBool("isOpenYee", CharacterOpenValue.isOpenYee);
        SetBool("isOpenOpticalDragon", CharacterOpenValue.isOpenOpticalDragon);
        SetBool("isOpenKC", CharacterOpenValue.isOpenKC);

        PlayerPrefs.SetInt("i_CurHavePoint", PointManager.i_CurHavePoint);
        PlayerPrefs.SetInt("i_DeadCount", CharacterManager.i_DeadCount);
        PlayerPrefs.SetInt("HighScore", Ranking.HighScore);

        PlayerPrefs.SetInt("i_CurSelectCharacterNumber", CharacterSelectManager.i_CurSelectCharacterNumber);

        PlayerPrefs.Save();
    }
	
    public static void SetBool(string name, bool boolValue)
    {
        PlayerPrefs.SetInt(name, boolValue ? 1 : 0);
    }

    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }

    public static void GetData()
    {
        ReinforceManager.i_CurBulletDamageLevel = PlayerPrefs.GetInt("i_CurBulletDamageLevel");
        ReinforceManager.i_CurBulletAreaLevel = PlayerPrefs.GetInt("i_CurBulletAreaLevel");
        ReinforceManager.i_CurBulletCycleLevel = PlayerPrefs.GetInt("i_CurBulletCycleLevel");
        ReinforceManager.i_CurCharacterGraphicsUpgradeLevel = PlayerPrefs.GetInt("i_CurCharacterGraphicsUpgradeLevel");
        ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel = PlayerPrefs.GetInt("i_CurBackgroundGraphicsUpgradeLevel");
        ReinforceManager.i_CurObstacleGraphicsUpgradeLevel = PlayerPrefs.GetInt("i_CurObstacleGraphicsUpgradeLevel");
        ReinforceManager.i_CurPlusPointLevel = PlayerPrefs.GetInt("i_CurPlusPointLevel");
        ReinforceManager.i_CurLoadingLevel = PlayerPrefs.GetInt("i_CurLoadingLevel");
        ReinforceManager.i_CurLoadingTime = PlayerPrefs.GetFloat("i_CurLoadingTime");

        ReinforceManager.b_CanFire = GetBool("b_CanFire");
        ReinforceManager.isOpenCharacterSelect = GetBool("isOpenCharacterSelect");
        ReinforceManager.isOpenGotcha = GetBool("isOpenGotcha");
        ReinforceManager.isSaveFirst = GetBool("isSaveFirst");
        PointManager.i_CurHavePoint = PlayerPrefs.GetInt("i_CurHavePoint");

        CharacterOpenValue.isOpenCube = GetBool("isOpenCube");
        CharacterOpenValue.isOpenRedBull = GetBool("isOpenRedBull");
        CharacterOpenValue.isOpenBrownOwl = GetBool("isOpenBrownOwl");
        CharacterOpenValue.isOpenSilverOwl = GetBool("isOpenSilverOwl");
        CharacterOpenValue.isOpenDragon = GetBool("isOpenDragon");
        CharacterOpenValue.isOpenTobacco = GetBool("isOpenTobacco");
        CharacterOpenValue.isOpenMoneybug = GetBool("isOpenMoneybug");
        CharacterOpenValue.isOpenHealingCat = GetBool("isOpenHealingCat");
        CharacterOpenValue.isOpenLamp = GetBool("isOpenLamp");
        CharacterOpenValue.isOpenYee = GetBool("isOpenYee");
        CharacterOpenValue.isOpenEpic = GetBool("isOpenEpic");
        CharacterOpenValue.isOpenOpticalDragon = GetBool("isOpenOpticalDragon");
        CharacterOpenValue.isOpenKC = GetBool("isOpenKC");

        CharacterManager.i_DeadCount = PlayerPrefs.GetInt("i_DeadCount");
        Ranking.HighScore = PlayerPrefs.GetInt("HighScore");

        CharacterSelectManager.i_CurSelectCharacterNumber = PlayerPrefs.GetInt("i_CurSelectCharacterNumber");
    }

    #region Delay

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.1f);
        mainMgr.curState = MainManager.MainState.MAIN;
        curState = SceneState.MAIN;
    }

    #endregion

    //Debug.Log(System.DateTime.Now); -> 스마트폰에서 현재 시간 가져오기.
    //Debug.Log(Time.realtimeSinceStartup); -> 게임 켜진 순간부터 시간재기.
}
