using UnityEngine;
using System.Collections;

public class CharacterDead : MonoBehaviour {
    public Sprite[] sprite_Char;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite_Char[0];

        animator = gameObject.GetComponent<Animator>();

        if (animator == null)
            animator = null;
    }

    void OnEnable()
    {
        if(animator != null)
            animator.SetBool("isDead", false);
    }

    void Update()
    {
        if (!CharacterManager.isBumped)
        {
            if(ReinforceManager.i_CurCharacterGraphicsUpgradeLevel == 3)
                animator.SetBool("isDead", false);

            if(ReinforceManager.i_CurCharacterGraphicsUpgradeLevel == 2)    
                spriteRenderer.sprite = sprite_Char[0];
        }

        else
        {
            if (ReinforceManager.i_CurCharacterGraphicsUpgradeLevel == 3)
                animator.SetBool("isDead", true);

            if (ReinforceManager.i_CurCharacterGraphicsUpgradeLevel == 2)    
                spriteRenderer.sprite = sprite_Char[1];
        }
    }
}
