using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26;
using Models;

public class testPush : MonoBehaviour
{
    public static Student1 stu1 = new Student1(0, 0, 0, 1, 1);
    public static Student1 stu2 = new Student1(6, 0, 0, 4, 2);
    public static Student1 stu3 = new Student1(0, 0, 0, 2, 5);

    GameObject student1;
    GameObject student2;
    GameObject student3;

    // Start is called before the first frame update
    void Start()
    {
        student1 = GameObject.FindWithTag("Student1");
        student2 = GameObject.FindWithTag("Student2");
        student3 = GameObject.FindWithTag("Student3");

        stu1.loggedIn = true;

        student2.SetActive(false);
        student3.SetActive(false);

        RestClient.Put<Student1>("https://bean-2fd9d.firebaseio.com/student1.json", stu1);                                          //push to firebase
    }

    // Update is called once per frame
    void Update()
    {
        //GetCameraRotation.print();

        RestClient.Get<Student1>("https://bean-2fd9d.firebaseio.com/student2.json").Then(firstUser => { stu2 = firstUser; });      //get info from firebase
        RestClient.Get<Student1>("https://bean-2fd9d.firebaseio.com/student3.json").Then(firstUser => { stu3 = firstUser; });

        if (stu2.loggedIn)                                                                                                        //acitivate student models if they are logged in
            student2.SetActive(true);
        else
            student2.SetActive(false);

        if (stu3.loggedIn)
            student3.SetActive(true);
        else
            student3.SetActive(false);

        RestClient.Put<Student1>("https://bean-2fd9d.firebaseio.com/student1.json", stu1);                                           //push to firebase
    }

    void OnApplicationQuit()
    {
        stu1.loggedIn = false;
        RestClient.Put<Student1>("https://bean-2fd9d.firebaseio.com/student1.json", stu1);                                           //push to firebase

    }
}
