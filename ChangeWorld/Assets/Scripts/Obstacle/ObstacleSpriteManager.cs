using UnityEngine;
using System.Collections;

public class ObstacleSpriteManager : MonoBehaviour {
    [SerializeField]
    float i_HP = 0;
    public static int count;

    public Sprite[] sprite_Obstacle;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        i_HP = count + 1;
    }

    void Update()
    {
        if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel <= 1 && ReinforceManager.i_CurObstacleGraphicsUpgradeLevel >= 0)
        {
            spriteRenderer.sprite = sprite_Obstacle[ReinforceManager.i_CurObstacleGraphicsUpgradeLevel];
        }

        else if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel == 2)
        {
            if (CharacterManager.i_PassCount >= 100 && count < 4)
            {
                count++;
                CharacterManager.i_PassCount = 0;
            }

            spriteRenderer.sprite = sprite_Obstacle[count];
        }

        else if (ReinforceManager.i_CurObstacleGraphicsUpgradeLevel == 3)
        {
            if (CharacterManager.i_PassCount >= 100 && count < 7)
            {
                count++;
                CharacterManager.i_PassCount = 0;
            }

            this.spriteRenderer.sprite = sprite_Obstacle[count];
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            col.gameObject.SetActive(false);
            //col.gameObject.transform.parent.transform.parent.SendMessage("DeleteBullet", SendMessageOptions.DontRequireReceiver);
            i_HP -= BulletFuncManager.f_BulletDamage;

            if (i_HP <= 0)
            {
                gameObject.SetActive(false);
                CharacterManager.i_GainScore += ((ReinforceManager.i_CurBulletAreaLevel + ReinforceManager.i_CurBulletCycleLevel + ReinforceManager.i_CurBulletDamageLevel) % 3);
            }
        }
    }
}
