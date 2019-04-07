using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
    private Vector3 v3_OldPos;
    private Vector3 v3_Focus;
    private Vector3 v3_OriginalCameraPosition;
    private Quaternion q_OriginalCameraRotation;
    public GameObject go_focusObj = null;
    private bool b_ViewEarth = false;

    public PlayerController player;

    void Start()
    {
        q_OriginalCameraRotation = gameObject.transform.rotation;
        v3_Focus = new Vector3(player.transform.position.x, player.transform.position.y + 0.2f, player.transform.position.z);
        transform.LookAt(v3_Focus);
        gameObject.transform.parent = go_focusObj.transform;
    }

    public void SetupInput()
    {
        v3_Focus = new Vector3(player.transform.position.x, player.transform.position.y + 0.2f, player.transform.position.z);
        Render();
        ViewEarth();
    }

    void Render()
    {
        float f_Delta = Input.GetAxis("Mouse ScrollWheel");
        if (f_Delta != 0.0f)
        {
            mouseWheelEvent(f_Delta);
        }
        if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            v3_OldPos = Input.mousePosition;
        }
        MouseDragEvent(Input.mousePosition);
    }

    void ViewEarth()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !b_ViewEarth)
        {
            player.b_DontMove = true;
            v3_OriginalCameraPosition = gameObject.transform.position;
            q_OriginalCameraRotation = gameObject.transform.rotation;
            gameObject.transform.position = new Vector3(player.transform.position.x, 10, player.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            b_ViewEarth = true;
        }

        else if (Input.GetKeyDown(KeyCode.LeftControl) && b_ViewEarth)
        {
            player.b_DontMove = false;
            gameObject.transform.position = v3_OriginalCameraPosition;//new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z - 2);
            gameObject.transform.rotation = q_OriginalCameraRotation;//Quaternion.Euler(player.transform.rotation.x + 20, player.transform.rotation.y, player.transform.rotation.z);
            b_ViewEarth = false;
        }
    }

    void MouseDragEvent(Vector3 mousePos)
    {
        Vector3 gapVector = mousePos - v3_OldPos;

        if (Input.GetMouseButton(1))
        {
            if (gapVector.magnitude > Vector3.kEpsilon)
            {
                cameraRotate(new Vector3(gapVector.y, gapVector.x, 0.0f));
            }
        }
        this.v3_OldPos = mousePos;
    }

    void cameraRotate(Vector3 eulerAngle)
    {
        Quaternion q = Quaternion.identity;
        go_focusObj.transform.localEulerAngles = go_focusObj.transform.localEulerAngles + eulerAngle;
        q.SetLookRotation(v3_Focus);
    }

    public void mouseWheelEvent(float f_Delta)
    {
        Vector3 focusToPosition = gameObject.transform.position - v3_Focus;

        Vector3 v3_Post = focusToPosition * (1.0f + f_Delta);

        if (v3_Post.magnitude > 0.01)
        {
            gameObject.transform.position = v3_Focus + v3_Post;
        }
    }
}

