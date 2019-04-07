using UnityEngine;
using System.Collections;

public class ReinforceStart : MonoBehaviour {
    public Sprite[] sprite_OnOff;
    SpriteRenderer spriteRenderer;
    int count = 0;
    static int level = 0;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        this.count = int.Parse(gameObject.name);
    }

    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (this.count <= CurSelect())
                spriteRenderer.sprite = sprite_OnOff[1];
            else
                spriteRenderer.sprite = sprite_OnOff[0];
        }
    }

    int CurSelect()
    {
        switch (SelectManager.curSelect)
        {
            case SelectManager.SelectIcon.PLUSPOINT:
                level = ReinforceManager.i_CurPlusPointLevel;
                break;

            case SelectManager.SelectIcon.BULLETCYCLE:
                level = ReinforceManager.i_CurBulletCycleLevel;
                break;

            case SelectManager.SelectIcon.AREA:
                level = ReinforceManager.i_CurBulletAreaLevel;
                break;

            case SelectManager.SelectIcon.DAMAGE:
                level = ReinforceManager.i_CurBulletDamageLevel;
                break;


            case SelectManager.SelectIcon.LOADING:
                level = ReinforceManager.i_CurLoadingLevel;
                break;

            case SelectManager.SelectIcon.CHARACTERUPGRADE:
                level = ReinforceManager.i_CurCharacterGraphicsUpgradeLevel+1;
                break;

            case SelectManager.SelectIcon.OBSTACLE:
                level = ReinforceManager.i_CurObstacleGraphicsUpgradeLevel+1;
                break;

            case SelectManager.SelectIcon.BACKGROUNDUPGRADE:
                level = ReinforceManager.i_CurBackgroundGraphicsUpgradeLevel+1;
                break;

            case SelectManager.SelectIcon.RESET:
                level = 0;
                break;
        }

        return level;
    }
}
