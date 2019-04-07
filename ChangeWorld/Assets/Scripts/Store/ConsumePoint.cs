using UnityEngine;
using System.Collections;

public class ConsumePoint : MonoBehaviour
{
    public Sprite[] sprite_Number;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = sprite_Number[0];
    }

    void Update()
    {
        ReinforceManager.i_ConsumePoint_Cycle = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurBulletCycleLevel + 1);
        ReinforceManager.i_ConsumePoint_Area = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurBulletAreaLevel + 1);
        ReinforceManager.i_ConsumePoint_Damage = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurBulletDamageLevel + 1);
        ReinforceManager.i_ConsumePoint_PlusPoint = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurPlusPointLevel + 1) * 2;

        ReinforceManager.i_ConsumePoint_Character = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurCharacterGraphicsUpgradeLevel + 1);
        ReinforceManager.i_ConsumePoint_Obstacle = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel + 1);
        ReinforceManager.i_ConsumePoint_Background = ReinforceManager.i_ConsumePointRatio * (ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel + 1);

        if (gameObject.name == "Ten")
        {
            switch (SelectManager.curSelect)
            {
                case SelectManager.SelectIcon.FIRE:
                    if(ReinforceManager.i_ConsumePoint_Fire / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Fire / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.PLUSPOINT:
                    if (ReinforceManager.i_ConsumePoint_PlusPoint / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_PlusPoint / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.BULLETCYCLE:
                    if(ReinforceManager.i_ConsumePoint_Cycle / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Cycle / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.AREA:
                    if(ReinforceManager.i_ConsumePoint_Area / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Area / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.DAMAGE:
                     if(ReinforceManager.i_ConsumePoint_Damage / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Damage / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.DRAGON:
                    if(ReinforceManager.i_ConsumePoint_Dragon != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Dragon / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.OWL:
                     if(ReinforceManager.i_ConsumePoint_Owl != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Owl / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.CUBE:
                    if(ReinforceManager.i_ConsumePoint_Cube / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Cube / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.LOADING:
                    if(ReinforceManager.i_ConsumePoint_Loading / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Loading / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.CHARACTERUPGRADE:
                    if(ReinforceManager.i_ConsumePoint_Character / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Character / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.OBSTACLE:
                     if(ReinforceManager.i_ConsumePoint_Obstacle / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Obstacle / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.BACKGROUNDUPGRADE:
                    if(ReinforceManager.i_ConsumePoint_Background / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Background / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.CHARACTERSELECT:
                    if(ReinforceManager.i_ConsumePoint_CharacterSelect / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_CharacterSelect / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.GOTCHA:
                    if (ReinforceManager.i_ConsumePoint_Gotcha / 10 != 0)
                        spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Gotcha / 10];

                    else
                        spriteRenderer.sprite = null;
                    break;

                case SelectManager.SelectIcon.RESET:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Reset / 10];
                    break;
            }
        }

        else if (gameObject.name == "One")
        {
            switch (SelectManager.curSelect)
            {
                case SelectManager.SelectIcon.FIRE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Fire % 10];
                    break;

                case SelectManager.SelectIcon.PLUSPOINT:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_PlusPoint % 10];
                    break;

                case SelectManager.SelectIcon.BULLETCYCLE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Cycle % 10];
                    break;

                case SelectManager.SelectIcon.AREA:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Area % 10];
                    break;

                case SelectManager.SelectIcon.DAMAGE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Damage % 10];
                    break;

                case SelectManager.SelectIcon.DRAGON:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Dragon % 10];
                    break;

                case SelectManager.SelectIcon.OWL:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Owl % 10];
                    break;

                case SelectManager.SelectIcon.CUBE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Cube % 10];
                    break;

                case SelectManager.SelectIcon.LOADING:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Loading % 10];
                    break;

                case SelectManager.SelectIcon.CHARACTERUPGRADE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Character % 10];
                    break;

                case SelectManager.SelectIcon.OBSTACLE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Obstacle % 10];
                    break;

                case SelectManager.SelectIcon.BACKGROUNDUPGRADE:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Background % 10];
                    break;

                case SelectManager.SelectIcon.CHARACTERSELECT:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_CharacterSelect % 10];
                    break;

                case SelectManager.SelectIcon.GOTCHA:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Gotcha % 10];
                    break;

                case SelectManager.SelectIcon.RESET:
                    spriteRenderer.sprite = sprite_Number[ReinforceManager.i_ConsumePoint_Reset % 10];
                    break;
            }
        }
    }
}
