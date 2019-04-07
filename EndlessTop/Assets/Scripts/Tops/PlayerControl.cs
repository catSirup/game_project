using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    [HideInInspector]
    public bool crashEffect = false;
    [HideInInspector]
    public bool bCanCrashEffect = false;
    [HideInInspector]
    public bool pushKey = false;

    public UI ui;
    public Transform effect;

    public float centerX = 0.0f;
    public float centerY = 0.0f;
    public float speed = 27.0f;

	void Start () {
        ui = GameObject.Find("UI").GetComponent<UI>();
        effect = GameObject.Find("MyTop").transform.Find("CrashEffect");
	}
	
	void FixedUpdate () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX != 0 && ui.pushSpaceKey)
        {
            pushKey = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * inputX, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (inputY != 0 && ui.pushSpaceKey)
        {
            pushKey = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed * inputY);
        }

        if (inputX == 0 && inputY == 0)
        {
            pushKey = false;
        }

        if (bCanCrashEffect)
        {
            crashEffect = true;
            bCanCrashEffect = false;
            effect.gameObject.SetActive(true);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            centerX = (this.transform.position.x + coll.transform.position.x) / 2;
            centerY = (this.transform.position.y + coll.transform.position.y) / 2;
            bCanCrashEffect = true;
        }
    }
}
