using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour
{
    private bool started = false;
    private bool mouseIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!started) started = true;
        }
        if (started)
        {
            if (mouseIn)
            {
                Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 zAxis = new Vector3(0, 0, 1);
                transform.RotateAround(pz, zAxis, 7.5f);
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(0,0,0), new Quaternion(0,0,0,0));
                started = false;
            }
        }
        else
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.SetPositionAndRotation(new Vector3(pz.x,pz.y-3.5f, 10), new Quaternion(0, 0, 0, 0));
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
        mouseIn = true;
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Leave");
        mouseIn = false;
    }
}
