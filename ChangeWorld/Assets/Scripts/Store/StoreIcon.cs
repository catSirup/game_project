using UnityEngine;
using System.Collections;

public class StoreIcon : MonoBehaviour
{
    static Ray2D ray;
    static RaycastHit2D hit;

    public Transform t_Select1;
    public Transform t_Select2;
    public Purchase purchase;

    void Update()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            switch (hit.collider.gameObject.name)
            {
                case "Button_fire":
                    SelectManager.curSelect = SelectManager.SelectIcon.FIRE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.b_CanFire);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_bonus":
                    SelectManager.curSelect = SelectManager.SelectIcon.PLUSPOINT;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurPlusPointLevel, ReinforceManager.i_MaximumPlusPoint);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_speed":
                    SelectManager.curSelect = SelectManager.SelectIcon.BULLETCYCLE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBulletCycleLevel, ReinforceManager.i_MaximumBulletCycleLevel);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_Damage":
                    SelectManager.curSelect = SelectManager.SelectIcon.DAMAGE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBulletDamageLevel, ReinforceManager.i_MaximumBulletDamageLevel);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_Area":
                    SelectManager.curSelect = SelectManager.SelectIcon.AREA;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBulletAreaLevel, ReinforceManager.i_MaximumBulletAreaLevel);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_dragon":
                    SelectManager.curSelect = SelectManager.SelectIcon.DRAGON;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(CharacterOpenValue.isOpenDragon);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_owlb":
                    SelectManager.curSelect = SelectManager.SelectIcon.OWL;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(CharacterOpenValue.isOpenBrownOwl);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_Cube":
                    SelectManager.curSelect = SelectManager.SelectIcon.CUBE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(CharacterOpenValue.isOpenCube);
                    t_Select1.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(true);
                    t_Select2.gameObject.SetActive(false);
                    break;

                case "Button_Loading":
                    SelectManager.curSelect = SelectManager.SelectIcon.LOADING;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurLoadingLevel, ReinforceManager.i_MaximumLoadingLevel);
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;

                case "Button_BackgroundUpgrade":
                    SelectManager.curSelect = SelectManager.SelectIcon.BACKGROUNDUPGRADE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;

                case "Button_CharacterUpgrade":
                    SelectManager.curSelect = SelectManager.SelectIcon.CHARACTERUPGRADE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurCharacterGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;

                case "Button_CharacterSelect":
                    SelectManager.curSelect = SelectManager.SelectIcon.CHARACTERSELECT;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.isOpenCharacterSelect);
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;

                case "Button_Gotcha":
                    SelectManager.curSelect = SelectManager.SelectIcon.GOTCHA;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.isOpenGotcha);
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;

                case "Button_ObstacleUpgrade":
                    SelectManager.curSelect = SelectManager.SelectIcon.OBSTACLE;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint(ReinforceManager.i_CurObstacleGraphicsUpgradeLevel, ReinforceManager.i_MaximumGraphicsUpgrade);
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;

                case "Button_Reset":
                    SelectManager.curSelect = SelectManager.SelectIcon.RESET;
                    purchase.ChangeButtonSpriteAndActiveReinforcePoint();
                    t_Select2.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
                    t_Select1.gameObject.SetActive(false);
                    t_Select2.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
