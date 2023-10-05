using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovementController : MonoBehaviour
{
    public Joystick _joystick;
    public FixedTouchField _fixedTouchField;

    private RigidbodyFirstPersonController _rigidbodyFirstPersonController;

    private void Start()
    {
        _rigidbodyFirstPersonController = this.GetComponent<RigidbodyFirstPersonController>();
    }

    private void FixedUpdate()
    {
        _rigidbodyFirstPersonController._joystickInputAxis.x = _joystick.Horizontal;
        _rigidbodyFirstPersonController._joystickInputAxis.y = _joystick.Vertical;
        _rigidbodyFirstPersonController.mouseLook._lookInputAxis = _fixedTouchField.TouchDist;
    }
}
