using UnityEngine;
using System.Collections;

public class SideMenuOnOff : MonoBehaviour {
    [HideInInspector]
    private bool Onable = false;
    Transform sMenu;
    private int index = 0;

    void Awake()
    {
        Time.timeScale = 1;
    }

	void Start () {
        sMenu = GameObject.Find("Menu").transform.Find("SideMenu");
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (index == 0)
            {
                index = 1;
            }

            else
            {
                index = 0;
            }
        }

        OnOff();
	}

    void OnOff()
    {
        if (index == 1)
        {
            sMenu.gameObject.SetActive(true);
            Onable = true;
        }

        else if (index == 0)
        {
            sMenu.gameObject.SetActive(false);
            Onable = false;
        }
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(int state)
    {
        index = state;
    }

    public bool GetOnable()
    {
        return Onable;
    }
}
