using UnityEngine;
using System.Collections;

public class ActiveUnitsPlaceSecond : MonoBehaviour {
    public float unitsPlaceNumber = 0.0f;

    public ActiveTensPlaceSecond atps;
    public UI ui;

	void Start () {
        ui = GameObject.Find("UI").GetComponent<UI>();
        atps = GameObject.Find("Timer").GetComponent<ActiveTensPlaceSecond>();
	}

	void Update () {
        if (StageManager.stage1)
        {
            atps.time = StageManager.stage1FallBackTime;
            getUnitsPlaceNumber();
        }

        else if (StageManager.stage2)
        {
            atps.time = StageManager.stage2FallBackTime;
            getUnitsPlaceNumber();
        }

        else if (StageManager.stage3)
        {
            atps.time = StageManager.stage3FallBackTime;
            getUnitsPlaceNumber();
        }

        else if (StageManager.stage4)
        {
            atps.time = StageManager.stage4FallBackTime;
            getUnitsPlaceNumber();
        }

        else if (StageManager.stage5)
        {
            atps.time = StageManager.stage5FallBackTime;
            getUnitsPlaceNumber();
        }
	}

    void getUnitsPlaceNumber()
    {
        atps.presentTime = atps.time + atps.imageTime - Time.time;
        atps.tensPlaceNumber = atps.presentTime / 10;
        unitsPlaceNumber = atps.presentTime - ((int)atps.tensPlaceNumber * 10);
    }
}
