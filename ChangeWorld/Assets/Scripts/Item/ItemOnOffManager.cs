using UnityEngine;
using System.Collections;

public class ItemOnOffManager : MonoBehaviour {
    public Sprite[] sprite_Items;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        for (int i = 0; i < sprite_Items.Length; i++)
        {
            if (i == ReinforceManager.i_CurObstacleGraphicsUpgradeLevel)
                spriteRenderer.sprite = sprite_Items[i];
        }
    }
}
