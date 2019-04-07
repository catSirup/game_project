using UnityEngine;
using System.Collections;

public class CoinVelocity : MonoBehaviour {
    void OnEnable()
    {
        StartCoroutine(coinVelocity());
    }

    void OnDisable()
    {
        StopCoroutine(coinVelocity());
    }

    IEnumerator coinVelocity()
    {
        while (true)
        {
            if (!CharacterManager.isNeverDead)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(- 3 - ObstacleVelocity.f_PlusSpeed, 0);
            }

            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((- 3 - ObstacleVelocity.f_PlusSpeed) * 2, 0);
            }

            yield return null;
        }
    }
}
