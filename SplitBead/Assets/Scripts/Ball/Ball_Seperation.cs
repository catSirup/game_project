using UnityEngine;
using System.Collections;

public class Ball_Seperation : MonoBehaviour {
    [HideInInspector]
    private bool isSeperation = false;
    
    public GameObject ball;
    private float delayTime;
    private float speed;
    private float instanceSpeed = 0.0f;
    private float scaleRate = 0.0f;

    BigBang BB;

    public AudioClip crashSound;
    public AudioClip seperationSound;

    SideMenuOnOff sMenu;
    Library library;

    void Start()
    {
        sMenu = GameObject.Find("Menu").GetComponent<SideMenuOnOff>();
        library = GameObject.Find("LibraryObject").GetComponent<Library>();
        BB = GameObject.Find("BigBangSpot").GetComponent<BigBang>();
        
        SetDelayTime();
        SetSpeed(speed);
	}

    void Action1()
    {
        speed = SetBallSpeed.ball_SeperationSpeed;

        if (library.GapTime(delayTime) > 9.0f && BB.GetIsBigBang())
        {
            isSeperation = true;
        }

        else if (!BB.GetIsBigBang())
        {
            isSeperation = false;
        }

        if (isSeperation)
        {
            Seperation();
            isSeperation = false;
            library.ClearTime(ref delayTime, 0.0f);
        }
    }

    void Action2()
    {
        //Time.timeScale = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    /// <summary>
    /// 입체감을 주기 위해 스케일 사용.
    /// </summary>
    public void SetScaleBall()
    {
        scaleRate = ((1.0f - gameObject.transform.position.y / 44) * 0.5f) + 0.5f;
        gameObject.transform.localScale = new Vector3(0.1f * scaleRate, 0.1f * scaleRate, 0.1f * scaleRate);
    }


	void Update () 
    {
        SetScaleBall();

        if (!DieBoolValue.isDie || !sMenu.GetOnable())
        {
            Time.timeScale = 1;
            Action1();
        }

        else if (DieBoolValue.isDie)
        {
            Action2();
        }

        if (sMenu.GetOnable())
        {
            Time.timeScale = 0;
        }
	}

    /// <summary>
    /// 시간 지연 변수 설정.
    /// </summary>
    public void SetDelayTime()
    {
        delayTime = Time.time;
    }

    public float GetDelayTime()
    {
        return delayTime;
    }

    /// <summary>
    /// 공 속력.
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return this.speed;
    }

    /// <summary>
    /// 분열 이벤트.
    /// </summary>
    public void Seperation()
    {
        library.SetRandomBall();
        ball = library.GetRandomBall();
        library.ClearTime(ref delayTime, 0);

        GameObject ballInstance = Instantiate(ball, gameObject.transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(seperationSound, gameObject.transform.position);

        if (ballInstance.tag == "BasicBall")
        {
            instanceSpeed = SetBallSpeed.ball_BasicSpeed;
        }

        else if (ballInstance.tag == "FastBall")
        {
            instanceSpeed = SetBallSpeed.ball_FastSpeed;
        }

        else if (ballInstance.tag == "SeperationBall")
        {
            instanceSpeed = SetBallSpeed.ball_SeperationSpeed;
        }

        ballInstance.GetComponent<Rigidbody2D>().velocity = new Vector2((gameObject.GetComponent<Rigidbody2D>().velocity.x / Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x)) * Mathf.Cos(library.GetRandomDegree()) * instanceSpeed,
                                                        (gameObject.GetComponent<Rigidbody2D>().velocity.y / Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y)) * Mathf.Sin(library.GetRandomDegree()) * instanceSpeed);
    }


    /// <summary>
    /// 충돌 이벤트.
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Button")
        {
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);
        }

        if (coll.gameObject.tag == "Wall")
        {
            //gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.normalized.x * speed, gameObject.rigidbody2D.velocity.normalized.y * speed * -1);
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);
        }
    }
}

