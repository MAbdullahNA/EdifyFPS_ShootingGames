using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private PlayerLocomotionInput _PlayerLocomotionInput;
    [SerializeField] private Camera _Camera;

    public float runAcceleration;
    public float runSpeed;
    public float drag;

    public float lookSenseH;
    public float lookSenseV;
    public float lookLimitV;

    private Vector2 cameraRotation = Vector2.zero;
    private Vector2 playerTargetRotaion = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForwardXZ = new Vector3(_Camera.transform.forward.x, 0, _Camera.transform.forward.z).normalized;// save the previous camera forward position
        Vector3 cameraRightXZ = new Vector3(_Camera.transform.right.x, 0, _Camera.transform.right.z).normalized;// save the previous camera horizontal/right position

        Vector3 moveDirection = cameraRightXZ * _PlayerLocomotionInput.moveInput.x + cameraForwardXZ * _PlayerLocomotionInput.moveInput.y;//calculate position w.r.t user input
        Vector3 movementDelta = moveDirection * runAcceleration * Time.deltaTime;// add acceleration
        Vector3 newVelocity = _CharacterController.velocity + movementDelta;// add velocity to current velocity of character

        Vector3 currentDrag = newVelocity.normalized * drag;
        if(newVelocity.magnitude > drag)
        {
            newVelocity = newVelocity - currentDrag;
        }
        else
        {
            newVelocity = Vector3.zero;
        }
        newVelocity = Vector3.ClampMagnitude(newVelocity, runSpeed);

        _CharacterController.Move(newVelocity * Time.deltaTime);// move the character
    }
    private void LateUpdate()
    {
        cameraRotation.x += lookSenseH * _PlayerLocomotionInput.lookInput.x;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y - lookSenseV * _PlayerLocomotionInput.lookInput.y, -lookLimitV, lookLimitV);

        playerTargetRotaion.x += transform.eulerAngles.x + lookSenseH * _PlayerLocomotionInput.lookInput.x;
        transform.rotation = Quaternion.Euler(0f, playerTargetRotaion.x, 0f);

        _Camera.transform.rotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0f);
    }
}
