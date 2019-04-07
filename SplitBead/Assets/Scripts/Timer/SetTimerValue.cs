using UnityEngine;
using System.Collections;

public class SetTimerValue : MonoBehaviour {
    TimerManager timeManager;

    /// <summary>
    /// 각 자리를 나타내는 변수
    /// </summary>
    private float hundredsPlaceNumber = 0.0f;
    private float tensPlaceNumber = 0.0f;
    private float unitsPlaceNumber = 0.0f;
    private float pointsPlaceNumber = 0.0f;

	void Start ()
    {
        timeManager = GameObject.Find("Timer").GetComponent<TimerManager>();
	}

    /// <summary>
    /// Set_();
    /// </summary>
    public void SetHundredsPlaceNumber()
    {
        if (!DieBoolValue.isDie)
            hundredsPlaceNumber = timeManager.GetPresentTime() / 100;

        else
            hundredsPlaceNumber = EndTime.endTime / 100;
    }

    public void SetTensPlaceNumber()
    {
        if (!DieBoolValue.isDie)
            tensPlaceNumber = (timeManager.GetPresentTime() - (int)hundredsPlaceNumber * 100) / 10;
        else
            tensPlaceNumber = (EndTime.endTime - (int)hundredsPlaceNumber * 100) / 10;
    }

    public void SetUnitsPlaceNumber()
    {
        if (!DieBoolValue.isDie)
            unitsPlaceNumber = timeManager.GetPresentTime() - ((int)hundredsPlaceNumber * 100) - ((int)tensPlaceNumber * 10);
        else
            unitsPlaceNumber = EndTime.endTime - ((int)hundredsPlaceNumber * 100) - ((int)tensPlaceNumber * 10);
    }

    public void SetPointsPlaceNumber()
    {
        if (!DieBoolValue.isDie)
            pointsPlaceNumber = (timeManager.GetPresentTime() - ((int)hundredsPlaceNumber * 100) - ((int)tensPlaceNumber * 10) - (int)unitsPlaceNumber) * 10;
        else
            pointsPlaceNumber = (EndTime.endTime - ((int)hundredsPlaceNumber * 100) - ((int)tensPlaceNumber * 10) - (int)unitsPlaceNumber) * 10;
    }

    /// <summary>
    /// Get_();
    /// </summary>
    /// <returns></returns>
    public float GetHundredsPlaceNumber()
    {
        return hundredsPlaceNumber;
    }

    public float GetTensPlaceNumber()
    {
        return tensPlaceNumber;
    }

    public float GetUnitsPlaceNumber()
    {
        return unitsPlaceNumber;
    }

    public float GetPointsPlaceNumber()
    {
        return pointsPlaceNumber;
    }
}
