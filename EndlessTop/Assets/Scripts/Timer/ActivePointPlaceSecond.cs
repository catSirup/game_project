using UnityEngine;
using System.Collections;

public class ActivePointPlaceSecond : MonoBehaviour {
    public float pointPlaceNumber = 0.0f;

    public ActiveTensPlaceSecond atps;
    public ActiveUnitsPlaceSecond aups;
    public UI ui;

	void Start () {
        ui = GameObject.Find("UI").GetComponent<UI>();
        atps = GameObject.Find("Timer").GetComponent<ActiveTensPlaceSecond>();
        aups = GameObject.Find("Timer").GetComponent<ActiveUnitsPlaceSecond>();
	}

	void Update () {
        if (StageManager.stage1)
        {
            atps.time = StageManager.stage1FallBackTime;
            getPointPlaceNumber();
        }

        else if (StageManager.stage2)
        {
            atps.time = StageManager.stage2FallBackTime;
            getPointPlaceNumber();
        }

        else if (StageManager.stage3)
        {
            atps.time = StageManager.stage3FallBackTime;
            getPointPlaceNumber();
        }

        else if (StageManager.stage4)
        {
            atps.time = StageManager.stage4FallBackTime;
            getPointPlaceNumber();
        }

        else if (StageManager.stage5)
        {
            atps.time = StageManager.stage5FallBackTime;
            getPointPlaceNumber();
        }
	}

    void getPointPlaceNumber()
    {
        atps.presentTime = atps.time - Time.time + atps.imageTime;
        atps.tensPlaceNumber = atps.presentTime / 10;
        aups.unitsPlaceNumber = atps.presentTime - ((int)atps.tensPlaceNumber * 10);

        pointPlaceNumber = (atps.presentTime - ((int)atps.tensPlaceNumber * 10) - ((int)aups.unitsPlaceNumber)) * 10;
    }
}
