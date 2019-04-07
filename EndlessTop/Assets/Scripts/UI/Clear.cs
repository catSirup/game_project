using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

	public UI ui;
    public float cTime = 0.0f;

	void Start () {
		ui = GameObject.Find ("UI").GetComponent<UI> ();
	}

    void Update()
    {
        if (StageManager.stage1 == true && TimerValueManager.closeTimer)
        {
            ClearTimer();
            if (Time.time - cTime > 4.0f)
            {
                StageManager.stage1 = false;
                StageManager.stage2 = true;
                TimerValueManager.closeTimer = false;
                ClearTimer();
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }

        if (StageManager.stage2 == true && TimerValueManager.closeTimer)
        {
            ClearTimer();
            if (Time.time - cTime > 4.0f)
            {
                StageManager.stage2 = false;
                StageManager.stage3 = true;
                TimerValueManager.closeTimer = false;
                ClearTimer();
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }

        if (StageManager.stage3 == true && TimerValueManager.closeTimer)
        {
            ClearTimer();
            if (Time.time - cTime > 4.0f)
            {
                StageManager.stage3 = false;
                StageManager.stage4 = true;
                TimerValueManager.closeTimer = false;
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }

        if (StageManager.stage4 == true && TimerValueManager.closeTimer)
        {
            ClearTimer();
            if (Time.time - cTime > 4.0f)
            {
                StageManager.stage4 = false;
                StageManager.stage5 = true;
                TimerValueManager.closeTimer = false;
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }

        if (StageManager.stage5 == true && TimerValueManager.closeTimer)
        {
            ClearTimer();
            if (Time.time - cTime > 4.0f)
            {
                StageManager.stage5 = false;
                StageManager.ending = true;
                TimerValueManager.closeTimer = false;
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
	}

    void ClearTimer()
    {
        if (Time.time - cTime > 4.1f)
        {
            cTime = Time.time;
        }
    }
}
