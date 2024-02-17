using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()//실행 시 작동
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)//정해진 버튼 오브젝트를 눌렀을 때
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(- 3.754f, -0.291f, 1.37f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
        if (other.gameObject.tag == "PlayerHand")//버튼 오브젝트와 상호작용 한 오브젝트의 tag가 PlayerHand일 때
        {
            SceneManager.LoadScene("INGAME"); // 지정한 씬으로 전환합니다.
        }
    }

    private void OnTriggerExit(Collider other)//정해진 버튼 오브젝트에서 벗어났을 때
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(-3.754f, -0.276f, 1.37f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

}
