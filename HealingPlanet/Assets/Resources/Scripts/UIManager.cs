using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    public CreatePlants tree1;
    public CreatePlants tree2;
    public CreatePlants tree3;
    public CreatePlants flower1;
    public CreatePlants flower2;
    public CreatePlants flower3;
    public CreatePlants alter;

    void Start()
    {
        tree1.Init();
        tree2.Init();
        tree3.Init();
        flower1.Init();
        flower2.Init();
        flower3.Init();
        alter.Init();
    }

    public void Render()
    {
        tree1.Create();
        tree2.Create();
        tree3.Create();
        flower1.Create();
        flower2.Create();
        flower3.Create();
        alter.Create();

        tree1.Render();
        tree2.Render();
        tree3.Render();
        flower1.Render();
        flower2.Render();
        flower3.Render();
        alter.Render();
    }
}
