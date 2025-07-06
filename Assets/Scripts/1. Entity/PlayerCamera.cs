using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        Managers.Game.onGameStart += Setup;
    }

    private void Setup()
    {
        virtualCamera.Follow = PlayerController.player.transform;
    }
}
