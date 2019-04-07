using UnityEngine;
using System.Collections;

public class CharacterSelectManager : MonoBehaviour
{
    public enum CharacterState { BASIC, CUBE, REDBULL, BROWNOWL, SILVEROWL, DRAGON, TOBACCO, MONEYBUG, HEALINGCAT, LAMP, EPIC, YEE, OPTICALDRAGON, KC };
    public CharacterState curState;

    public Transform t_Basic;
    public Transform t_Cube;
    public Transform t_Redbull;
    public Transform t_BrownOwl;
    public Transform t_SilverOwl;
    public Transform t_Dragon;
    public Transform t_Tobacco;
    public Transform t_MoneyBug;
    public Transform t_HealingCat;
    public Transform t_Lamp;
    public Transform t_Epic;
    public Transform t_Yee;
    public Transform t_OpticalDragon;
    public Transform t_KC;

    public static int i_CurSelectCharacterNumber;

    void Start()
    {
        curState = CharacterState.BASIC;
    }

    void Update()
    {
        switch (curState)
        {
            case CharacterState.BASIC:
                t_Basic.gameObject.SetActive(true);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenBasic)
                    i_CurSelectCharacterNumber = 0;
                break;

            case CharacterState.CUBE:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(true);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenCube)
                    i_CurSelectCharacterNumber = 1;
                break;

            case CharacterState.REDBULL:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(true);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenRedBull)
                    i_CurSelectCharacterNumber = 2;
                break;

            case CharacterState.BROWNOWL:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(true);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenBrownOwl)
                    i_CurSelectCharacterNumber = 3;
                break;

            case CharacterState.SILVEROWL:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(true);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenSilverOwl)
                    i_CurSelectCharacterNumber = 4;
                break;

            case CharacterState.DRAGON:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(true);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenDragon)
                    i_CurSelectCharacterNumber = 5;
                break;

            case CharacterState.TOBACCO:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(true);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenTobacco)
                    i_CurSelectCharacterNumber = 6;
                break;

            case CharacterState.MONEYBUG:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(true);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenMoneybug)
                    i_CurSelectCharacterNumber = 7;
                break;

            case CharacterState.HEALINGCAT:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(true);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenHealingCat)
                    i_CurSelectCharacterNumber = 8;
                break;

            case CharacterState.LAMP:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(true);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenLamp)
                    i_CurSelectCharacterNumber = 9;
                break;

            case CharacterState.EPIC:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(true);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenEpic)
                    i_CurSelectCharacterNumber = 10;
                break;

            case CharacterState.OPTICALDRAGON:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(true);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenOpticalDragon)
                    i_CurSelectCharacterNumber = 11;
                break;

            case CharacterState.YEE:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(true);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(false);

                if (CharacterOpenValue.isOpenYee)
                    i_CurSelectCharacterNumber = 12;
                break;

            case CharacterState.KC:
                t_Basic.gameObject.SetActive(false);
                t_Cube.gameObject.SetActive(false);
                t_Redbull.gameObject.SetActive(false);
                t_BrownOwl.gameObject.SetActive(false);
                t_SilverOwl.gameObject.SetActive(false);
                t_Dragon.gameObject.SetActive(false);
                t_Tobacco.gameObject.SetActive(false);
                t_MoneyBug.gameObject.SetActive(false);
                t_HealingCat.gameObject.SetActive(false);
                t_Lamp.gameObject.SetActive(false);
                t_Epic.gameObject.SetActive(false);
                t_Yee.gameObject.SetActive(false);
                t_OpticalDragon.gameObject.SetActive(false);
                t_KC.gameObject.SetActive(true);

                if (CharacterOpenValue.isOpenKC)
                    i_CurSelectCharacterNumber = 13;
                break;
        }
    }
}
