using UnityEngine;
using System.Collections;

public class Purchase : MonoBehaviour
{
    public Sprite[] sprite_ButtonOnOff;
    public AudioClip sound_Purchace;
    public Transform t_Popup;
    public Transform t_Message;
    public Transform t_ReinforcePoint;
    public Transform t_ResetPopup;
    SpriteRenderer spriteRenderer;

    bool isPopupOn = false;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = sprite_ButtonOnOff[0];
    }

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonDown(0) && hit.collider.gameObject.name == "Store_ReinforceButton")
        {
            Purchasing();
        }

        else if (isPopupOn && Input.GetMouseButtonDown(0))
        {
            t_Popup.gameObject.SetActive(false);
            t_Message.gameObject.SetActive(false);
            isPopupOn = false;
        }
    }

    void Purchasing()
    {
        switch (SelectManager.curSelect)
        {
            case SelectManager.SelectIcon.FIRE:
                PurchaseFunction(ref ReinforceManager.b_CanFire, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Fire);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.b_CanFire);
                break;

            case SelectManager.SelectIcon.PLUSPOINT:
                PurchaseFunction(ref ReinforceManager.i_CurPlusPointLevel, ReinforceManager.i_MaximumPlusPoint, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_PlusPoint);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurPlusPointLevel, ReinforceManager.i_MaximumPlusPoint);
                break;

            case SelectManager.SelectIcon.DAMAGE:
                PurchaseFunction(ref ReinforceManager.i_CurBulletDamageLevel, ReinforceManager.i_MaximumBulletDamageLevel, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Damage);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBulletDamageLevel, ReinforceManager.i_MaximumBulletDamageLevel);
                break;

            case SelectManager.SelectIcon.BULLETCYCLE:
                PurchaseFunction(ref ReinforceManager.i_CurBulletCycleLevel, ReinforceManager.i_MaximumBulletCycleLevel, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Cycle);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBulletCycleLevel, ReinforceManager.i_MaximumBulletCycleLevel);
                break;

            case SelectManager.SelectIcon.AREA:
                PurchaseFunction(ref ReinforceManager.i_CurBulletAreaLevel, ReinforceManager.i_MaximumBulletAreaLevel, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Area);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBulletAreaLevel, ReinforceManager.i_MaximumBulletAreaLevel);
                break;

            case SelectManager.SelectIcon.CUBE:
                if (ReinforceManager.isOpenCharacterSelect)
                    PurchaseFunction(ref CharacterOpenValue.isOpenCube, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Cube);
                else
                {
                    t_Message.gameObject.SetActive(true);
                    isPopupOn = true;
                }

                ChangeButtonSpriteAndActiveReinforcePoint(CharacterOpenValue.isOpenCube);
                break;

            case SelectManager.SelectIcon.DRAGON:
                if (ReinforceManager.isOpenCharacterSelect)
                    PurchaseFunction(ref CharacterOpenValue.isOpenDragon, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Dragon);
                else
                {
                    t_Message.gameObject.SetActive(true);
                    isPopupOn = true;
                }

                ChangeButtonSpriteAndActiveReinforcePoint(CharacterOpenValue.isOpenDragon);
                break;

            case SelectManager.SelectIcon.OWL:
                if (ReinforceManager.isOpenCharacterSelect)
                    PurchaseFunction(ref CharacterOpenValue.isOpenBrownOwl, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Owl);
                else
                {
                    t_Message.gameObject.SetActive(true);
                    isPopupOn = true;
                }

                ChangeButtonSpriteAndActiveReinforcePoint(CharacterOpenValue.isOpenBrownOwl);
                break;

            case SelectManager.SelectIcon.LOADING:
                PurchaseFunction(ref ReinforceManager.i_CurLoadingLevel, ReinforceManager.i_MaximumLoadingLevel, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Loading);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurLoadingLevel, ReinforceManager.i_MaximumLoadingLevel);
                break;

            case SelectManager.SelectIcon.CHARACTERUPGRADE:
                PurchaseFunction(ref ReinforceManager.i_CurCharacterGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Character);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurCharacterGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                break;

            case SelectManager.SelectIcon.OBSTACLE:
                PurchaseFunction(ref ReinforceManager.i_CurObstacleGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Obstacle);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurObstacleGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                break;

            case SelectManager.SelectIcon.BACKGROUNDUPGRADE:
                PurchaseFunction(ref ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Background);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                break;

            case SelectManager.SelectIcon.GOTCHA:
                PurchaseFunction(ref ReinforceManager.isOpenGotcha, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_Gotcha);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.isOpenGotcha);
                break;

            case SelectManager.SelectIcon.CHARACTERSELECT:
                PurchaseFunction(ref ReinforceManager.isOpenCharacterSelect, ref PointManager.i_CurHavePoint, ReinforceManager.i_ConsumePoint_CharacterSelect);
                ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.isOpenCharacterSelect);
                break;

            case SelectManager.SelectIcon.RESET:             
                if (PointManager.i_CurHavePoint >= ReinforceManager.i_ConsumePoint_Reset)
                {
                    t_ResetPopup.gameObject.SetActive(true);
                }

                else if (PointManager.i_CurHavePoint < ReinforceManager.i_ConsumePoint_Reset)
                {
                    Popup();
                }
                break;
        }
    }

    void Popup()
    {
        if (!isPopupOn)
        {
            t_Popup.gameObject.SetActive(true);
            isPopupOn = true;
        }
    }
   
    public void ChangeButtonSpriteAndActiveReinforcePoint()
    {
        spriteRenderer.sprite = sprite_ButtonOnOff[0];
        t_ReinforcePoint.gameObject.SetActive(true);
    }

    public void ChangeButtonSpriteAndActiveReinforcePoint(bool boolValue)
    {
        if (boolValue)
        {
            spriteRenderer.sprite = sprite_ButtonOnOff[1];
            t_ReinforcePoint.gameObject.SetActive(false);
        }

        else
        {
            spriteRenderer.sprite = sprite_ButtonOnOff[0];
            t_ReinforcePoint.gameObject.SetActive(true);
        }

    }

    public void ChangeButtonSpriteAndActiveReinforcePoint(int curLevel, int maxLevel)
    {
        if (curLevel == maxLevel)
        {
            spriteRenderer.sprite = sprite_ButtonOnOff[1];
            t_ReinforcePoint.gameObject.SetActive(false);
        }

        else
        {
            spriteRenderer.sprite = sprite_ButtonOnOff[0];
            t_ReinforcePoint.gameObject.SetActive(true);
        }
    }

    void PurchaseFunction(ref bool boolValue, ref int curHavePoint, int needPoint)
    {
        if (!boolValue && curHavePoint >= needPoint)
        {
            curHavePoint -= needPoint;
            boolValue = true;
            AudioSource.PlayClipAtPoint(sound_Purchace, transform.position);
        }

        else if (!boolValue && curHavePoint < needPoint)
        {
            Popup();
        }
    }

    void PurchaseFunction(ref int curLevel, int maxLevel, ref int curHavePoint, int needPoint)
    {
        if (curLevel != maxLevel && curHavePoint >= needPoint)
        {
            curHavePoint -= needPoint;
            curLevel++;
            AudioSource.PlayClipAtPoint(sound_Purchace, transform.position);
        }

        else if (curLevel != maxLevel && curHavePoint < needPoint)
        {
            Popup();
        }
    }

}
