using UnityEngine;
using System.Collections;

public class ShowPointPlaceSecond : MonoBehaviour {
   
    public GameObject zero;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;

    public ActivePointPlaceSecond apps;

	void Start () {
        apps = GameObject.Find("Timer").GetComponent<ActivePointPlaceSecond>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckNumber();
        ShowNumber();
	}

    void CheckNumber()
    {
        if ((apps.pointPlaceNumber >= 0 && apps.pointPlaceNumber < 1) || TimerValueManager.closeTimer)
        {
            TimerValueManager.second0_Zero = true;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 1 && apps.pointPlaceNumber < 2)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = true;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 2 && apps.pointPlaceNumber < 3)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = true;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 3 && apps.pointPlaceNumber < 4)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = true;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 4 && apps.pointPlaceNumber < 5)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = true;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 5 && apps.pointPlaceNumber < 6)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = true;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 6 && apps.pointPlaceNumber < 7)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = true;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 7 && apps.pointPlaceNumber < 8)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = true;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 8 && apps.pointPlaceNumber < 9)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = true;
            TimerValueManager.second0_Nine = false;
        }

        else if (apps.pointPlaceNumber >= 9)
        {
            TimerValueManager.second0_Zero = false;
            TimerValueManager.second0_One = false;
            TimerValueManager.second0_Two = false;
            TimerValueManager.second0_Three = false;
            TimerValueManager.second0_Four = false;
            TimerValueManager.second0_Five = false;
            TimerValueManager.second0_Six = false;
            TimerValueManager.second0_Seven = false;
            TimerValueManager.second0_Eight = false;
            TimerValueManager.second0_Nine = true;
        }
    }

    void ShowNumber()
    {
        if (TimerValueManager.second0_Zero)
        {
            zero.SetActive(true);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_One)
        {
            zero.SetActive(false);
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Two)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(true);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Three)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(true);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Four)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(true);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Five)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(true);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Six)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(true);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Seven)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(true);
            eight.SetActive(false);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Eight)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(true);
            nine.SetActive(false);
        }

        else if (TimerValueManager.second0_Nine)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
            seven.SetActive(false);
            eight.SetActive(false);
            nine.SetActive(true);
        }
    }
}
