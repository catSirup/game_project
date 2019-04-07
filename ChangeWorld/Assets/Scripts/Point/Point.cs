using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {
    public Sprite[] sprite_Num;
    SpriteRenderer spriteRenderer;

    int Tho = 0;
    int Hun = 0;
    int Ten = 0;
    int One = 0;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        Tho = PointManager.i_CurHavePoint / 1000;
        Hun = PointManager.i_CurHavePoint / 100 - (Tho * 10);
        Ten = PointManager.i_CurHavePoint / 10 - (Tho * 100) - (Hun * 10);
        One = PointManager.i_CurHavePoint % 10;

        if (gameObject.name == "Tho")
        {
            if (Tho == 0)
                spriteRenderer.sprite = null;
            else
            spriteRenderer.sprite = sprite_Num[Tho];
        }

        else if (gameObject.name == "Hun")
        {
            if (Tho == 0 && Hun == 0)
                spriteRenderer.sprite = null;
            else
                spriteRenderer.sprite = sprite_Num[Hun];
        }

        else if (gameObject.name == "Ten")
        {
            if(Tho == 0 && Hun == 0 && Ten == 0)
                spriteRenderer.sprite = null;
            else
                spriteRenderer.sprite = sprite_Num[Ten];
        }

        else if (gameObject.name == "One")
        {
            spriteRenderer.sprite = sprite_Num[One];
        }
    }
}
