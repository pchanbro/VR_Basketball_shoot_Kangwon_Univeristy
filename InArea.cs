using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InArea : MonoBehaviour
{
    public GameObject stage;
    public GameObject area;
    public GameObject inArea;
    public GameObject rightHand;
    public bool isPressed;
    Material areaMaterial;

    void Start()
    {
        isPressed = false;
        stage = GameObject.Find("Stage");
        area = GameObject.Find("Area");
        inArea = GameObject.Find("InArea");
        rightHand = GameObject.Find("RightHand Controller");
        areaMaterial = area.GetComponent<Renderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == rightHand.GetComponent<BoxCollider>() && !isPressed)
        {
            areaMaterial.color = new Color(0.2f, 0.27f, 0.6f);
            isPressed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == rightHand.GetComponent<BoxCollider>() && isPressed)
        {
            areaMaterial.color = new Color(1.0f, 1.0f, 1.0f);
            isPressed = false;
        }
    }
}
