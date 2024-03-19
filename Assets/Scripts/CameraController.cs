using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float scrollSpeed = 30f;
    public float maxX = 80f;
    public float minX = 0f;
    public float maxY = 80f;
    public float minY = 10f;
    public float maxZ = 72f;
    public float minZ = -10f;
    private bool movementEnabled = true;

    public float panBorderthickness = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            movementEnabled = !movementEnabled;
        }
        if (movementEnabled)
        {
            //WASD movement
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"))*panSpeed * Time.deltaTime,Space.World);
            MouseMovement();
        }
        
    }

    private void MouseMovement()
    {
        if (Input.mousePosition.y >= Screen.height - panBorderthickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y <= panBorderthickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - panBorderthickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x <=panBorderthickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //Zoom in/out
        //transform.Translate(Vector3.up * Input.GetAxis("Mouse ScrollWheel") * panSpeed * Time.deltaTime,Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }
}
