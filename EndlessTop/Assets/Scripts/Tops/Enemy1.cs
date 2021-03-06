﻿using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
    [HideInInspector]
    public bool crashTop = false;

    public Vector2 gapVector;

    public ProtectTop protectTop;
    public PlayerControl player;
    public MoveManager move;

    public UI ui;

    public float speed = 0.0f;

	void Start () {
        player = GameObject.Find("MyTop").GetComponent<PlayerControl>();
        protectTop = GameObject.Find("ProtectTop").GetComponent<ProtectTop>();
        move = gameObject.GetComponent<MoveManager>();
        speed = TopMoveSpeedValueManager.enemy1Speed;

        ui = GameObject.Find("UI").GetComponent<UI>();
	}
	
	void Update () {
        if (protectTop.gameObject.activeInHierarchy && !this.crashTop && !TimerValueManager.closeTimer && ui.pushSpaceKey)
        {
            this.speed = TopMoveSpeedValueManager.enemy1Speed;
            gapVector = new Vector2(protectTop.transform.position.x - this.transform.position.x, protectTop.transform.position.y - this.transform.position.y);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(gapVector.normalized.x * speed, gapVector.normalized.y * speed);
        }

        else if (protectTop.gameObject.activeInHierarchy && this.crashTop)
        {
            move.AfterCrashTop(player.GetComponent<Collider2D>());
        }

        else if (TimerValueManager.closeTimer || !protectTop.gameObject.activeInHierarchy)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "MyTop")
        {
            this.crashTop = true;
            this.speed = 30.0f;

            if (!player.pushKey)
            {
                gapVector = new Vector2(protectTop.transform.position.x - this.transform.position.x, protectTop.transform.position.y - this.transform.position.y);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-gapVector.normalized.x * speed, -gapVector.normalized.y * speed);
            }
        }

        if (coll.gameObject.tag == "Wall")
        {
            this.speed = 5.0f;
            this.crashTop = false;
        }
    }
}
