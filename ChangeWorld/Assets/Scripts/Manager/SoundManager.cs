using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public SceneManager sceneMgr;
    public MainManager mainMgr;
    public CharacterSelectManager characterSelectMgr;
    public CharacterManager characterMgr;

    public AudioClip backgroundSound;
    public AudioClip gotcha;
    public AudioClip store;
    public AudioClip characterSelect;
    //public AudioClip[] backgroundSound;
    public AudioClip[] ExSound;
    AudioSource audioSource;

    bool isPlayBackgroundSound;
    bool isPlayStoreSound;
    bool isPlayGotchaSound;
    bool isPlaySelectSound;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        isPlayBackgroundSound = false;
        isPlayStoreSound = false;
        isPlayGotchaSound = false;
        isPlaySelectSound = false;
    }

    void Update()
    {
        audioSource.volume = 0.5f;
        switch (mainMgr.curState)
        {
            case MainManager.MainState.TITLE:
            case MainManager.MainState.MAIN:

                if (!isPlayBackgroundSound)
                {
                    audioSource.clip = backgroundSound;
                    audioSource.loop = true;
                    audioSource.Play();

                    isPlayGotchaSound = false;
                    isPlaySelectSound = false;
                    isPlayStoreSound = false;
                    isPlayBackgroundSound = true;
                }
                break;

            case MainManager.MainState.CHARACTERSELECT:
                if (!isPlaySelectSound)
                {
                    audioSource.Stop();
                    audioSource.clip = characterSelect;
                    audioSource.loop = true;
                    audioSource.Play();

                    isPlayGotchaSound = false;
                    isPlayStoreSound = false;
                    isPlayBackgroundSound = false;
                    isPlaySelectSound = true;
                }
                break;

            case MainManager.MainState.STORE:
                if (!isPlayStoreSound)
                {
                    audioSource.Stop();
                    audioSource.clip = store;
                    audioSource.loop = true;
                    audioSource.Play();

                    isPlayGotchaSound = false;
                    isPlaySelectSound = false;
                    isPlayBackgroundSound = false;
                    isPlayStoreSound = true;
                }
                break;

            case MainManager.MainState.GOTCHA:
                if (!isPlayGotchaSound)
                {
                    audioSource.Stop();
                    audioSource.clip = gotcha;
                    audioSource.loop = true;
                    audioSource.Play();

                    isPlaySelectSound = false;
                    isPlayBackgroundSound = false;
                    isPlayStoreSound = false;
                    isPlayGotchaSound = true;
                }
                break;
        }

        switch (sceneMgr.curState)
        {
            case SceneManager.SceneState.LOADING:
                isPlaySelectSound = false;
                isPlayBackgroundSound = false;
                isPlayStoreSound = false;
                isPlayGotchaSound = false;
                audioSource.Stop();
                break;

            case SceneManager.SceneState.PLAY:
                if (!isPlayBackgroundSound && Explanation.b_IsDisapear)
                {
                    if (characterSelectMgr.curState == CharacterSelectManager.CharacterState.EPIC)
                    {
                        audioSource.clip = ExSound[0];
                    }

                    else if (characterSelectMgr.curState == CharacterSelectManager.CharacterState.YEE)
                    {
                        audioSource.clip = ExSound[1];
                        audioSource.volume = 0.7f;
                    }

                    else
                    {
                        audioSource.clip = backgroundSound;
                    }

                    audioSource.loop = true;
                    audioSource.Play();
                    isPlayBackgroundSound = true;
                }

                if (isPlayBackgroundSound && CharacterManager.isBumped)
                {
                    isPlaySelectSound = false;
                    isPlayBackgroundSound = false;
                    isPlayStoreSound = false;
                    isPlayGotchaSound = false;
                    audioSource.Stop();
                }

                break;
        }
    }
}
