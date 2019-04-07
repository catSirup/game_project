using UnityEngine;
using System.Collections;

public class TempScene : Scene
{
    public override void Initialize()
    {
        SceneManager.sceneMgr.ChangeScene(SceneManager.sceneMgr.GetPrevState());
    }

    public override void Updated()
    {
        
    }

    public override void Exit()
    {

    }
}
