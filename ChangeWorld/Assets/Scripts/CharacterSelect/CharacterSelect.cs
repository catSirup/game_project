using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
    public Sprite[] OnOff;
    SpriteRenderer spriteRenderer;

    public static Ray2D ray;
    public static RaycastHit2D hit;

    public Transform t_Select;

    public CharacterSelectManager characterSelectMgr;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        CurCharacterIcon();
    }

    void Update()
    {
        SelectCharacter();
    }

    void SelectCharacter()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.CompareTag("Basic"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.BASIC;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Cube"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.CUBE;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Redbull"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.REDBULL;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("BrownOwl"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.BROWNOWL;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("SilverOwl"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.SILVEROWL;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Dragon"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.DRAGON;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Tobacco"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.TOBACCO;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("MoneyBug"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.MONEYBUG;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("HealingCat"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.HEALINGCAT;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Lamp"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.LAMP;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Epic"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.EPIC;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("Yee"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.YEE;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("OpticalDragon"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.OPTICALDRAGON;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }

            else if (hit.collider.gameObject.CompareTag("KC"))
            {
                characterSelectMgr.curState = CharacterSelectManager.CharacterState.KC;
                t_Select.position = new Vector2(hit.collider.gameObject.transform.position.x - 0.02f, hit.collider.gameObject.transform.position.y + 0.02f);
            }
        }
    }

    void CurCharacterIcon()
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
