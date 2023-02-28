//InputControl.cs by Azuline Studios© All Rights Reserved
//Manages button and axis input to be read by the other scripts.
using UnityEngine;

using System.Collections;

public class InputControl : MonoBehaviour
{

    private FPSPlayer FPSPlayerComponent;
    //button states that are accessed by the other scripts
    [HideInInspector]
    public bool fireHold;
    [HideInInspector]
    public bool firePress;
    [HideInInspector]
    public bool reloadPress;
    [HideInInspector]
    public bool fireModePress;
    [HideInInspector]
    public bool jumpHold;
    [HideInInspector]
    public bool jumpPress;
    [HideInInspector]
    public bool crouchHold;
    [HideInInspector]
    public bool proneHold;
    [HideInInspector]
    public bool sprintHold;
    [HideInInspector]
    public bool zoomHold;
    [HideInInspector]
    public bool zoomPress;
    [HideInInspector]
    public bool leanLeftHold;
    [HideInInspector]
    public bool leanRightHold;
    [HideInInspector]
    public bool useHold;
    [HideInInspector]
    public bool usePress;
    [HideInInspector]
    public bool usePressUp;
    [HideInInspector]
    public bool toggleCameraHold;
    [HideInInspector]
    public bool toggleCameraDown;
    [HideInInspector]
    public bool grenadeHold;
    [HideInInspector]
    public bool deadzonePress;
    [HideInInspector]
    public bool meleePress;
    [HideInInspector]
    public bool flashlightPress;
    [HideInInspector]
    public bool holsterPress;
    [HideInInspector]
    public bool dropPress;
    [HideInInspector]
    public bool bulletTimePress;
    [HideInInspector]
    public bool moveHold;
    [HideInInspector]
    public bool movePress;
    [HideInInspector]
    public bool throwHold;
    [HideInInspector]
    public bool helpPress;
    [HideInInspector]
    public bool menuPress;
    [HideInInspector]
    public bool pausePress;
    [HideInInspector]
    public bool selectNextPress;
    [HideInInspector]
    public bool selectPrevPress;
    [HideInInspector]
    public bool selectGrenPress;
    [HideInInspector]
    public bool selectWeap1Press;
    [HideInInspector]
    public bool selectWeap2Press;
    [HideInInspector]
    public bool selectWeap3Press;
    [HideInInspector]
    public bool selectWeap4Press;
    [HideInInspector]
    public bool selectWeap5Press;
    [HideInInspector]
    public bool selectWeap6Press;
    [HideInInspector]
    public bool selectWeap7Press;
    [HideInInspector]
    public bool selectWeap8Press;
    [HideInInspector]
    public bool selectWeap9Press;
    [HideInInspector]
    public bool selectWeap0Press;
    [HideInInspector]
    public float mouseWheel;
    [HideInInspector]
    public bool leftHold;
    [HideInInspector]
    public bool rightHold;
    [HideInInspector]
    public bool forwardHold;
    [HideInInspector]
    public bool backHold;
    [HideInInspector]
    public float moveXButton;
    [HideInInspector]
    public float moveYButton;
    //gamepad input axes
    [Tooltip("Minimum input amount to ignore (helps with worn-out joysticks that don't return to center).")]
    public float deadzone = 0.2f;
    private Vector2 moveInput;
    private Vector2 lookInput;
    //combined button and axis inputs for moving
    [HideInInspector]
    public float moveX;
    [HideInInspector]
    public float moveY;
    //combined button and axis inputs for looking
    [HideInInspector]
    public float lookX;
    [HideInInspector]
    public float lookY;
    //Xbox 360 dpad controls (button held)
    [HideInInspector]
    public bool xboxDpadLeftHold;
    [HideInInspector]
    public bool xboxDpadRightHold;
    [HideInInspector]
    public bool xboxDpadUpHold;
    [HideInInspector]
    public bool xboxDpadDownHold;
    //Xbox 360 dpad controls (button press)
    [HideInInspector]
    public bool xboxDpadLeftPress;
    [HideInInspector]
    public bool xboxDpadRightPress;
    [HideInInspector]
    public bool xboxDpadUpPress;
    [HideInInspector]
    public bool xboxDpadDownPress;
    private bool xbdpLstate;
    private bool xbdpRstate;
    private bool xbdpUstate;
    private bool xbdpDstate;
    public FPSRigidBodyWalker run_player;
    public GameObject StartPosition;
    public Transform enemytransform;
    public bool lockMovement, AutoAm;
    public static InputControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        FPSPlayerComponent = GetComponent<FPSPlayer>();
    }
    int dist = 0;
    void Update()
    {
        Ray_cross();
        if (!lockMovement) PlayerRotation();
        if (FPSPlayerComponent && !FPSPlayerComponent.restarting)
        {
            //player movement buttons
            leftHold = ControlFreak2.CF2Input.GetButton("Left");
            rightHold = ControlFreak2.CF2Input.GetButton("Right");
            forwardHold = ControlFreak2.CF2Input.GetButton("Forward");
            backHold = ControlFreak2.CF2Input.GetButton("Back");
            //cancel player movement if opposite buttons are held at the same time
            if (leftHold && !rightHold)
            {
                moveXButton = -1.0f;
            }
            else if (rightHold && !leftHold)
            {
                moveXButton = 1.0f;
            }
            else
            {
                moveXButton = 0.0f;
            }
            if (forwardHold && !backHold)
            {
                moveYButton = 1.0f;
            }
            else if (backHold && !forwardHold)
            {
                moveYButton = -1.0f;
            }
            else
            {
                moveYButton = 0.0f;
            }
            //scaled radial deadzone for joysticks for smooth player movement ramp from deadzone
            moveInput = new Vector2(ControlFreak2.CF2Input.GetAxis("Joystick Move X"), ControlFreak2.CF2Input.GetAxis("Joystick Move Y"));
            if (moveInput.magnitude < deadzone)
            {
                moveInput = Vector2.zero;
            }
            else
            {
                moveInput = moveInput.normalized * ((moveInput.magnitude - deadzone) / (1 - deadzone));
            }
            lookInput = new Vector2(AccelerateInput(ControlFreak2.CF2Input.GetAxis("Joystick Look X")), AccelerateInput(ControlFreak2.CF2Input.GetAxis("Joystick Look Y")));
            if (lookInput.magnitude < deadzone)
            {
                lookInput = Vector2.zero;
            }
            else
            {
                lookInput = lookInput.normalized * ((lookInput.magnitude - deadzone) / (1 - deadzone));
            }
            if (moveY > 0.9f && FPSPlayerComponent.zoomed == false)//&& ModeSelecion.SelectedModes == 0 || ModeSelecion.SelectedModes == 1 || ModeSelecion.SelectedModes == 2
            {
                sprintHold = true;
                run_player.sprintActive = true;
            }
            else
            {
                sprintHold = false;
                run_player.sprintActive = false;
            }
            //combine button and axis input for player movement
            moveX = Mathf.Clamp(moveXButton + moveInput.x, -1.0f, 1.0f);
            moveY = Mathf.Clamp(moveYButton + moveInput.y, -1.0f, 1.0f);
            //combine mouse and axis input for player looking (accelerate axis input)

            lookX = ControlFreak2.CF2Input.GetAxisRaw("Mouse X") + lookInput.x;
            lookY = ControlFreak2.CF2Input.GetAxisRaw("Mouse Y") + lookInput.y;

            //manage zoom and fire inputs and determine if xbox 360 triggers have been pressed or held
            if (/*ControlFreak2.CF2Input.GetAxisRaw("Xbox R Trigger") > 0.1f || */ControlFreak2.CF2Input.GetButton("Fire"))
            {
                fireHold = true;
            }
            else
            {
                fireHold = false;
            }
            if (/*ControlFreak2.CF2Input.GetAxisRaw("Xbox L Trigger") > 0.1f ||*/ ControlFreak2.CF2Input.GetButton("Zoom"))
            {
                zoomHold = true;
            }
            else
            {
                zoomHold = false;
            }
            firePress = ControlFreak2.CF2Input.GetButtonDown("Fire");
            zoomPress = ControlFreak2.CF2Input.GetButtonDown("Zoom");
            reloadPress = ControlFreak2.CF2Input.GetButtonDown("Reload");
            jumpHold = ControlFreak2.CF2Input.GetButton("Jump");
            jumpPress = ControlFreak2.CF2Input.GetButtonDown("Jump");
            sprintHold = ControlFreak2.CF2Input.GetButton("Sprint");
            holsterPress = ControlFreak2.CF2Input.GetButtonDown("Holster Weapon");
            deadzonePress = ControlFreak2.CF2Input.GetButtonDown("Toggle Deadzone Aiming");
            selectNextPress = ControlFreak2.CF2Input.GetButtonDown("Select Next Weapon");
            selectPrevPress = ControlFreak2.CF2Input.GetButtonDown("Select Previous Weapon");
            selectGrenPress = ControlFreak2.CF2Input.GetButtonDown("Select Next Grenade");
        }
        else
        {
            fireHold = false;//stop shooting if level is restarting
        }
    }
    //accelerate axis input for easier control and reduction of axis drift (deadzone improvement)
    float AccelerateInput(float input)
    {
        float inputAccel;
        inputAccel = ((1.0f / 8.0f) * input * (Mathf.Abs(input) * 8.0f)) * Time.smoothDeltaTime * 60.0f;
        return inputAccel;
    }
    RaycastHit hit;
    public Camera cam;
    public GameObject whiteRectangle, RedRectangle;
    Vector3 dir;
    float rotateSpeed = 3f;
    private void PlayerRotation()
    {
        if (dir.magnitude == 0) return;
        Vector3 rotDir = new Vector3(dir.x, dir.y, dir.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotDir), Time.deltaTime * rotateSpeed);
    }
    void Ray_cross()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //----------------------------------------------------------------------
        if (zoomHold == false)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Head")
                {
                    whiteRectangle.SetActive(false);
                    RedRectangle.SetActive(true);
                    UI_Manager.shot_org = false;
                    enemytransform = hit.collider.transform;
                    //if (environmentSelection.Curr_Mode != 1)
                    //{
                    if (UI_Manager.instance.mainParent.GetComponent<SmoothMouseLook>().Animals == null)
                    {
                        //AutoAm = true;
                        UI_Manager.instance.mainParent.GetComponent<SmoothMouseLook>().Animals = hit.collider.gameObject;
                    }

                    //}
                }
                else if (hit.collider.tag == "Body")
                {
                    whiteRectangle.SetActive(false);
                    RedRectangle.SetActive(true);
                    UI_Manager.shot_org = true;
                    enemytransform = hit.collider.transform;
                    //if (environmentSelection.Curr_Mode != 1)
                    //{
                    if (UI_Manager.instance.mainParent.GetComponent<SmoothMouseLook>().Animals == null)
                    {
                        //AutoAm = true;
                        UI_Manager.instance.mainParent.GetComponent<SmoothMouseLook>().Animals = hit.collider.gameObject;
                    }

                    //}
                }
                else
                {
                    whiteRectangle.SetActive(true);
                    RedRectangle.SetActive(false);
                }
            }
        }
    }
}
