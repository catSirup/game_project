using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour {

    private float presentTime = 0.0f;
    private float time;

    SideMenuOnOff sMenu;

    SetTimerValue timeValue;
    HundredsPlaceNumberRender hp;
    TensPlaceNumberRender tp;
    UnitsPlaceNumberRender up;
    PointPlaceNumberRender pp;

    void Start()
    {
        timeValue = GameObject.Find("Timer").GetComponent<SetTimerValue>();
        hp = GameObject.Find("Hundred`sPlace").GetComponent<HundredsPlaceNumberRender>();
        tp = GameObject.Find("Ten`sPlace").GetComponent<TensPlaceNumberRender>();
        up = GameObject.Find("Unit`sPlace").GetComponent<UnitsPlaceNumberRender>();
        pp = GameObject.Find("Point`sPlace").GetComponent<PointPlaceNumberRender>();
        SetTime();
    }
	
	void Update ()
    {
        //Debug.Log(Time.time);
        if (!DieBoolValue.isDie)
        {
            SetPresentTIme();
            EndTime.endTime = GetPresentTime();
        }
        //시간을 계속 저장.
        timeValue.SetHundredsPlaceNumber();
        timeValue.SetTensPlaceNumber();
        timeValue.SetUnitsPlaceNumber();
        timeValue.SetPointsPlaceNumber();

        timeValue.GetHundredsPlaceNumber();
        timeValue.GetTensPlaceNumber();
        timeValue.GetUnitsPlaceNumber();
        timeValue.GetPointsPlaceNumber();

        hp.Render();
        tp.Render();
        up.Render();
        pp.Render();
	}

    public void SetTime()
    {
        time = Time.time;
    }

    public float GetTime()
    {
        return time;
    }

    public void SetPresentTIme()
    {
        presentTime = Time.time - GetTime();
    }

    public float GetPresentTime()
    {
        return presentTime;
    }
}
