using UnityEngine;
using System.Collections;

public class ItemVelocity : MonoBehaviour {
    void OnEnable()
    {
        StartCoroutine(itemVelocity());
    }

    void OnDisable()
    {
        StopCoroutine(itemVelocity());
    }

    IEnumerator itemVelocity()
    {
        while (true)
        {
            if (CharacterManager.isNeverDead)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.3f -ObstacleVelocity.f_PlusSpeed, 0);
            }

            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((-3.3f - ObstacleVelocity.f_PlusSpeed) * 2, 0);
            }

            yield return null;
        }
    }
}
