using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public Transform vehicleRoot;
    public float cameraRotateSpeed = 5;
    public float x, y = 0;
    public bool checkbutton;

    // Update is called once per frame
    void Update()
    {
        if (checkbutton == true)
        {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {
            x = Mathf.Lerp(x, Mathf.Clamp(Input.GetAxis("Mouse X"), -2, 2) * cameraRotateSpeed, Time.deltaTime * 5.0f);
              //  Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40, 60);
                  Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40, Time.deltaTime);
                //Camera.main.fieldOfView = 40f;
            }
        else
        {
            x = Mathf.Lerp(x, cameraRotateSpeed * 0.01f, Time.deltaTime * 5.0f);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40, Time.deltaTime);
                //Camera.main.fieldOfView = 60f;
            }


#elif UNITY_ANDROID || UNITY_IOS



        if (Input.touchCount == 1)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Moved:
                    x = Mathf.Lerp(x, Mathf.Clamp(Input.GetTouch(0).deltaPosition.x, -2, 2) * cameraRotateSpeed, Time.deltaTime*3.0f);
                    //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40, 60);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40, Time.deltaTime);
                    //Camera.main.fieldOfView = 40f;
                    break;
            }

        }
        else {
            x = Mathf.Lerp(x, cameraRotateSpeed * 0.02f, Time.deltaTime*3.0f);
              Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40, Time.deltaTime);
              //Camera.main.fieldOfView = 60f;
        }

#endif

            transform.RotateAround(vehicleRoot.position, Vector3.up, x);
    }

        if (checkbutton != true)
        {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR

            if (Input.GetMouseButton(0))
            {
                x = Mathf.Lerp(x, Mathf.Clamp(Input.GetAxis("Mouse X"), -2, 2) * cameraRotateSpeed, Time.deltaTime * 5.0f);
                //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40, 60);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime);
            }
            else
            {
                x = Mathf.Lerp(x, cameraRotateSpeed * 0.01f, Time.deltaTime * 5.0f);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime);
            }


#elif UNITY_ANDROID || UNITY_IOS



        if (Input.touchCount == 1)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Moved:
                    x = Mathf.Lerp(x, Mathf.Clamp(Input.GetTouch(0).deltaPosition.x, -2, 2) * cameraRotateSpeed, Time.deltaTime*3.0f);
                    //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40, 60);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime);
                    break;
            }

        }
        else {
            x = Mathf.Lerp(x, cameraRotateSpeed * 0.02f, Time.deltaTime*3.0f);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime);
        }

#endif

            transform.RotateAround(vehicleRoot.position, Vector3.up, x);
        }
    }
}
