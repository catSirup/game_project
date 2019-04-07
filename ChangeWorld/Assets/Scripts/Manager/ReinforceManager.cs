using UnityEngine;
using System.Collections;

public static class ReinforceManager
{
    #region Reinforce Level

    public static int i_CurBulletDamageLevel;
    public static int i_CurBulletAreaLevel;
    public static int i_CurBulletCycleLevel;
    public static int i_CurCharacterGraphicsUpgradeLevel;
    public static int i_CurBackgroundGraphicsUpgradeLevel;
    public static int i_CurObstacleGraphicsUpgradeLevel;
    public static int i_CurPlusPointLevel;
    public static int i_CurLoadingLevel;


    // 최대 강화 레벨.
    public static int i_MaximumBulletDamageLevel = 4;
    public static int i_MaximumBulletAreaLevel = 4;
    public static int i_MaximumBulletCycleLevel = 4;
    public static int i_MaximumGraphicsUpgrade = 3;
    public static int i_MaximumPlusPoint = 4;
    public static int i_MaximumLoadingLevel = 4;
    public static int i_MaximumSoundLevel = 4;
    
    public static bool b_CanFire;
    public static bool isOpenCharacterSelect;
    public static bool isOpenGotcha;

    // 로딩 시간
    public static float i_CurLoadingTime;

    #endregion

    #region secondary quantity

    public static int i_ConsumePointRatio = 5;

    public static int i_ConsumePoint_Fire = 5;
    public static int i_ConsumePoint_Cycle = i_ConsumePointRatio * (i_CurBulletCycleLevel + 1);
    public static int i_ConsumePoint_Area = i_ConsumePointRatio * (i_CurBulletAreaLevel + 1);
    public static int i_ConsumePoint_Damage = i_ConsumePointRatio * (i_CurBulletDamageLevel + 1);
    public static int i_ConsumePoint_PlusPoint = i_ConsumePointRatio * (i_CurPlusPointLevel + 1) * 2;
    public static int i_ConsumePoint_Dragon = 20;
    public static int i_ConsumePoint_Cube = 10;
    public static int i_ConsumePoint_Owl = 15;

    public static int i_ConsumePoint_Loading = 10;
    public static int i_ConsumePoint_Character = i_ConsumePointRatio * (i_CurCharacterGraphicsUpgradeLevel + 1);
    public static int i_ConsumePoint_Obstacle = i_ConsumePointRatio * (i_CurObstacleGraphicsUpgradeLevel + 1);
    public static int i_ConsumePoint_Background = i_ConsumePointRatio * (i_CurBackgroundGraphicsUpgradeLevel + 1);
    public static int i_ConsumePoint_CharacterSelect = 10;
    public static int i_ConsumePoint_Gotcha = 10;
    public static int i_ConsumePoint_Reset = 20;

    public static bool isSaveFirst = SceneManager.GetBool("isSaveFirst");

    #endregion
}
