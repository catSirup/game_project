using UnityEngine;
using System.Collections;

public class ShowUnitsPlaceSecond : MonoBehaviour {

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

    public ActiveUnitsPlaceSecond aups;

	void Start () {
        aups = GameObject.Find("Timer").GetComponent<ActiveUnitsPlaceSecond>();
	}
	

	void Update () {
        NumberCheck();
        ShowNumber();
	}

    void NumberCheck()
    {
        if ((aups.unitsPlaceNumber >= 0 && aups.unitsPlaceNumber < 1) || TimerValueManager.closeTimer)
        {
            TimerValueManager.second1_Zero = true;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 1 && aups.unitsPlaceNumber < 2)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = true;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 2 && aups.unitsPlaceNumber < 3)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = true;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 3 && aups.unitsPlaceNumber < 4)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = true;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 4 && aups.unitsPlaceNumber < 5)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = true;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 5 && aups.unitsPlaceNumber < 6)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = true;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 6 && aups.unitsPlaceNumber < 7)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = true;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 7 && aups.unitsPlaceNumber < 8)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = true;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 8 && aups.unitsPlaceNumber < 9)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = true;
            TimerValueManager.second1_Nine = false;
        }

        else if (aups.unitsPlaceNumber >= 9)
        {
            TimerValueManager.second1_Zero = false;
            TimerValueManager.second1_One = false;
            TimerValueManager.second1_Two = false;
            TimerValueManager.second1_Three = false;
            TimerValueManager.second1_Four = false;
            TimerValueManager.second1_Five = false;
            TimerValueManager.second1_Six = false;
            TimerValueManager.second1_Seven = false;
            TimerValueManager.second1_Eight = false;
            TimerValueManager.second1_Nine = true;
        }
    }

    void ShowNumber()
    {
        if (TimerValueManager.second1_Zero)
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

        else if (TimerValueManager.second1_One)
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

        else if (TimerValueManager.second1_Two)
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

        else if (TimerValueManager.second1_Three)
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

        else if (TimerValueManager.second1_Four)
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

        else if (TimerValueManager.second1_Five)
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

        else if (TimerValueManager.second1_Six)
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

        else if (TimerValueManager.second1_Seven)
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

        else if (TimerValueManager.second1_Eight)
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

        else if (TimerValueManager.second1_Nine)
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
