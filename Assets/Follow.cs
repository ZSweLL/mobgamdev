using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform target;

    Vector3 startPos;
    float followDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        followDistance = target.transform.position.z - this.transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x,
                                                this.transform.position.y, 
                                                target.position.z - followDistance);
        
    }
}
