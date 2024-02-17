using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goalkeeper : MonoBehaviour
{
    public Transform playerPosition; // ���� ��ġ
    public Transform goalPosition; // ����� ��ġ
    private GameObject goalkeeperInstance; // ������ ����� �ν��Ͻ�
    public float lerpSpeed = 5f;
    private GameObject armJoint1;
    private GameObject armJoint2;

    private void Start()
    {
        CreateGoalkeeper();
    }

    private void Update()
    {
        int num = Score.score;
        float goalkeeperspeed = (0.02f*(float)num) ;   // ����� ������ ��ġ �̵� �ӵ�
        MoveGoalkeeper(goalkeeperspeed);
        armJoint1.transform.Rotate(new Vector3(0f, 0f, 1f)); // ù ��° �� ȸ��
        armJoint2.transform.Rotate(new Vector3(0f, 0f, -1f)); // �� ��° �� ȸ��
    }

    private void MoveGoalkeeper(float keeperspeed)
    {
        Vector3 targetPosition = CalculateGoalkeeperPosition();

        // ���� ��ġ���� ��ǥ ��ġ�� ���� �����Ͽ� �ε巴�� �̵�
        goalkeeperInstance.transform.localPosition = Vector3.Lerp(goalkeeperInstance.transform.
            localPosition, targetPosition, lerpSpeed * Time.deltaTime * keeperspeed);

        // ������� �÷��̾ �ٶ󺸵��� ȸ��
        goalkeeperInstance.transform.LookAt(playerPosition.position);
    }

    private Vector3 CalculateGoalkeeperPosition()
    {
        // �÷��̾� ��ġ�� ��� ��ġ�� �������� ����� ��ġ�� ����մϴ�.
        // �÷��̾�� ��븦 ������ ������ ���ϰ�, �ش� ������ �÷��̾� ��ġ�� ����� ������ ����� ��ġ�� �����մϴ�.

        Vector3 goalkeeperPosition = Vector3.zero;

        Vector3 playerToGoal = goalPosition.position - playerPosition.position;
        float playerToGoalDistance = playerToGoal.magnitude;
        Vector3 playerToGoalDirection = playerToGoal.normalized;

        // ����� ��ġ�� �÷��̾�� ��� �߰����� ���� (����� 0.5f�� �����Ͽ� ��ġ�� ������ �� �ֽ��ϴ�.)
        float goalkeeperDistance = playerToGoalDistance * 0.3f;
        goalkeeperPosition = playerPosition.position + playerToGoalDirection * goalkeeperDistance;

        return goalkeeperPosition;
    }

    private void CreateGoalkeeper()
    {
        goalkeeperInstance = new GameObject("Goalkeeper");

        // ����� ������ ���� ��Ҹ� �����ϴ� ť�� ����� GameObject�� �߰��մϴ�.
        GameObject bodyCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bodyCube.transform.parent = goalkeeperInstance.transform;
        bodyCube.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        bodyCube.transform.localScale = new Vector3(0.5f, 0.75f, 0.25f); // ������ ũ�� ����

        GameObject headCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        headCube.transform.parent = goalkeeperInstance.transform;
        headCube.transform.localPosition = new Vector3(0f, 1.0f, 0f);
        headCube.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); // �Ӹ��� ũ�� ����

        armJoint1 = new GameObject("ArmJoint1");
        armJoint1.transform.parent = goalkeeperInstance.transform;
        armJoint1.transform.localPosition = new Vector3(-0.35f, 0.7f, 0f);

        GameObject armCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armCube1.transform.parent = armJoint1.transform;
        armCube1.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.125f);
        armCube1.transform.localScale = new Vector3(0.1f, 0.5f, 0.25f); // ���� ũ�� ����

        armJoint2 = new GameObject("ArmJoint2");
        armJoint2.transform.parent = goalkeeperInstance.transform;
        armJoint2.transform.localPosition = new Vector3(0.35f, 0.7f, 0f);


        GameObject armCube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armCube2.transform.parent = armJoint2.transform;
        armCube2.transform.localPosition = new Vector3(0.05f, 0.25f, 0.125f);
        armCube2.transform.localScale = new Vector3(0.1f, 0.5f, 0.25f); // ���� ũ�� ����

        //armCube1.transform.Rotate(new Vector3(0f, 0f, 20f)); // ù ��° �� ȸ��
        //armCube2.transform.Rotate(new Vector3(0f, 0f, -20f)); // �� ��° �� ȸ��

        GameObject legCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        legCube1.transform.parent = goalkeeperInstance.transform;
        legCube1.transform.localPosition = new Vector3(-0.15f, -0.5f, 0f);
        legCube1.transform.localScale = new Vector3(0.25f, 0.75f, 0.2f); // �ٸ��� ũ�� ����

        GameObject legCube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        legCube2.transform.parent = goalkeeperInstance.transform;
        legCube2.transform.localPosition = new Vector3(0.15f, -0.5f, 0f);
        legCube2.transform.localScale = new Vector3(0.25f, 0.75f, 0.2f); // �ٸ��� ũ�� ����


        goalkeeperInstance.transform.position = transform.position;

        // ������� ��� ť�꿡 ������ ��Ƽ������ �����մϴ�.
        Renderer[] renderers = goalkeeperInstance.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Color.red;
        }
    }
}