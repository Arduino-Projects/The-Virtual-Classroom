using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCameraRotation : MonoBehaviour
{
    public static Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.eulerAngles;
        transform.eulerAngles = rotation;

        testPush.stu1.x = rotation.x;
        testPush.stu1.y = rotation.y;
        testPush.stu1.z = rotation.z;
    }

    //public static void center()
    //{
        //rotation = new Vector3(180f, 180f, 180f);
        //transform.eulerAngles = rotation;
        //transform.Rotate(transform.rotation.eulerAngles + new Vector3 (0f, 0.1f, 0f));
    //}

    public static void print() 
    {
        Debug.Log(rotation.x + ", " + rotation.y + ", " + rotation.z);
    }
}
