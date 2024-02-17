using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class CreateBasketball : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(-3.754f, -0.291f, 1.37f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(-3.754f, -0.276f, 1.37f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        sphere.transform.localPosition = new Vector3(0.0f, 1.0f, -1.0f);
        sphere.tag = "Grabbable";
        Material sphereMaterial = sphere.GetComponent<Renderer>().material;
        sphereMaterial.color = new Color(0.52f, 0.27f, 0.07f);

        Rigidbody sphereRigidbody = sphere.AddComponent<Rigidbody>();
        sphereRigidbody.mass = 0.005f;
        sphereRigidbody.drag = 0.01f;
        sphereRigidbody.angularDrag = 0f;
        sphereRigidbody.useGravity = true;
        sphereRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;


        SphereCollider sphereCollider = sphere.GetComponent<SphereCollider>();
        PhysicMaterial physicMaterial = new PhysicMaterial();
        physicMaterial.bounciness = 10.0f;
        sphereCollider.material = physicMaterial;

        XRGrabInteractable grabInteractable = sphere.AddComponent<XRGrabInteractable>();
        grabInteractable.throwOnDetach = true;
        grabInteractable.trackPosition = true;
        grabInteractable.trackRotation = true;
        grabInteractable.velocityScale = 10.0f;
        grabInteractable.throwSmoothingDuration = 0.2f;
        grabInteractable.throwVelocityScale = 3f;

    }
}