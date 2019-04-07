using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
    public Dictionary<string, AudioClip> clip;
    public static SoundManager soundMgr = null;

    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private AudioSource audioSource;

    public void Initialize()
    {
        if (soundMgr == null) soundMgr = this;
        else if (soundMgr != this) Destroy(this.gameObject);

        clip = new Dictionary<string, AudioClip>();

        clip.Add("GameOver", clips[0]);
        clip.Add("Word_BGM", clips[1]);
        clip.Add("Word_Click", clips[2]);
        clip.Add("Word_Correct", clips[3]);
        clip.Add("Word_Incorrect", clips[4]);
        clip.Add("Ball_BGM", clips[5]);
        clip.Add("Ball_Correct", clips[6]);
        clip.Add("Ball_Incorrect", clips[7]);
        clip.Add("Flower_Drag1", clips[8]);
        clip.Add("Flower_Drag2", clips[9]);
        clip.Add("Flower_BGM", clips[10]);
        clip.Add("Catchmind_NextQuestion", clips[11]);
        clip.Add("Catchmind_NextQuestionChanging", clips[12]);
        clip.Add("Catchmind_Correct", clips[13]);
        clip.Add("Catchmind_Incorrect", clips[14]);
        clip.Add("Catchmind_BGM", clips[15]);
        clip.Add("StartingGame", clips[16]);
        clip.Add("ReadyGo", clips[17]);
        clip.Add("MainBGM", clips[18]);
        clip.Add("BBOCKBBOCK", clips[19]);
        clip.Add("Timelimit1", clips[20]);
        clip.Add("Timelimet2", clips[21]);
    }

    public void PlayBGM(string name)
    {
        audioSource.clip = clip[name];
        audioSource.Play();
    }

    public void PlayES(string name)
    {
        AudioSource.PlayClipAtPoint(clip[name], Camera.main.transform.position);
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
