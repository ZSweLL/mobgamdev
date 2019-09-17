using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{

    void Start() {
        Destroy(this.gameObject, 5);
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Target")) {
             Destroy(this.gameObject);
             Destroy(other.gameObject);
        }
    }
}
