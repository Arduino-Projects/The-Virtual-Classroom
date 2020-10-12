using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using Models;

[Serializable] // This makes the class able to be serialized into a JSON
public class Student1 : IEquatable<Student1>
{
    public double x;
    public double y;
    public double z;

    public double locationx;
    public double locationy;

    public bool loggedIn;

    public Student1(double x, double y, double z, int locx, int locy)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.locationx = locx;
        this.locationy = locy;
        this.loggedIn = false;
    }

    public void update()                            //update rotation
    {
        /*x = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye)[0];  
        y = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye)[1];
        z = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye)[2];*/
    }

    public bool Equals(Student1 stu)
    {
        if (stu.locationx != this.locationx && stu.locationy != this.locationy)
            return false;
        else
            return true;
    }
}