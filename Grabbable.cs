using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grabbable : MonoBehaviour
{
    private GameObject grabbedObject;
    private Rigidbody grabbedObjectRigidbody;
    public float throwForceThreshold = 5f;
    private Vector3 previousVelocity;
    private InputDevice targetDevice;

    void Start()
    {
        // 컨트롤러를 찾아 설정
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (grabbedObject == null && other.CompareTag("Grabbable"))
        {
            grabbedObject = other.gameObject;
            grabbedObjectRigidbody = grabbedObject.GetComponent<Rigidbody>();
            grabbedObjectRigidbody.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabbedObject)
        {
            grabbedObjectRigidbody.isKinematic = false;
            grabbedObject = null;
            grabbedObjectRigidbody = null;
        }
    }

    private void Update()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = transform.position;
        }

        Vector3 deviceVelocity;
        if (targetDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out deviceVelocity))
        {
            if (grabbedObject != null && (deviceVelocity - previousVelocity).magnitude > throwForceThreshold)
            {
                grabbedObjectRigidbody.isKinematic = false;
                grabbedObjectRigidbody.velocity = deviceVelocity;
                grabbedObject = null;
                grabbedObjectRigidbody = null;
            }
            previousVelocity = deviceVelocity;
        }
    }
}
