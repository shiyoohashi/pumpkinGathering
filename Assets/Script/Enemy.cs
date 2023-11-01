using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    //GameObject型を変数targetで宣言します。
    public GameObject target;
    // public Text text;
    private float timeCount;
    private float speed;
    private float randomScale;
    private float randomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = Time.time;
        randomScale = UnityEngine.Random.Range(0.01f, 0.05f);
        speed = randomScale;
    }

    // Update is called once per frame
    private void FixedUpdate(){   
        if (Time.time - timeCount > 10) {
            print("up");
            print(speed);
            timeCount = Time.time;
            randomSpeed = UnityEngine.Random.Range(0.01f, 0.04f);
            speed = speed + randomSpeed;
        }         
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        Vector3 p = new Vector3(0f, 0f, speed);

        transform.Translate(p);
    }
}