using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] private PlayerLocomotionInput _playerLocomotionInput;
    [SerializeField] private float locomotionBlendInput = 2f;

    public string inputX = "InputX";
    public string inputY = "InputY";

    Vector2 currentBlendInput = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        Vector2 moveInput = _playerLocomotionInput.moveInput;
        currentBlendInput = Vector2.Lerp(currentBlendInput, moveInput, locomotionBlendInput * Time.deltaTime);

        _animator.SetFloat(inputX, currentBlendInput.x);
        _animator.SetFloat(inputY, currentBlendInput.y);
    }
}
