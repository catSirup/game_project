using UnityEngine;
using System.Collections;

public static class SetBallSpeed 
{
    public static float distance = 44.0f;
    /// <summary>
    /// 초기 각각 공들의 속도 설정.
    /// </summary>
    public static float ball_BasicSpeed = Mathf.Abs(distance / 1.5f);
    public static float ball_FastSpeed = Random.Range(ball_BasicSpeed + 0.5f, ball_BasicSpeed + 3.0f);
    public static float ball_SeperationSpeed = ball_BasicSpeed;
}
