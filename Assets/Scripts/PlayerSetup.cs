using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject _fpsModel;
    public GameObject _nonFpsModel;

    private void Start()
    {
        _fpsModel.SetActive(photonView.IsMine);
        _nonFpsModel.SetActive(!photonView.IsMine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
