using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CannonController : MonoBehaviour
{

    float shotPower = 1;
    bool timerIsGoing = false;
    float timer = 0;

    public Rigidbody cannonball;
    public float shotPowerMultiplier = 30;

    public TextMeshPro shotPowerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsGoing) {
            if(shotPower > 5) shotPower = 5;
            if(shotPower < 2.5f) shotPower = 2.5f;
            timer += Time.deltaTime;
            shotPower = timer;
            this.transform.localScale += Vector3.one * Time.deltaTime * 0.5f;
            shotPowerText.text = "ShotPower = " + shotPower.ToString("0,0");
        }
        #if UNITY_IOS
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) {
                timerIsGoing = true;
            }
            if(touch.phase == TouchPhase.Ended) {
                if(timerIsGoing)Shoot();
                
            }
        }
        #endif

        #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0)) {
            timerIsGoing = true;
        }if(Input.GetMouseButtonUp(0)) {
            if(timerIsGoing) Shoot();
        }
        #endif
    }

    void Shoot() {
        timer = 0;
        this.transform.localScale = Vector3.one;
        timerIsGoing = false;
        

        Rigidbody ball = Instantiate(cannonball, this.transform.position, this.transform.rotation);
        ball.AddRelativeForce(Vector3.forward * shotPowerMultiplier * shotPower, ForceMode.Impulse);
    }
}
