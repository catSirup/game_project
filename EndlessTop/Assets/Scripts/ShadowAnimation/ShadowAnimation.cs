using UnityEngine;
using System.Collections;

public class ShadowAnimation : MonoBehaviour {

    public Transform parentShawdowTop;
    public Vector2 gapVecter;
    public float speed = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        gapVecter = new Vector2(parentShawdowTop.transform.position.x - this.transform.position.x, parentShawdowTop.transform.position.y - this.transform.position.y);

        if (parentShawdowTop.GetComponent<Rigidbody2D>().velocity.x != 0 && parentShawdowTop.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((gapVecter.x * speed), (gapVecter.y * speed));
        }

        else if (parentShawdowTop.GetComponent<Rigidbody2D>().velocity.x == 0 && parentShawdowTop.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(gapVecter.x * speed, gapVecter.y * speed);
        }
	}
}
