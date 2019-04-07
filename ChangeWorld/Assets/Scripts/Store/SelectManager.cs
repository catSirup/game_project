using UnityEngine;
using System.Collections;

public class SelectManager : MonoBehaviour {
    public enum SelectIcon
    {
        FIRE = 0, PLUSPOINT, DAMAGE, BULLETCYCLE, AREA, CUBE,
        DRAGON, OWL, LOADING, CHARACTERUPGRADE, OBSTACLE,
        BACKGROUNDUPGRADE, GOTCHA, CHARACTERSELECT, RESET
    };

    public static SelectIcon curSelect;
    public GameObject[] go_Icons;

    void Awake()
    {
        curSelect = SelectIcon.FIRE;
    }

    void Update()
    {
        for (int i = 0; i < go_Icons.Length; i++)
        {
            if (i == (int)curSelect)
            {
                go_Icons[i].SetActive(true);
            }
            else
                go_Icons[i].SetActive(false);
        }
    }
}
