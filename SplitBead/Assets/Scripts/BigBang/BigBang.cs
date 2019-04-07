using UnityEngine;
using System.Collections;

public class BigBang : MonoBehaviour {
    [HideInInspector]
    private bool isCanBigBang = false;
    [HideInInspector]
    private bool isBigBang = false;
    [HideInInspector]
    private bool inputKey = false;

    public GameObject[] BasicBallList;
    public GameObject[] FastBallList;
    public GameObject[] SeperationBallList;

    public AudioClip boom;

    private Vector2 gapVector;
    BigBangTimeValue BBTV;
    Library library;

	void Start () {
        library = GameObject.Find("LibraryObject").GetComponent<Library>();
        BBTV = gameObject.GetComponent<BigBangTimeValue>();
	}

    void Update()
    {
        BasicBallList = GameObject.FindGameObjectsWithTag("BasicBall");
        FastBallList = GameObject.FindGameObjectsWithTag("FastBall");
        SeperationBallList = GameObject.FindGameObjectsWithTag("SeperationBall");

        if(Input.GetKey(KeyCode.Space) && library.GapTime(BBTV.GetTime()) > 15.0f)
        {
            GatheringBead();
            inputKey = true;
            isBigBang = false;
        }
       
        if(Input.GetKeyUp(KeyCode.Space) && inputKey && !isCanBigBang)
        {
            AudioSource.PlayClipAtPoint(boom, gameObject.transform.position);
            theBigBang();
            BBTV.SetTime(Time.time);
            isCanBigBang = true;
            inputKey = false;
        }

        if (isCanBigBang)
        {
            isBigBang = true;
            isCanBigBang = false;
        }

    }
    
    public void SetIsCanBigBang(bool state)
    {
        isCanBigBang = state;
    }

    public bool GetIsCanBigBang()
    {
        return isCanBigBang;
    }

    /// <summary>
    /// 변수 리턴.
    /// </summary>
    public void SetIsBigBang(bool state)
    {
        isBigBang = state;
    } 

    public bool GetIsBigBang()
    {
        return isBigBang;
    }

    /// <summary>
    /// 누르고 있을 때
    /// </summary>
    public void GatheringBead()
    {
        foreach (GameObject basic in BasicBallList)
        {
            SetGapVector(basic);
            basic.GetComponent<Rigidbody2D>().velocity = new Vector2(GetGapVector().x, GetGapVector().y);
        }

        foreach (GameObject fast in FastBallList)
        {
            SetGapVector(fast);
            fast.GetComponent<Rigidbody2D>().velocity = new Vector2(GetGapVector().x, GetGapVector().y);
        }

        foreach (GameObject seperation in SeperationBallList)
        {
            SetGapVector(seperation);
            seperation.GetComponent<Rigidbody2D>().velocity = new Vector2(GetGapVector().x, GetGapVector().y);
        }
    }

    /// <summary>
    /// 손 뗐을 때
    /// </summary>
    public void theBigBang()
    {
        foreach (GameObject basic in BasicBallList)
        {
            library.SetRandomVector();
            basic.GetComponent<Rigidbody2D>().velocity = new Vector2(library.GetRandomVector().normalized.x * SetBallSpeed.ball_BasicSpeed,
                                                     library.GetRandomVector().normalized.y * SetBallSpeed.ball_BasicSpeed);
        }

        foreach (GameObject fast in FastBallList)
        {
            library.SetRandomVector();
            fast.GetComponent<Rigidbody2D>().velocity = new Vector2(library.GetRandomVector().normalized.x * SetBallSpeed.ball_FastSpeed,
                                                    library.GetRandomVector().normalized.y * SetBallSpeed.ball_FastSpeed);
        }

        foreach (GameObject seperation in SeperationBallList)
        {
            library.SetRandomVector();
            seperation.GetComponent<Rigidbody2D>().velocity = new Vector2(library.GetRandomVector().normalized.x * SetBallSpeed.ball_SeperationSpeed,
                                                          library.GetRandomVector().normalized.y * SetBallSpeed.ball_SeperationSpeed);
        }
    }

 
    /// <summary>
    /// 차이벡터
    /// </summary>
    /// <param name="ball"></param>
    public void SetGapVector(GameObject ball)
    {
        gapVector = new Vector2((-7) - ball.transform.position.x, 3 - ball.transform.position.y);
    }

    public Vector2 GetGapVector()
    {
        return gapVector;
    }
    
}
