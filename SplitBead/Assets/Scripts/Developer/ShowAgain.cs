using UnityEngine;
using System.Collections;

public class ShowAgain : MonoBehaviour {
    Transform LeftDown;
    Transform MiddleDown;
    Transform RightDown;
    Transform LeftUp;
    Transform MiddleUp;
    Transform RightUp;

    Library library;
    DelayTimeValue DTV;

	void Start () 
    {
        LeftDown = GameObject.Find("DeadLineDown").transform.Find("LeftDown");
        MiddleDown = GameObject.Find("DeadLineDown").transform.Find("MiddleDown");
        RightDown = GameObject.Find("DeadLineDown").transform.Find("RightDown");

        LeftUp = GameObject.Find("DeadLineUp").transform.Find("LeftUp");
        MiddleUp = GameObject.Find("DeadLineUp").transform.Find("MiddleUp");
        RightUp = GameObject.Find("DeadLineUp").transform.Find("RightUp");

        library = GameObject.Find("LibraryObject").GetComponent<Library>();
        DTV = GameObject.Find("LibraryObject").GetComponent<DelayTimeValue>();
	}
	
	void Update () 
    {
        if (!DeadLineSetBoolValue.DownLeft && library.GapTime(DTV.GetDeleyTime1()) > 3.0f)
        {
            DeadLineSetBoolValue.DownLeft = true;
            LeftDown.gameObject.SetActive(true);
        }


        if (!DeadLineSetBoolValue.DownMiddle && library.GapTime(DTV.GetDeleyTime2()) > 3.0f)
        {
            DeadLineSetBoolValue.DownMiddle = true;
            MiddleDown.gameObject.SetActive(true);
        }

        if (!DeadLineSetBoolValue.DownRight && library.GapTime(DTV.GetDeleyTime3()) > 3.0f)
        {
            DeadLineSetBoolValue.DownRight = true;
            RightDown.gameObject.SetActive(true);
        }

        if (!DeadLineSetBoolValue.UpLeft && library.GapTime(DTV.GetDeleyTime4()) > 3.0f)
        {
            DeadLineSetBoolValue.UpLeft = true;
            LeftUp.gameObject.SetActive(true);
        }

        if (!DeadLineSetBoolValue.UpMiddle && library.GapTime(DTV.GetDeleyTime5()) > 3.0f)
        {
            DeadLineSetBoolValue.UpMiddle = true;
            MiddleUp.gameObject.SetActive(true);
        }

        if (!DeadLineSetBoolValue.UpRight && library.GapTime(DTV.GetDeleyTime6()) > 3.0f)
        {
            DeadLineSetBoolValue.UpRight = true;
            RightUp.gameObject.SetActive(true);
        }
	}
}
