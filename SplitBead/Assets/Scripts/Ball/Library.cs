using UnityEngine;
using System.Collections;

public class Library : MonoBehaviour {
    private float randomDegree = 0.0f;
    public GameObject[] ball = new GameObject[3];
    private GameObject selectBall;
    private int index = 0;
    private Vector2 randomVector;

    void Awake()
    {
        Time.timeScale = 1;

        EndTime.endTime = 0;

        DieBoolValue.isDie = false;

        SetBallBoolValue.firstBall = true;

        DeadLineSetBoolValue.UpLeft = true;
        DeadLineSetBoolValue.UpMiddle = true;
        DeadLineSetBoolValue.UpRight = true;
        DeadLineSetBoolValue.DownLeft = true;
        DeadLineSetBoolValue.DownMiddle = true;
        DeadLineSetBoolValue.DownRight = true;
    }

    public void SetRandomDegree()
    {
        this.randomDegree = Random.Range(30.0f, 150.0f);
    }

    public float GetRandomDegree()
    {
        return randomDegree;
    }

    /// <summary>
    /// 두 점 사이의 각도 구하는 공식
    /// </summary>
    /// <param name="col"></param>
    /// <returns></returns>
    public float GetDegree()
    {
        float radian = Mathf.Atan2(this.transform.position.x - 0, this.transform.position.y - 0);
        return (radian * 180 / Mathf.PI - 90);
    }

    /// <summary>
    /// 공 랜덤 선택
    /// </summary>
    /// <returns></returns>
    public void SetRandomBall()
    {
        index = Random.Range(0, ball.Length);
        selectBall = ball[index];
    }

    public GameObject GetRandomBall()
    {
        return selectBall;
    }

    /// <summary>
    /// 시간 관련 함수(자주 써서 함수화 시킴)
    /// </summary>
    /// <param name="time"></param>
    /// <param name="gapTime"></param>
    public void ClearTime(ref float time, float gapTime)
    {
        if (GapTime(time) > gapTime)
        {
            time = Time.time;
        }
    }

    public float GapTime(float time)
    {
        return Time.time - time;
    }


    /// <summary>
    /// 랜덤 벡터 정하기.
    /// </summary>
    public void SetRandomVector()
    {
        int index1 = 0;
        int index2 = 0;

        float[] vec = new float[10];

        float vec1 = Random.Range(-11, -4);
        float vec2 = Random.Range(4, 11);

        vec[0] = vec1;
        vec[1] = vec2;
        vec[2] = vec1;
        vec[3] = vec2;
        vec[4] = vec1;
        vec[5] = vec2;
        vec[6] = vec1;
        vec[7] = vec2;
        vec[8] = vec1;
        vec[9] = vec2;

        index1 = Random.Range(0, 9);
        index2 = Random.Range(0, 9);

        randomVector = new Vector2(vec[index1], vec[index2]);
    }

    public Vector2 GetRandomVector()
    {
        return randomVector;
    }
}
