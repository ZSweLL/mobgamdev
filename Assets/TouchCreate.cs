using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }
        // if(Input.GetMouseButtonDown(0)) {
        //     CreateCube(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        // }
    }

    void CreateCube(Vector3 givenPosition) {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = givenPosition;
        Destroy(cube, 2);

    }
}
