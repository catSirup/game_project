using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    public Sprite[] numbers;
    public SpriteRenderer spriteRenderer;

    private int tho;
    private int hun;
    private int ten;
    private int one;

    void OnEnable()
    {
        tho = PlayScene.score / 1000;
        hun = PlayScene.score / 100 - tho * 10;
        ten = PlayScene.score / 10 - tho * 100 - hun * 10;
        one = PlayScene.score - tho * 1000 - hun * 100 - ten * 10;


        switch (gameObject.name)
        {
            case "tho":
                if (tho != 0)
                    spriteRenderer.sprite = numbers[tho];
                else
                    spriteRenderer.sprite = null;
                break;

            case "hun":
                if (tho == 0 && hun == 0)
                    spriteRenderer.sprite = null;
                else
                    spriteRenderer.sprite = numbers[hun];
                break;

            case "ten":
                if (hun == 0 && ten == 0)
                    spriteRenderer.sprite = null;
                else
                    spriteRenderer.sprite = numbers[ten];
                break;

            case "one":
                spriteRenderer.sprite = numbers[one];
                break;
        }
    }
}
