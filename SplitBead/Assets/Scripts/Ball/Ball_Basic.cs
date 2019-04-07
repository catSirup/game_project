using UnityEngine;
using System.Collections;

public class Ball_Basic : MonoBehaviour {
    [HideInInspector]
    private int crashCount = 0;
    [HideInInspector]
    private bool isSeperation = false;
    
    private GameObject ball;

    private float scaleRate = 0.0f;
    private float speed = 0.0f;
    private float instanceSpeed = 0.0f;
    private float delayTime;
    private Vector2 vec;
    Library library;
    DelayTimeValue DTV;
    SideMenuOnOff sMenu;

    public AudioClip crashSound;
    public AudioClip seperationSound;

    void Start()
    {
        sMenu = GameObject.Find("Menu").GetComponent<SideMenuOnOff>();
        library = GameObject.Find("LibraryObject").GetComponent<Library>();
        DTV = GameObject.Find("LibraryObject").GetComponent<DelayTimeValue>();

        SetDelayTime();
        SetSpeed(speed);
    }

    void Action1()
    {
        speed = SetBallSpeed.ball_BasicSpeed;
        
        if (SetBallBoolValue.firstBall)
        {
            library.SetRandomVector();
            RandomMove();
            SetBallBoolValue.firstBall = false;
        }

        if (crashCount != 0 && crashCount % 6 == 0)
        {
            isSeperation = true;
            crashCount = 0;
        }

        if (isSeperation)
        {
            Seperation();
            isSeperation = false;
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

    void Update()
    {
        SetScaleBall();

        speed = SetBallSpeed.ball_BasicSpeed;

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
            Debug.Log("A");
            Time.timeScale = 0;
        }
    }

    public int GetCrashCount()
    {
        return crashCount;
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
    /// 공의 속력 관리.
    /// </summary>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return this.speed;
    }

    /// <summary>
    /// 공 분열시 이벤트.
    /// </summary>
    public void Seperation()
    {
        library.SetRandomBall();
        ball = library.GetRandomBall();

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

        Debug.Log(ballInstance.GetComponent<Rigidbody2D>().velocity);
        //Debug.Log(instanceSpeed);
    }

    public void RandomMove()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * library.GetRandomVector().normalized.x, speed * library.GetRandomVector().normalized.y);
    }

    /// <summary>
    /// 충돌이벤트.
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Button")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);
        }

        if (coll.gameObject.tag == "Wall")
        {
            this.crashCount++;
            //gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.normalized.x * speed, gameObject.rigidbody2D.velocity.normalized.y * speed * -1);
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);
        }

        if (coll.gameObject.tag == "LeftDown")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);

            coll.gameObject.SetActive(false);
            DeadLineSetBoolValue.DownLeft = false;
            DTV.SetDeleyTime1();
        }
        
        if (coll.gameObject.tag == "MiddleDown")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);

            coll.gameObject.SetActive(false);
            DeadLineSetBoolValue.DownMiddle = false;
            DTV.SetDeleyTime2();
        }
        
        if (coll.gameObject.tag == "RightDown")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);

            coll.gameObject.SetActive(false);
            DeadLineSetBoolValue.DownRight = false;
            DTV.SetDeleyTime3();
        }
        
        if (coll.gameObject.tag == "LeftUp")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);

            coll.gameObject.SetActive(false);
            DeadLineSetBoolValue.UpLeft = false;
            DTV.SetDeleyTime4();
        }

        if (coll.gameObject.tag == "MiddleUp")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);

            coll.gameObject.SetActive(false);
            DeadLineSetBoolValue.UpMiddle = false;
            DTV.SetDeleyTime5();
        }

        if (coll.gameObject.tag == "RightUp")
        {
            this.crashCount++;
            AudioSource.PlayClipAtPoint(crashSound, gameObject.transform.position);

            coll.gameObject.SetActive(false);
            DeadLineSetBoolValue.UpRight = false;
            DTV.SetDeleyTime6();
        }
    }

}
