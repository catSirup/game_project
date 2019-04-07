using UnityEngine;
using System.Collections;

public class ReinforceLevelManager : MonoBehaviour {
    public GameObject[] go_ReinforceLevelInfo;

    void Update()
    {
        switch (SelectManager.curSelect)
        {
            case SelectManager.SelectIcon.CUBE:
            case SelectManager.SelectIcon.DRAGON:
            case SelectManager.SelectIcon.FIRE:
            case SelectManager.SelectIcon.GOTCHA:
            case SelectManager.SelectIcon.OWL:
            case SelectManager.SelectIcon.CHARACTERSELECT:
                go_ReinforceLevelInfo[0].gameObject.SetActive(true);
                go_ReinforceLevelInfo[1].gameObject.SetActive(false);
                break;

            default:
                go_ReinforceLevelInfo[0].gameObject.SetActive(false);
                go_ReinforceLevelInfo[1].gameObject.SetActive(true);
                break;
        }
    }
}
