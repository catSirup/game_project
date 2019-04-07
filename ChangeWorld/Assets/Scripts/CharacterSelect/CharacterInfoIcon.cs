using UnityEngine;
using System.Collections;

public class CharacterInfoIcon : MonoBehaviour {
    public Sprite[] OnOff;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        switch (gameObject.tag)
        {
            case "Basic":

                if (CharacterOpenValue.isOpenBasic)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Cube":

                if (CharacterOpenValue.isOpenCube)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Redbull":

                if (CharacterOpenValue.isOpenRedBull)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "BrownOwl":

                if (CharacterOpenValue.isOpenBrownOwl)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "SilverOwl":

                if (CharacterOpenValue.isOpenSilverOwl)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Dragon":

                if (CharacterOpenValue.isOpenDragon)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Tobacco":

                if (CharacterOpenValue.isOpenTobacco)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "MoneyBug":

                if (CharacterOpenValue.isOpenMoneybug)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "HealingCat":

                if (CharacterOpenValue.isOpenHealingCat)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Lamp":

                if (CharacterOpenValue.isOpenLamp)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Epic":

                if (CharacterOpenValue.isOpenEpic)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "Yee":

                if (CharacterOpenValue.isOpenYee)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "OpticalDragon":

                if (CharacterOpenValue.isOpenOpticalDragon)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

            case "KC":

                if (CharacterOpenValue.isOpenKC)
                    spriteRenderer.sprite = OnOff[1];
                else
                    spriteRenderer.sprite = OnOff[0];

                break;

        }
    }
}
