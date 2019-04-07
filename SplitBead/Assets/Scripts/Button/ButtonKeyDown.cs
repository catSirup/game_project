using UnityEngine;
using System.Collections;

public class ButtonKeyDown : MonoBehaviour {
    ButtonAnimation LeftDown;
    ButtonAnimation MiddleDown;
    ButtonAnimation RightDown;
    ButtonAnimation LeftUp;
    ButtonAnimation MiddleUp;
    ButtonAnimation RightUp;

    public AudioClip pushButton;

    private float time = 0.0f;

    SideMenuOnOff sMenu; 
    Library library;

	void Start () {
        LeftUp = GameObject.Find("Square_UpLeft").GetComponent<ButtonAnimation>();
        LeftDown = GameObject.Find("Square_DownLeft").GetComponent<ButtonAnimation>();
        RightUp = GameObject.Find("Square_UpRight").GetComponent<ButtonAnimation>();
        RightDown = GameObject.Find("Square_DownRight").GetComponent<ButtonAnimation>();
        MiddleUp = GameObject.Find("Square_UpMiddle").GetComponent<ButtonAnimation>();
        MiddleDown = GameObject.Find("Square_DownMiddle").GetComponent<ButtonAnimation>();

        library = GameObject.Find("LibraryObject").GetComponent<Library>();
        sMenu = GameObject.Find("Menu").GetComponent<SideMenuOnOff>();
        time = Time.time;
	}
	
	void Update () 
    {
        if (!sMenu.GetOnable())
        {
            // S
            if (Input.GetKeyDown(KeyCode.S) && DeadLineSetBoolValue.UpLeft)
            {
                library.ClearTime(ref time, 0.1f);
                AudioSource.PlayClipAtPoint(pushButton, gameObject.transform.position);
                LeftUp.SetKeyDown(true);
            }
            else if (Input.GetKeyUp(KeyCode.S) || library.GapTime(time) > 1.0f && DeadLineSetBoolValue.UpLeft)
            {
                LeftUp.SetKeyDown(false);
            }

            // D
            if (Input.GetKeyDown(KeyCode.D) && DeadLineSetBoolValue.UpMiddle)
            {
                library.ClearTime(ref time, 0.1f);
                AudioSource.PlayClipAtPoint(pushButton, gameObject.transform.position);
                MiddleUp.SetKeyDown(true);

            }
            else if (Input.GetKeyUp(KeyCode.D) || library.GapTime(time) > 1.0f && DeadLineSetBoolValue.UpMiddle)
            {
                MiddleUp.SetKeyDown(false);
            }

            // F
            if (Input.GetKeyDown(KeyCode.F) && DeadLineSetBoolValue.UpRight)
            {
                library.ClearTime(ref time, 0.1f);
                AudioSource.PlayClipAtPoint(pushButton, gameObject.transform.position);
                RightUp.SetKeyDown(true);
            }
            else if (Input.GetKeyUp(KeyCode.F) || library.GapTime(time) > 1.0f && DeadLineSetBoolValue.UpRight)
            {
                RightUp.SetKeyDown(false);
            }

            // J
            if (Input.GetKeyDown(KeyCode.J) && DeadLineSetBoolValue.DownLeft)
            {
                library.ClearTime(ref time, 0.1f);
                AudioSource.PlayClipAtPoint(pushButton, gameObject.transform.position);
                LeftDown.SetKeyDown(true);
            }
            else if (Input.GetKeyUp(KeyCode.J) || library.GapTime(time) > 1.0f && DeadLineSetBoolValue.DownLeft)
            {
                LeftDown.SetKeyDown(false);
            }

            // K
            if (Input.GetKeyDown(KeyCode.K) && DeadLineSetBoolValue.DownMiddle)
            {
                library.ClearTime(ref time, 0.1f);
                AudioSource.PlayClipAtPoint(pushButton, gameObject.transform.position);
                MiddleDown.SetKeyDown(true);
            }
            else if (Input.GetKeyUp(KeyCode.K) || library.GapTime(time) > 1.0f && DeadLineSetBoolValue.DownMiddle)
            {
                MiddleDown.SetKeyDown(false);
            }

            // L
            if (Input.GetKeyDown(KeyCode.L) && DeadLineSetBoolValue.DownRight)
            {
                library.ClearTime(ref time, 0.1f);
                AudioSource.PlayClipAtPoint(pushButton, gameObject.transform.position);
                RightDown.SetKeyDown(true);
            }
            else if (Input.GetKeyUp(KeyCode.L) || library.GapTime(time) > 1.0f && DeadLineSetBoolValue.DownRight)
            {
                RightDown.SetKeyDown(false);
            }
        }
	}
}
