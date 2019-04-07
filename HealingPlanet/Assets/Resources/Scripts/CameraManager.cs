using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public CameraController cameraController;

    public Transform cameraManager;
    public Transform Cat;
    public Transform Ufo;

    void Update()
    {
        if (Cat.gameObject.activeInHierarchy)
        {
            cameraManager.transform.parent = Cat;
            cameraController.SetupInput();
        }
        else
        {
            cameraManager.transform.parent = Ufo;
            cameraController.SetupInput();
        }
    }
}
