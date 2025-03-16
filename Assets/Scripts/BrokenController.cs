using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BrokenController : MonoBehaviour
{
    public Transform chestEmpty;

    private void Update()
    {
        if (!IsControllerConnected())
        {
            MoveHandToChest();
        }
    }

    private bool IsControllerConnected()
    {
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;
        return CheckDeviceConnected(controllerCharacteristics);
    }

    private bool CheckDeviceConnected(InputDeviceCharacteristics characteristics)
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        return devices.Count > 0;
    }

    private void MoveHandToChest()
    {
        transform.position = chestEmpty.position;
        transform.rotation = chestEmpty.rotation;
    }
}
