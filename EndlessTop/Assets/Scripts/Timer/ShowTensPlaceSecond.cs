using UnityEngine;
using System.Collections;

public class ShowTensPlaceSecond : MonoBehaviour {

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

    public ActiveTensPlaceSecond atps;

	void Start () {
        atps = GameObject.Find("Timer").GetComponent<ActiveTensPlaceSecond>();
	}
	
	void Update () {
        NumberCheck();
        ShowNumber();
	}

    void NumberCheck()
    {
        if ((atps.tensPlaceNumber >= 0 && atps.tensPlaceNumber < 1) || TimerValueManager.closeTimer)
        {
            TimerValueManager.second10_Zero = true;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 1 && atps.tensPlaceNumber < 2)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = true;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 2 && atps.tensPlaceNumber < 3)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = true;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 3 && atps.tensPlaceNumber < 4)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = true;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 4 && atps.tensPlaceNumber < 5)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = true;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 5 && atps.tensPlaceNumber < 6)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = true;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 6 && atps.tensPlaceNumber < 7)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = true;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 7 && atps.tensPlaceNumber < 8)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = true;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 8 && atps.tensPlaceNumber < 9)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = true;
            TimerValueManager.second10_Nine = false;
        }

        else if (atps.tensPlaceNumber >= 9)
        {
            TimerValueManager.second10_Zero = false;
            TimerValueManager.second10_One = false;
            TimerValueManager.second10_Two = false;
            TimerValueManager.second10_Three = false;
            TimerValueManager.second10_Four = false;
            TimerValueManager.second10_Five = false;
            TimerValueManager.second10_Six = false;
            TimerValueManager.second10_Seven = false;
            TimerValueManager.second10_Eight = false;
            TimerValueManager.second10_Nine = true;
        }
    }

    void ShowNumber()
    {
        if (TimerValueManager.second10_Zero == true)
        {
            zero.SetActive(true);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
        }

        else if (TimerValueManager.second10_One == true)
        {
            zero.SetActive(false);
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
        }

        else if (TimerValueManager.second10_Two == true)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(true);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
        }

        else if (TimerValueManager.second10_Three == true)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(true);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(false);
        }

        else if (TimerValueManager.second10_Four == true)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(true);
            five.SetActive(false);
            six.SetActive(false);
        }

        else if (TimerValueManager.second10_Five == true)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(true);
            six.SetActive(false);
        }

        else if (TimerValueManager.second10_Six == true)
        {
            zero.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            six.SetActive(true);
        }
    }
}
