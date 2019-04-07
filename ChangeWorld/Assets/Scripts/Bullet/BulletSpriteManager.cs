using UnityEngine;
using System.Collections;

public class BulletSpriteManager : MonoBehaviour
{
    public Sprite[] sprite_Bullets;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        spriteRenderer.sprite = sprite_Bullets[ReinforceManager.i_CurCharacterGraphicsUpgradeLevel];
    }

}
