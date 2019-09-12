using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(player.position.x, startingPosition.y, startingPosition.z);
    }
}
