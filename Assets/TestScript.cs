using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    float tapTimer = 0;
    public float doubleTapInterval = 0.2f;
    bool tapped = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        Debug.Log("Edited from the Browser in Github");
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
        if(Input.anyKeyDown) {
            // A wild tap appears!
            if(tapped) {
                DoubleTap();
                tapped = false;
            } else {
                tapped = true;
            }
        }
    }
    void SingleTap() {
            Debug.Log("<color=red>Singly tap!</color>");
            Debug.Log("Timer = " + tapTimer);
            tapTimer = 0;
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void DoubleTap() {
            Debug.Log("<color=blue>Double tap!</color>");
            Debug.Log("Timer = " + tapTimer);
            tapTimer = 0;
            transform.localScale += Vector3.one * 0.2f;
            if(this.transform.localScale.x > 5) {
                this.transform.localScale = Vector3.one;
            }
    }
}
