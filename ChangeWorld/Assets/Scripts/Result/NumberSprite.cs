using UnityEngine;
using System.Collections;

public class NumberSprite : MonoBehaviour {
    public Sprite[] sprite_Num;
    SpriteRenderer spriteRenderer;
    public CharacterManager characterMgr;

    int number = 0;
    int tenTho = 0;
    int tho = 0;
    int hun = 0;
    int ten = 0;
    int one = 0;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gameObject.transform.parent.name == "HighScore")
        {
            if (CharacterManager.i_GainScore > Ranking.HighScore)
            {
                number = CharacterManager.i_GainScore;
                Ranking.HighScore = CharacterManager.i_GainScore;
            }
            else
                number = Ranking.HighScore;

            RenderSprite(number);
        }

        else if (gameObject.transform.parent.name == "CurScore")
        {
            number = CharacterManager.i_GainScore;
            RenderSprite(number);
        }

        else if (gameObject.transform.parent.name == "Point")
        {
            number = characterMgr.i_GainPoint;
            RenderSprite(number);
        }
    }

    void RenderSprite(int num)
    {
        tenTho = num / 10000;
        tho = num / 1000 - tenTho * 10;
        hun = num / 100 - tenTho * 100 - tho * 10;
        ten = num / 10 - tenTho * 1000 - tho * 100 - hun * 10;
        one = num % 10;

        if (gameObject.name == "TheTho")
        {
            if (tenTho != 0)
                spriteRenderer.sprite = sprite_Num[tenTho];

            else
                spriteRenderer.sprite = null;
        }

        else if (gameObject.name == "tho")
        {
            if (tho == 0 && tenTho == 0)
                spriteRenderer.sprite = null;

            else
                spriteRenderer.sprite = sprite_Num[tho];         
        }

        else if (gameObject.name == "hun")
        {
            if (tho == 0 && hun == 0 && tenTho == 0)
                spriteRenderer.sprite = null;

            else
                spriteRenderer.sprite = sprite_Num[hun];

        }

        else if (gameObject.name == "ten")
        {
            if (hun == 0 && tho == 0 && ten == 0 && tenTho == 0)
                spriteRenderer.sprite = null;

            else
                spriteRenderer.sprite = sprite_Num[ten];
        }

        else if (gameObject.name == "one")
        {
            spriteRenderer.sprite = sprite_Num[one];
        }
    }
}
