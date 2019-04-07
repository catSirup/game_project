using UnityEngine;
using System.Collections;

public class ActiveTensPlaceSecond : MonoBehaviour {
    public float tensPlaceNumber = 0.0f;

    public float presentTime = 0.0f;
    public float imageTime = 0.0f;
    public float time = 0.0f;

    public UI ui;

	void Start () {
        ui = GameObject.Find("UI").GetComponent<UI>();
        imageTime = Time.time;
    }

    void OnEnable()
    {
        if (Time.time - imageTime > 0.01f)
        {
            imageTime = Time.time;
        }
    }

    void Update()
    {
        if (StageManager.stage1)
        {
            time = StageManager.stage1FallBackTime;
            stopTimer();
            getTensPlaceNumber();
            closeTimer();
        }

        else if (StageManager.stage2)
        {
            time = StageManager.stage2FallBackTime;
            stopTimer();
            getTensPlaceNumber();
            closeTimer();
        }

        else if (StageManager.stage3)
        {
            time = StageManager.stage3FallBackTime;
            stopTimer();
            getTensPlaceNumber();
            closeTimer();
        }

        else if (StageManager.stage4)
        {
            time = StageManager.stage4FallBackTime;
            stopTimer();
            getTensPlaceNumber();
            closeTimer();
        }

        else if (StageManager.stage5)
        {
            time = StageManager.stage5FallBackTime;
            stopTimer();
            getTensPlaceNumber();
            closeTimer();
        }
    }

    void getTensPlaceNumber()
    {
        presentTime = time - Time.time + imageTime;
        tensPlaceNumber = presentTime / 10;
    }

    void closeTimer()
    {
        if (tensPlaceNumber < 0)
        {
            TimerValueManager.closeTimer = true;
        }
    }

    void stopTimer()
    {
        if (ui.gameover)
        {
            imageTime = Time.time - time + presentTime;
        }
    }
}
