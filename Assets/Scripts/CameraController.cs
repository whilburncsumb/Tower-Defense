using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;
    public AnimationCurve transitionCurve;
    public float panSpeed = 30f;
    public float scrollSpeed = 30f;
    public float maxX = 80f;
    public float minX = 0f;
    public float maxY = 80f;
    public float minY = 10f;
    public float maxZ = 72f;
    public float minZ = -10f;
    public float panBorderthickness = 10f;
    
    void Update()
    {
         if (GameLogic.GameIsOver)
         {
             this.enabled = false;
             return;
         }
         if(true)
         {
             //WASD movement
             cinemachineCamera.transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"))*panSpeed * Time.deltaTime,Space.World);
             // MouseMovement();
             MouseZoom();
             CameraConstraints();
         }
         
    }

     private void MouseMovement()
     {
         if (Input.mousePosition.y >= Screen.height - panBorderthickness)
         {
             cinemachineCamera.transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
         }
         if (Input.mousePosition.y <= panBorderthickness)
         {
             cinemachineCamera.transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
         }
         if (Input.mousePosition.x >= Screen.width - panBorderthickness)
         {
             cinemachineCamera.transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
         }
         if (Input.mousePosition.x <=panBorderthickness)
         {
             cinemachineCamera.transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
         }
     }

     private void MouseZoom(){
         float scroll = Input.GetAxis("Mouse ScrollWheel");
         Vector3 pos = cinemachineCamera.transform.position;
         pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
         pos.y = Mathf.Clamp(pos.y, minY, maxY);
         cinemachineCamera.transform.position = pos;
     }

     private void CameraConstraints()
     {
         Vector3 pos = cinemachineCamera.transform.position;
         pos.x = Mathf.Clamp(pos.x, minX, maxX);
         pos.y = Mathf.Clamp(pos.y, minY, maxY);
         pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
         cinemachineCamera.transform.position = pos;
     }

    public void TriggerCameraTransition(Transform targetTransform)
    {
        StartCoroutine(TransitionCamera(targetTransform));
    }

    private IEnumerator TransitionCamera(Transform endPoint)
    {
        float elapsed = 0f;
        float transitionDuration = 2f;
        Vector3 initialPosition = cinemachineCamera.transform.position;
        Quaternion initialRotation = cinemachineCamera.transform.rotation;

        while (elapsed < transitionDuration)
        {
            float t = transitionCurve.Evaluate(elapsed / transitionDuration);

            cinemachineCamera.transform.position = Vector3.Lerp(initialPosition, endPoint.position, t);
            cinemachineCamera.transform.rotation = Quaternion.Lerp(initialRotation, endPoint.rotation, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera reaches the final position and rotation exactly
        cinemachineCamera.transform.position = endPoint.position;
        cinemachineCamera.transform.rotation = endPoint.rotation;
    }
}