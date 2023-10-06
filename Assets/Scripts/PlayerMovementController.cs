using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovementController : MonoBehaviour
{
    public Joystick _joystick;
    public FixedTouchField _fixedTouchField;

    private RigidbodyFirstPersonController _rigidbodyFirstPersonController;

    private Animator _animator;

    private void Start()
    {
        _rigidbodyFirstPersonController = this.GetComponent<RigidbodyFirstPersonController>();
        _animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbodyFirstPersonController._joystickInputAxis.x = _joystick.Horizontal;
        _rigidbodyFirstPersonController._joystickInputAxis.y = _joystick.Vertical;
        _rigidbodyFirstPersonController.mouseLook._lookInputAxis = _fixedTouchField.TouchDist;

        _animator.SetFloat("horizontal", _joystick.Horizontal);
        _animator.SetFloat("vertical", _joystick.Vertical);

        if (Mathf.Abs(_joystick.Horizontal) > 0.9 || Mathf.Abs(_joystick.Vertical) > 0.9)
        {
            _animator.SetBool("isRunning", true);
            _rigidbodyFirstPersonController.movementSettings.ForwardSpeed = 10;
        }
        else
        {
            _animator.SetBool("isRunning", false);
            _rigidbodyFirstPersonController.movementSettings.ForwardSpeed = 5;
        }
    }
}
