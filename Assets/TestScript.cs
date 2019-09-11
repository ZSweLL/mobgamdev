using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    float tapTimer = 0;
    public float doubleTapInterval = 0.2f;
    bool tapped = false;
    Rigidbody rb;
    public int jumpPower = 5;
    public int forwardSpeed = 20;
    bool grounded = false;

    public int score = 0;

    TextMeshPro scoreText;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        Debug.Log("Edited from the Browser in Github");

        rb = this.GetComponent<Rigidbody>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // tap timer
        if(tapped) {
            tapTimer += Time.deltaTime;
            // if it has been more than 0.2 seconds...
            if(tapTimer > doubleTapInterval) {
                SingleTap();
                tapped = false;
            } 
        }
        if(Input.anyKeyDown && grounded) {
            // A wild tap appears!
            if(tapped) {
                DoubleTap();
                tapped = false;
            } else {
                tapped = true;
            }
        }
    }

    void FixedUpdate() {
        rb.AddRelativeForce(Vector3.right * forwardSpeed);
    }
    void SingleTap() {
            Debug.Log("<color=red>Singly tap!</color>");
            Debug.Log("Timer = " + tapTimer);
            tapTimer = 0;
            // GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            rb.AddRelativeForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    void DoubleTap() {
            Debug.Log("<color=blue>Double tap!</color>");
            Debug.Log("Timer = " + tapTimer);
            tapTimer = 0;
            // transform.localScale += Vector3.one * 0.2f;
            // if(this.transform.localScale.x > 5) {
            //     this.transform.localScale = Vector3.one;
            // }
            rb.AddRelativeForce(Vector3.up * jumpPower * 2, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = true;
        } else if(other.gameObject.CompareTag("Pickup")) {
            score += 1000;
            scoreText.text = "Score = " + score;
            Destroy(other.gameObject);
        } else if(other.gameObject.CompareTag("Finish")) {
            // reset everything!
            score = 0;
            this.transform.position = startPosition;
            Application.LoadLevel(0);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }
}
