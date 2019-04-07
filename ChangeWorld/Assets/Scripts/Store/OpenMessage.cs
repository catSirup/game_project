using UnityEngine;
using System.Collections;

public class OpenMessage : MonoBehaviour {
    public Sprite[] sprite_OnOff;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        switch (SelectManager.curSelect)
        {
            case SelectManager.SelectIcon.FIRE:
                ChangeMessage(ReinforceManager.b_CanFire);
                break;

            case SelectManager.SelectIcon.CHARACTERSELECT:
                ChangeMessage(ReinforceManager.isOpenCharacterSelect);
                break;

            case SelectManager.SelectIcon.CUBE:
                ChangeMessage(CharacterOpenValue.isOpenCube);
                break;

            case SelectManager.SelectIcon.DRAGON:
                ChangeMessage(CharacterOpenValue.isOpenDragon);
                break;

            case SelectManager.SelectIcon.GOTCHA:
                ChangeMessage(ReinforceManager.isOpenGotcha);
                break;

            case SelectManager.SelectIcon.OWL:
                ChangeMessage(CharacterOpenValue.isOpenBrownOwl);
                break;
                
        }
    }

    void ChangeMessage(bool boolValue)
    {
        if (boolValue)
            spriteRenderer.sprite = sprite_OnOff[1];
        else
            spriteRenderer.sprite = sprite_OnOff[0];
    }
}
