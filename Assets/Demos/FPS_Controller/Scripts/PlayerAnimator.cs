using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] private PlayerLocomotionInput _playerLocomotionInput;
    public string inputX = "InputX";
    public string inputY = "InputY";

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        Vector2 moveInput = _playerLocomotionInput.moveInput;
        _animator.SetFloat(inputX,moveInput.x);
        _animator.SetFloat(inputY,moveInput.y);
    }
}
