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

    void Start()//���� �� �۵�
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)//������ ��ư ������Ʈ�� ������ ��
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(- 3.754f, -0.291f, 1.37f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
        if (other.gameObject.tag == "PlayerHand")//��ư ������Ʈ�� ��ȣ�ۿ� �� ������Ʈ�� tag�� PlayerHand�� ��
        {
            SceneManager.LoadScene("INGAME"); // ������ ������ ��ȯ�մϴ�.
        }
    }

    private void OnTriggerExit(Collider other)//������ ��ư ������Ʈ���� ����� ��
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(-3.754f, -0.276f, 1.37f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

}
