using UnityEngine;
using System.Collections;

public class ButtonOff : MonoBehaviour {
    Transform UpLeft;
    Transform UpMiddle;
    Transform UpRight;
    Transform DownLeft;
    Transform DownMiddle;
    Transform DownRight;


	void Start () 
    {
        UpLeft = GameObject.Find("Box").transform.Find("Square_UpLeft");
        UpMiddle = GameObject.Find("Box").transform.Find("Square_UpMiddle");
        UpRight = GameObject.Find("Box").transform.Find("Square_UpRight");
        DownLeft = GameObject.Find("Box").transform.Find("Square_DownLeft");
        DownMiddle = GameObject.Find("Box").transform.Find("Square_DownMiddle");
        DownRight = GameObject.Find("Box").transform.Find("Square_DownRight");
	}
	
	void Update () {

        if (!DieBoolValue.isDie)
        {
            if (DeadLineSetBoolValue.DownLeft)
            {
                DownLeft.gameObject.SetActive(true);
            }

            else
            {
                DownLeft.gameObject.SetActive(false);
            }

            if (DeadLineSetBoolValue.DownRight)
            {
                DownRight.gameObject.SetActive(true);
            }

            else
            {
                DownRight.gameObject.SetActive(false);
            }

            if (DeadLineSetBoolValue.DownMiddle)
            {
                DownMiddle.gameObject.SetActive(true);
            }

            else
            {
                DownMiddle.gameObject.SetActive(false);
            }

            if (DeadLineSetBoolValue.UpLeft)
            {
                UpLeft.gameObject.SetActive(true);
            }

            else
            {
                UpLeft.gameObject.SetActive(false);
            }

            if (DeadLineSetBoolValue.UpRight)
            {
                UpRight.gameObject.SetActive(true);
            }

            else
            {
                UpRight.gameObject.SetActive(false);
            }

            if (DeadLineSetBoolValue.UpMiddle)
            {
                UpMiddle.gameObject.SetActive(true);
            }

            else
            {
                UpMiddle.gameObject.SetActive(false);
            }
        }
	}
}
