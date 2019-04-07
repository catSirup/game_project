using UnityEngine;
using System.Collections;

public static class StageManager {
    // 스테이지별 제한시간
    public static float stage1FallBackTime = 20.0f;
    public static float stage2FallBackTime = 20.0f;
    public static float stage3FallBackTime = 20.0f;
    public static float stage4FallBackTime = 20.0f;
    public static float stage5FallBackTime = 20.0f;

    // 스테이지 확인 변수
    public static bool stage1 = true;
    public static bool stage2 = false;
    public static bool stage3 = false;
    public static bool stage4 = false;
    public static bool stage5 = false;
    public static bool ending = false;
}
