using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    [HideInInspector]
    public bool pushSpaceKey = false;
    [HideInInspector]
    public bool gameover = false;

	public int count = 0;

    Transform Timer;
    Transform CheckUp;

    Transform StageFont;
    Transform Fallbacktime;
    Transform PushSpace;
    Transform GameOver;
    Transform StartUI;
    Transform StageSideNumber;
    Transform Clear;

    public float time = 0.0f;

	void Start () {
        Timer = GameObject.Find("UI").transform.FindChild("Timer");
        CheckUp = GameObject.Find("UI").transform.FindChild("checkUp");

        StageFont = GameObject.Find("UI").transform.FindChild("StageMainNumber");
        Fallbacktime = GameObject.Find("UI").transform.FindChild("FallBackTime");
        PushSpace = GameObject.Find("UI").transform.FindChild("PushSpace");
        GameOver = GameObject.Find("UI").transform.FindChild("GameOverUI");
        StartUI = GameObject.Find("UI").transform.FindChild("startUI");
        StageSideNumber = GameObject.Find("UI").transform.FindChild("StageFont");
        Clear = GameObject.Find("UI").transform.FindChild("ClearAnimation");

        time = Time.time;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !gameover)
        {
            pushSpaceKey = true;

            Timer.gameObject.SetActive(true);
            CheckUp.gameObject.SetActive(false);
            StageFont.gameObject.SetActive(false);
            Fallbacktime.gameObject.SetActive(false);
            PushSpace.gameObject.SetActive(false);
            GameOver.gameObject.SetActive(false);
        }

        if (gameover)
        {
            ResetTimer();

            if (Time.time - time > 1.5f)
            {
                GameOver.gameObject.SetActive(true);
                Timer.gameObject.SetActive(false);
                StartUI.gameObject.SetActive(false);
                StageSideNumber.gameObject.SetActive(false);
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Application.loadedLevelName == "Stage1")
                {
                    Application.LoadLevel(0);
                }

                else if (Application.loadedLevelName == "Stage2")
                {
                    Application.LoadLevel(1);
                }

                else if (Application.loadedLevelName == "Stage3")
                {
                    Application.LoadLevel(2);
                }

                else if (Application.loadedLevelName == "Stage4")
                {
                    Application.LoadLevel(3);
                }

                else if (Application.loadedLevelName == "Stage5")
                {
                    Application.LoadLevel(4);
                }
            }
        }

        if (TimerValueManager.closeTimer)
        {
            Clear.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

	public void ResetTimer()
	{
		if (Time.time - time > 2.0f)
		{
			time = Time.time;
		}
	}
}
