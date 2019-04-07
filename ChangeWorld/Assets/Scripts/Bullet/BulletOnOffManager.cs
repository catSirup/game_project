using UnityEngine;
using System.Collections;

public class BulletOnOffManager : MonoBehaviour {
    public GameObject[] go_BulletsChild;
    void OnEnable()
    {
        for (int i = 0; i < ReinforceManager.i_MaximumBulletAreaLevel + 1; i++)
        {
            if (i == ReinforceManager.i_CurBulletAreaLevel)
            {
                go_BulletsChild[i].SetActive(true);
            }

            else
            {
                go_BulletsChild[i].SetActive(false);
            }
        }
    }

}
