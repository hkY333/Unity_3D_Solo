using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector2 curMovementInput;
    [SerializeField] private float jumpPower;
    [SerializeField] private float crouchingSpeed;
    [SerializeField] private bool isCrouching = false;
    [SerializeField] private float prevSpeed;

    [Header("Look")]
    [SerializeField] private Transform springArm;
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    [SerializeField] private float camCurXRot;
    [SerializeField] private float lookSensitivity;
    private Vector2 mouseDelta;

    private Rigidbody _rigidbody;

    public bool canLook = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    public void OnCrouchingInput(InputAction.CallbackContext context)
    { 
        if (context.phase == InputActionPhase.Started && isCrouching == false)
        {
            prevSpeed = moveSpeed;
            moveSpeed *= crouchingSpeed;
            isCrouching = true;
        }

        else if (context.phase == InputActionPhase.Started && isCrouching == true)
        {
            moveSpeed = prevSpeed;
            isCrouching= false;
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        springArm.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

}
