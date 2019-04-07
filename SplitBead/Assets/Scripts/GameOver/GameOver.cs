using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    private int index = 0;

   
	void Start () {
        Time.timeScale = 1;
	}
	
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index += 1;

            if (index > 1)
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
	}

    public int GetIndex()
    {
        return index;
    }
}
