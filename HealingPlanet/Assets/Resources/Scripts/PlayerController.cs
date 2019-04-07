using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public GameObject[] player = new GameObject[2];

    //Value
    private Vector3 v3_defalutPosition = new Vector3(0, 0, 0);
    private Vector3 v3_Velocity;
    private float f_SpeedCat = 2.5f;
    private float f_SpeedUfo = 5f;
    private float f_RotateSpeed = 4;
    [System.NonSerialized]
    public bool b_DontMove = false;
    public Transform t_Light;

    Animation anim;

	void Start () 
    {
        player[0].SetActive(true);
        player[1].SetActive(false);

        t_Light.gameObject.SetActive(false);
	}

    public void Init()
    {
        gameObject.transform.position = v3_defalutPosition;

        f_SpeedCat = 2.5f;
        f_SpeedUfo = 5.0f;
        f_RotateSpeed = 4;

        b_DontMove = false;
    }

    public void MovePlayer()
    {
#if UNITY_EDITOR
        if (!b_DontMove) 
		{
			float inputX = Input.GetAxis ("Horizontal");
			float inputZ = Input.GetAxis ("Vertical");

            if (player[0].activeInHierarchy)
            {
                v3_Velocity = new Vector3(0, 0, inputZ * f_SpeedCat);
                v3_Velocity = transform.TransformDirection(v3_Velocity);
                gameObject.transform.localPosition += v3_Velocity * Time.fixedDeltaTime;
                gameObject.transform.Rotate(0, inputX * f_RotateSpeed, 0);
            }
            else
            {
                v3_Velocity = new Vector3(0, 0, inputZ * f_SpeedUfo);
                v3_Velocity = transform.TransformDirection(v3_Velocity);
                gameObject.transform.localPosition += v3_Velocity * Time.fixedDeltaTime;
                gameObject.transform.Rotate(0, inputX * f_RotateSpeed, 0);
            }
		}
#endif
    }

    public void InputKey()
    {
        if (!b_DontMove)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                light.gameObject.SetActive(!light.gameObject.activeInHierarchy);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                player[0].SetActive(!player[0].activeInHierarchy);
                player[1].SetActive(!player[1].activeInHierarchy);
            }
        }
    }

}
