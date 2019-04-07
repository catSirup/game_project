using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {
    void OnEnable()
    {
        StartCoroutine(bulletVelocity());
    }

    void OnDisable()
    {
        StopCoroutine(bulletVelocity());
    }

    IEnumerator bulletVelocity()
    {
        while (true)
        {
            if (!CharacterManager.isNeverDead)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4 + ObstacleVelocity.f_PlusSpeed, 0);
            }

            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((4 + ObstacleVelocity.f_PlusSpeed) * 2, 0);
            }

            yield return null;
        }
    }
}
