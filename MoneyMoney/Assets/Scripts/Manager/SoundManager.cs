using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioClip Main;
    public AudioClip Play;
    public AudioClip Ending;
    public AudioClip clip;
    public AudioSource audioSource;

    public SceneManager sceneMgr;
    public PlayScene playScene;

    private bool isPlayingMain;
    private bool isPlayingQuiz;
    private bool isPlayingEnding;

    public void Initialize()
    {
        isPlayingMain = false;
        isPlayingQuiz = false;
        isPlayingEnding = false;
        StartCoroutine(PlaySound());
    }

    public IEnumerator PlaySound()
    {
        while (true)
        {
            if (sceneMgr.curState == SS.SceneState.MAIN && !isPlayingMain)
            {
                audioSource.Stop();
                AudioSource.PlayClipAtPoint(clip, transform.position);
                yield return new WaitForSeconds(1.0f);
                audioSource.clip = Main;
                audioSource.Play();
                isPlayingQuiz = false;
                isPlayingEnding = false;
                isPlayingMain = true;
            }

            else if (sceneMgr.curState == SS.SceneState.PLAY)
            {
                if ((playScene.curState == PS.SceneState.QUIZ || playScene.curState == PS.SceneState.LIFE) && !isPlayingQuiz)
                {
                    audioSource.Stop();
                    yield return new WaitForSeconds(1.0f);
                    audioSource.clip = Play;
                    audioSource.Play();
                    isPlayingEnding = false;
                    isPlayingMain = false;
                    isPlayingQuiz = true;
                }

                else if (playScene.curState == PS.SceneState.GAMEOVER && !isPlayingEnding)
                {
                    audioSource.Stop();
                    yield return new WaitForSeconds(1.0f);
                    audioSource.clip = Ending;
                    audioSource.Play();
                    isPlayingMain = false;
                    isPlayingQuiz = false;
                    isPlayingEnding = true;
                }
            }

            yield return null;
        }
    }
}
