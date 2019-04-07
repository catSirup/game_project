using UnityEngine;
using System.Collections;

public class ObstacleVelocity : MonoBehaviour {
    [SerializeField]
    float f_InitSpeed;
    [SerializeField]
    public static float f_PlusSpeed;

    public static int i_CurCreateCount;

    void Awake()
    {
        i_CurCreateCount = 0;
    }

    void OnEnable()
    {
        i_CurCreateCount += 1;
        f_PlusSpeed += 0.02f;
        StartCoroutine(obstacleVelocity());
    }

    void OnDisable()
    {
        StopCoroutine(obstacleVelocity());
    }

    IEnumerator obstacleVelocity()
    {
        while (true)
        {
            if (!CharacterManager.isNeverDead)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-f_InitSpeed - f_PlusSpeed, 0);
            else
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((-f_InitSpeed - f_PlusSpeed) * 2, 0);

            yield return null;
        }
    }
}
