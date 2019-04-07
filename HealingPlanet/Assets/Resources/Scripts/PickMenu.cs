using UnityEngine;
using System.Collections;

public class PickMenu : MonoBehaviour {

    public Ray ray;
    public RaycastHit2D hit;
	
	// Update is called once per frame
	void Update () 
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        rayCasting(ray);
	}

    void rayCasting(Ray ray)
    {
        hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null && hit.transform.gameObject == this.gameObject && Input.GetMouseButtonDown(0))
        {
            if (this.gameObject.name == "Back")
                Application.LoadLevel("Title");

            else if (this.gameObject.name == "Start")
                Application.LoadLevel("Tutorial");

            else if (this.gameObject.name == "Develop")
                Application.LoadLevel("Develop");

            else if (this.gameObject.name == "Exit")
                Application.Quit();
        }
    }
}
