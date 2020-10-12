using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class Student : MonoBehaviour
{
    private Animator animator;

    private float rotationSpeed = 5;

    public float headRotX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;

        transform.eulerAngles = rotation;

        headRotX = rotation.y;
    }
}
