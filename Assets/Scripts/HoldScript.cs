using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldScript : MonoBehaviour
{

    Color originalColor;
    Renderer rend;

    bool timerIsGoing;
    float timer;

    Vector3 position;
    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
       rend = this.GetComponent<Renderer>();
       originalColor = rend.material.color; 
       width = (float)Screen.width / 2f;
       height = (float)Screen.height / 2f;
       position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        if(timerIsGoing) {
            timer += Time.deltaTime;
            if(timer > 4) {
                rend.material.color = Color.red;
        } else if(timer > 2) {
            rend.material.color = Color.yellow;
        } 
        
  }

        if(Input.touchCount > 0) {
            Debug.Log("I've been tapped!");
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) {
                rend.material.color = Color.green;
                timerIsGoing = true;
            }

            // if(touch.phase == TouchPhase.Moved) {
            //     Vector2 pos = touch.position;
            //     Debug.Log("Touch Position = " + touch.position);

            //     pos.x = (pos.x - width) / width;
            //     pos.y = (pos.y - height) / height;
            //     position = new Vector3(pos.x * 3f, pos.y * 3f, 0);

            //     this.transform.position = position;
            // }
            // if(touch.phase == TouchPhase.Ended) {
            //     rend.material.color = originalColor;
            //     timerIsGoing = false;
            //     timer = 0;
            //     transform.localScale = Vector3.one;
            // }
        }

        if(Input.touchCount <= 1) {
            transform.localScale = Vector3.one;
        }
        if(Input.touchCount == 2) {
            transform.localScale = Vector3.one * 2;
        }
        if(Input.touchCount == 3) {
            transform.localScale = Vector3.one * 3;
        }
    }
}
