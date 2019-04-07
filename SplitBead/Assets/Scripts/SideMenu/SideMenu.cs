using UnityEngine;
using System.Collections;

public class SideMenu : MonoBehaviour {
    public AudioClip move;
    private int iIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            iIndex += 1;

            if (iIndex > 2)
            {
                iIndex -= 1;
            }
            AudioSource.PlayClipAtPoint(move, gameObject.transform.position);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            iIndex -= 1;
            if (iIndex < 0)
            {
                iIndex += 1;
            }
            AudioSource.PlayClipAtPoint(move, gameObject.transform.position);
        }
    }

    public int GetIndex()
    {
        return iIndex;
    }
}
