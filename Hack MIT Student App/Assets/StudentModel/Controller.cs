using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator anim;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("n"))
            anim.SetBool("sitting", false);
        if (Input.GetKey("m"))
            anim.SetBool("sitting", true);

        if (Input.GetKey("b"))
            anim.SetBool("raiseHand", true);
        if (Input.GetKey("v"))
            anim.SetBool("raiseHand", false);

        if (Input.anyKey)
        {
            anim.enabled = false;
            anim.SetTrigger("center");
            anim.speed = 1;
            anim.enabled = true;
            //GetCameraRotation.center();
        }

        if (testPush.stu1.y > 180 && testPush.stu1.y < 280)
        {
            anim.speed = 0f;
            if(anim.GetBool("sitting") == false)
                anim.Play("standing_headCenterToRight", 0, (int)((testPush.stu1.y-180) / 100 * 19));
            else
                anim.Play("sitting_headCenterToRight", 0, (int)((testPush.stu1.y - 180) / 100 * 19));

            //Debug.Log((testPush.stu1.y - 180) / 100 * 19);
        }
        else if (testPush.stu1.y < 180 && testPush.stu1.y > 80)
        {
            anim.speed = 0f;
            if (anim.GetBool("sitting") == false)
                anim.Play("standing_headCenterToLeft", 0, (int)((testPush.stu1.y - 80) / 100 * 19));
            else
                anim.Play("sitting_headCenterToLeft", 0, (int)((testPush.stu1.y - 80) / 100 * 19));

            //Debug.Log((testPush.stu1.y - 80) / 100 * 19);
        }
    }
}
