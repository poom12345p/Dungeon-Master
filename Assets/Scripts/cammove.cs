using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammove : MonoBehaviour
{
    public float speed = 20.0f;
    public float x_Edge, y_Edge;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x_Edge = Dungeon_data.max_X_pos;
        y_Edge = Dungeon_data.max_Y_pos;
        if (Input.GetMouseButton(1))
        {

            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position += new Vector3(-Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0.0f, 0.0f);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position += new Vector3(-Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0.0f, 0.0f);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                transform.position += new Vector3(0.0f, 0.0f, (Input.GetAxis("Mouse Y") * -1.00f) * Time.deltaTime * speed);
            }
            else if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.position += new Vector3(0.0f, 0.0f, (Input.GetAxis("Mouse Y") * -1.00f) * Time.deltaTime * speed);
            }

            if (transform.position.x > x_Edge)
            {
                transform.localPosition = new Vector3(x_Edge, transform.localPosition.y, transform.localPosition.z);
            }
            else if (transform.position.x < -x_Edge)
            {
                transform.localPosition = new Vector3(-x_Edge, transform.localPosition.y, transform.localPosition.z);
            }

            if (transform.position.z > y_Edge)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, y_Edge);
            }
            else if (transform.position.z < -5)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -5);
            }

        }

        if (!door_scp.mouse_on_door)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // bakcward
            {
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize + 1, 20);
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 1, 5);
            }
        }
    }
}
