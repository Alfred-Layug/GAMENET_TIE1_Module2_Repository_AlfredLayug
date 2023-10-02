using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject _playerPrefab;

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            int randomPointX = Random.Range(-10, 10);
            int randomPointZ = Random.Range(-10, 10);
            PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(randomPointX, 0, randomPointZ), Quaternion.identity);
        }
    }
}