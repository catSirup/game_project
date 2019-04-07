using UnityEngine;
using System.Collections;

public class InputKey : MonoBehaviour {
    Transform Page1;
    Transform Page2;
    Transform Page3;

    private int index = 0;
	void Start () {
        Page1 = gameObject.transform.Find("1Page");
        Page2 = gameObject.transform.Find("2Page");
        Page3 = gameObject.transform.Find("3Page");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index += 1;

            if (index > 2)
            {
                index -= 1;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index -= 1;

            if (index < 0)
            {
                index += 1;
            }
        }

        ActivePage();
	}

    void ActivePage()
    {
        if (index == 0)
        {
            Page1.gameObject.SetActive(true);
            Page2.gameObject.SetActive(false);
            Page3.gameObject.SetActive(false);
        }

        else if (index == 1)
        {
            Page1.gameObject.SetActive(false);
            Page2.gameObject.SetActive(true);
            Page3.gameObject.SetActive(false);
        }

        else if (index == 2)
        {
            Page1.gameObject.SetActive(false);
            Page2.gameObject.SetActive(false);
            Page3.gameObject.SetActive(true);
        }
    }
}
