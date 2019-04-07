using UnityEngine;
using System.Collections;

public class UnitsPlaceNumberRender : MonoBehaviour {

    public GameObject Zero;
    public GameObject One;
    public GameObject Two;
    public GameObject Three;
    public GameObject Four;
    public GameObject Five;
    public GameObject Six;
    public GameObject Seven;
    public GameObject Eight;
    public GameObject Nine;

    SetTimerValue timeValue;

    void Start()
    {
        timeValue = GameObject.Find("Timer").GetComponent<SetTimerValue>();
    }

    public void Render()
    {
        if (timeValue.GetUnitsPlaceNumber() > 0.0f && timeValue.GetUnitsPlaceNumber() <= 1.0f)
        {
            Zero.SetActive(true);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 1.0f && timeValue.GetUnitsPlaceNumber() <= 2.0f)
        {
            Zero.SetActive(false);
            One.SetActive(true);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 2.0f && timeValue.GetUnitsPlaceNumber() <= 3.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(true);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 3.0f && timeValue.GetUnitsPlaceNumber() <= 4.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(true);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 4.0f && timeValue.GetUnitsPlaceNumber() <= 5.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(true);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 5.0f && timeValue.GetUnitsPlaceNumber() <= 6.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(true);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 6.0f && timeValue.GetUnitsPlaceNumber() <= 7.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(true);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 7.0f && timeValue.GetUnitsPlaceNumber() <= 8.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(true);
            Eight.SetActive(false);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 8.0f && timeValue.GetUnitsPlaceNumber() <= 9.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(true);
            Nine.SetActive(false);
        }

        else if (timeValue.GetUnitsPlaceNumber() > 9.0f)
        {
            Zero.SetActive(false);
            One.SetActive(false);
            Two.SetActive(false);
            Three.SetActive(false);
            Four.SetActive(false);
            Five.SetActive(false);
            Six.SetActive(false);
            Seven.SetActive(false);
            Eight.SetActive(false);
            Nine.SetActive(true);
        }
    }
}
