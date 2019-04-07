using UnityEngine;
using System.Collections;

public class administratorMode : MonoBehaviour
{
    public Transform P;
    public MainManager mainMgr;
    bool isOpen = false;
    int p = 0;

    void OnEnable()
    {
        p = 0;
        isOpen = false;
        StartCoroutine(administrator());
    }

    IEnumerator administrator()
    {
        while (!isOpen)
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.name == "P")
                    p += 1;
            }

            if (p >= 10)
            {
                ReinforceManager.i_CurBulletDamageLevel = ReinforceManager.i_MaximumBulletDamageLevel;
                ReinforceManager.i_CurBulletAreaLevel = ReinforceManager.i_MaximumBulletAreaLevel;
                ReinforceManager.i_CurBulletCycleLevel = ReinforceManager.i_MaximumBulletCycleLevel;
                ReinforceManager.i_CurCharacterGraphicsUpgradeLevel = ReinforceManager.i_MaximumGraphicsUpgrade;
                ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel = ReinforceManager.i_MaximumGraphicsUpgrade;
                ReinforceManager.i_CurObstacleGraphicsUpgradeLevel = ReinforceManager.i_MaximumGraphicsUpgrade;
                ReinforceManager.i_CurPlusPointLevel = ReinforceManager.i_MaximumPlusPoint;
                ReinforceManager.i_CurLoadingLevel = ReinforceManager.i_MaximumLoadingLevel;

                CharacterOpenValue.isOpenBasic = true;
                CharacterOpenValue.isOpenCube = true;
                CharacterOpenValue.isOpenRedBull = true;
                CharacterOpenValue.isOpenBrownOwl = true;
                CharacterOpenValue.isOpenSilverOwl = true;
                CharacterOpenValue.isOpenDragon = true;
                CharacterOpenValue.isOpenTobacco = true;
                CharacterOpenValue.isOpenMoneybug = true;
                CharacterOpenValue.isOpenHealingCat = true;
                CharacterOpenValue.isOpenLamp = true;
                CharacterOpenValue.isOpenEpic = true;
                CharacterOpenValue.isOpenYee = true;
                CharacterOpenValue.isOpenOpticalDragon = true;
                //CharacterOpenValue.isOpenKC = true;

                ReinforceManager.b_CanFire = true;
                ReinforceManager.isOpenCharacterSelect = true;
                ReinforceManager.isOpenGotcha = true;

                PointManager.i_CurHavePoint = 100;
                mainMgr.curState = MainManager.MainState.TITLE;
                isOpen = true;
            }

            yield return null;
        }
    }
}
