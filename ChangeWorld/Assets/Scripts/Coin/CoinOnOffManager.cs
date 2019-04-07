using UnityEngine;
using System.Collections;

public class CoinOnOffManager : MonoBehaviour {
    public GameObject[] go_Coins;

    void OnEnable()
    {
        for (int i = 0; i < ReinforceManager.i_MaximumGraphicsUpgrade + 1; i++)
        {
            if (i == ReinforceManager.i_CurObstacleGraphicsUpgradeLevel)
            {
                go_Coins[i].SetActive(true);
            }

            else
                go_Coins[i].SetActive(false);
        }
    }
}
