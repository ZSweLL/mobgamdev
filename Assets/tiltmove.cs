using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltmove : MonoBehaviour
{
   // Move object using accelerometer
    public float speed = 10.0f;
    public float rotSpeed = 60f;

    Transform body;

    Vector3 startPosition;

    void Start() {
        body = this.transform.GetChild(0);
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;

        // we assume that device is held parallel to the ground
        // and Home button is in the right hand

        // remap device acceleration axis to game coordinates:
        //  1) XY plane of the device is mapped onto XZ plane
        //  2) rotated 90 degrees around Y axis
        dir.x = -Input.acceleration.x;
        dir.z = Input.acceleration.y;

        // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(dir * speed);
        body.transform.Rotate(0,0,-dir.x * rotSpeed);
    }

    void OnTriggerEnter(Collider other) {
         if(other.gameObject.CompareTag("Obstacle")) {
            this.transform.position = startPosition;
            Application.LoadLevel(4);
        } else if (other.gameObject.CompareTag("Finish")) {
            this.transform.position = startPosition;
            Application.LoadLevel(4);
        }
    }
}
