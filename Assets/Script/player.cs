using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour 
    
{
    private Rigidbody rb;
    private int count;
    public float speed;
    public Text countText;
    public Text clearText;

    void Start()
    {
        print("init");
        rb = GetComponent<Rigidbody>();
        speed = 40;
        count = 0;
        clearText.text = "";
        
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        print(other.gameObject.CompareTag("Coin"));
        if (other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            count = count + 1;
            setCount();
            if (count > 100){
                SceneManager.LoadScene("ClearScene");
            }
        } else if (other.gameObject.CompareTag("Enemy")) {
            print("enemy");
            SceneManager.LoadScene("GameoverScene");
        }
    }

    void setCount(){
        countText.text = "Count: " + count.ToString();
    }


}
