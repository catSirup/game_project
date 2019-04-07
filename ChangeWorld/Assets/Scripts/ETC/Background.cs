using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public GameObject[] go_Background;

    void OnEnable()
    {
        SetBackground(ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel);
    }

    void Update()
    {
        SetBackground(ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel);
    }

    void SetBackground(int rainforceNum)
    {
        for (int i = 0; i < ReinforceManager.i_MaximumGraphicsUpgrade + 1; i++)
        {
            if (i == rainforceNum)
            {
                go_Background[i].SetActive(true);
            }
            else
            {
                go_Background[i].SetActive(false);
            }
        }
    }

}
