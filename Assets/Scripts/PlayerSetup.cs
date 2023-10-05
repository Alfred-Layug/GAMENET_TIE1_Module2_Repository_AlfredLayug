using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject _fpsModel;
    public GameObject _nonFpsModel;

    public GameObject _playerUiPrefab;

    public PlayerMovementController _playerMovementController;
    public Camera _fpsCamera;

    private void Start()
    {
        _playerMovementController = this.GetComponent<PlayerMovementController>();

        _fpsModel.SetActive(photonView.IsMine);
        _nonFpsModel.SetActive(!photonView.IsMine);

        if (photonView.IsMine)
        {
            GameObject playerUi = Instantiate(_playerUiPrefab);
            _playerMovementController._fixedTouchField = playerUi.transform.Find("RotationTouchField").GetComponent<FixedTouchField>();
            _playerMovementController._joystick = playerUi.transform.Find("Fixed Joystick").GetComponent<Joystick>();
            _fpsCamera.enabled = true;
        }
        else
        {
            _playerMovementController.enabled = false;
            GetComponent<RigidbodyFirstPersonController>().enabled = false;
            _fpsCamera.enabled = false;
        }
    }
}
