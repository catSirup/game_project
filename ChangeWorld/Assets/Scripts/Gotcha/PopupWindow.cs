using UnityEngine;
using System.Collections;

public class PopupWindow : MonoBehaviour {
    public enum ImageState 
    { 
        SILVEROWL = 0, TOBACCO, EPIC, YEE, LAMP, HEALINGCAT, 
        OPTICALDRAGON, REDBULL, MONEYBUG, PT5, PT7, PT9,  LOT, POINTLESS 
    };

    public ImageState curState;
    public GameObject[] Image;
    public GameObject[] Info;

    public int RandomNumber()
    {
        return Random.Range(0, 200);
    }

    public int RandomSelect(int num)
    {
        if (num >= 0 && num < 7)
        {
            curState = ImageState.SILVEROWL;

            if (!CharacterOpenValue.isOpenSilverOwl)
                CharacterOpenValue.isOpenSilverOwl = true;
        }

        else if (num >= 7 && num < 14)
        {
            curState = ImageState.TOBACCO;

            if (!CharacterOpenValue.isOpenTobacco)
                CharacterOpenValue.isOpenTobacco = true;
        }

        else if (num >= 14 && num < 21)
        {
            curState = ImageState.EPIC;

            if (!CharacterOpenValue.isOpenEpic)
                CharacterOpenValue.isOpenEpic = true;
        }

        else if (num >= 21 && num < 28)
        {
            curState = ImageState.YEE;

            if (!CharacterOpenValue.isOpenYee)
                CharacterOpenValue.isOpenYee = true;
        }

        else if (num >= 28 && num < 35)
        {
            curState = ImageState.LAMP;

            if (!CharacterOpenValue.isOpenLamp)
                CharacterOpenValue.isOpenLamp = true;
        }

        else if (num >= 35 && num < 42)
        {
            curState = ImageState.HEALINGCAT;

            if (!CharacterOpenValue.isOpenHealingCat)
                CharacterOpenValue.isOpenHealingCat = true;
        }

        else if (num >= 42 && num < 49)
        {
            curState = ImageState.OPTICALDRAGON;

            if (!CharacterOpenValue.isOpenOpticalDragon)
                CharacterOpenValue.isOpenOpticalDragon = true;
        }

        else if (num >= 49 && num < 56)
        {
            curState = ImageState.REDBULL;

            if (!CharacterOpenValue.isOpenRedBull)
                CharacterOpenValue.isOpenRedBull = true;
        }

        else if (num >= 56 && num < 63)
        {
            curState = ImageState.MONEYBUG;

            if (!CharacterOpenValue.isOpenMoneybug)
                CharacterOpenValue.isOpenMoneybug = true;
        }

        else if (num >= 63 && num < 95)
        {
            curState = ImageState.PT5;
            PointManager.i_CurHavePoint += 5;
        }

        else if (num >= 95 && num < 140)
        {
            curState = ImageState.PT7;
            PointManager.i_CurHavePoint += 7;
        }

        else if (num >= 140 && num < 160)
        {
            curState = ImageState.PT9;
            PointManager.i_CurHavePoint += 9;
        }

        else if (num >= 160 && num < 200)
        {
            curState = ImageState.LOT;
        }

        return (int)curState;
    }

    public void ImageInfoOnOff(int num)
    {
        for (int i = 0; i < 14; i++)
        {
            if (i == num)
            {
                Image[i].SetActive(true);
                Info[i].SetActive(true);
            }

            else
            {
                Image[i].SetActive(false);
                Info[i].SetActive(false);
            }
        }
    }
}
