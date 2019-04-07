using UnityEngine;
using System.Collections;

public class ReinforceStarMessage : MonoBehaviour {
    public GameObject[] go_Stars;

    void Update()
    {
        switch (SelectManager.curSelect)
        {
            case SelectManager.SelectIcon.AREA:
                ChangeObject(ReinforceManager.i_CurBulletAreaLevel, ReinforceManager.i_MaximumBulletAreaLevel);
                break;

            case SelectManager.SelectIcon.BACKGROUNDUPGRADE:
                ChangeObject(ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                break;

            case SelectManager.SelectIcon.BULLETCYCLE:
                ChangeObject(ReinforceManager.i_CurBulletCycleLevel, ReinforceManager.i_MaximumBulletCycleLevel);
                break;

            case SelectManager.SelectIcon.CHARACTERUPGRADE:
                ChangeObject(ReinforceManager.i_CurCharacterGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                break;

            case SelectManager.SelectIcon.DAMAGE:
                ChangeObject(ReinforceManager.i_CurBulletDamageLevel, ReinforceManager.i_MaximumBulletDamageLevel);
                break;

            case SelectManager.SelectIcon.LOADING:
                ChangeObject(ReinforceManager.i_CurLoadingLevel, ReinforceManager.i_MaximumLoadingLevel);
                break;

            case SelectManager.SelectIcon.OBSTACLE:
                ChangeObject(ReinforceManager.i_CurObstacleGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                break;

            case SelectManager.SelectIcon.PLUSPOINT:
                ChangeObject(ReinforceManager.i_CurPlusPointLevel, ReinforceManager.i_MaximumPlusPoint);
                break;

            case SelectManager.SelectIcon.RESET:
                go_Stars[0].gameObject.SetActive(false);
                go_Stars[1].gameObject.SetActive(false);
                break;
        }
    }

    void ChangeObject(int curLevel, int maxLevel)
    {
        if (curLevel == maxLevel)
        {
            go_Stars[0].gameObject.SetActive(false);
            go_Stars[1].gameObject.SetActive(true);
        }

        else
        {
            go_Stars[0].gameObject.SetActive(true);
            go_Stars[1].gameObject.SetActive(false);
        }
    }
}
