using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
    public GameObject[] go_Cloud;

    [SerializeField]
    float f_FirstSpeed;
    [SerializeField]
    float f_SecondSpee;

    void OnEnable()
    {
        go_Cloud[0].GetComponent<Rigidbody2D>().velocity = new Vector2(-f_FirstSpeed, 0);
        go_Cloud[1].GetComponent<Rigidbody2D>().velocity = new Vector2(-f_SecondSpee, 0);
    }

    void Update()
    {
        if (go_Cloud[0].transform.position.x < -25.6f)
            go_Cloud[0].transform.position = new Vector2(25.6f, -2.12f);

        if (go_Cloud[1].transform.position.x < -25.6f)
            go_Cloud[1].transform.position = new Vector2(25.6f, -2.12f);
    }
}
