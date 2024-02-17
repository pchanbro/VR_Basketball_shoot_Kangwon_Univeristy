using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goalkeeper : MonoBehaviour
{
    public Transform playerPosition; // 나의 위치
    public Transform goalPosition; // 골대의 위치
    private GameObject goalkeeperInstance; // 생성된 수비수 인스턴스
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
        float goalkeeperspeed = (0.02f*(float)num) ;   // 수비수 모형의 위치 이동 속도
        MoveGoalkeeper(goalkeeperspeed);
        armJoint1.transform.Rotate(new Vector3(0f, 0f, 1f)); // 첫 번째 팔 회전
        armJoint2.transform.Rotate(new Vector3(0f, 0f, -1f)); // 두 번째 팔 회전
    }

    private void MoveGoalkeeper(float keeperspeed)
    {
        Vector3 targetPosition = CalculateGoalkeeperPosition();

        // 현재 위치에서 목표 위치로 선형 보간하여 부드럽게 이동
        goalkeeperInstance.transform.localPosition = Vector3.Lerp(goalkeeperInstance.transform.
            localPosition, targetPosition, lerpSpeed * Time.deltaTime * keeperspeed);

        // 수비수가 플레이어를 바라보도록 회전
        goalkeeperInstance.transform.LookAt(playerPosition.position);
    }

    private Vector3 CalculateGoalkeeperPosition()
    {
        // 플레이어 위치와 골대 위치를 기준으로 수비수 위치를 계산합니다.
        // 플레이어와 골대를 지나는 직선을 구하고, 해당 직선상에 플레이어 위치에 가까운 지점을 수비수 위치로 설정합니다.

        Vector3 goalkeeperPosition = Vector3.zero;

        Vector3 playerToGoal = goalPosition.position - playerPosition.position;
        float playerToGoalDistance = playerToGoal.magnitude;
        Vector3 playerToGoalDirection = playerToGoal.normalized;

        // 수비수 위치를 플레이어와 골대 중간으로 설정 (상수인 0.5f를 조절하여 위치를 변경할 수 있습니다.)
        float goalkeeperDistance = playerToGoalDistance * 0.3f;
        goalkeeperPosition = playerPosition.position + playerToGoalDirection * goalkeeperDistance;

        return goalkeeperPosition;
    }

    private void CreateGoalkeeper()
    {
        goalkeeperInstance = new GameObject("Goalkeeper");

        // 수비수 모형의 구성 요소를 구성하는 큐브 모양의 GameObject를 추가합니다.
        GameObject bodyCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bodyCube.transform.parent = goalkeeperInstance.transform;
        bodyCube.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        bodyCube.transform.localScale = new Vector3(0.5f, 0.75f, 0.25f); // 몸통의 크기 조정

        GameObject headCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        headCube.transform.parent = goalkeeperInstance.transform;
        headCube.transform.localPosition = new Vector3(0f, 1.0f, 0f);
        headCube.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); // 머리의 크기 조정

        armJoint1 = new GameObject("ArmJoint1");
        armJoint1.transform.parent = goalkeeperInstance.transform;
        armJoint1.transform.localPosition = new Vector3(-0.35f, 0.7f, 0f);

        GameObject armCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armCube1.transform.parent = armJoint1.transform;
        armCube1.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.125f);
        armCube1.transform.localScale = new Vector3(0.1f, 0.5f, 0.25f); // 팔의 크기 조정

        armJoint2 = new GameObject("ArmJoint2");
        armJoint2.transform.parent = goalkeeperInstance.transform;
        armJoint2.transform.localPosition = new Vector3(0.35f, 0.7f, 0f);


        GameObject armCube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armCube2.transform.parent = armJoint2.transform;
        armCube2.transform.localPosition = new Vector3(0.05f, 0.25f, 0.125f);
        armCube2.transform.localScale = new Vector3(0.1f, 0.5f, 0.25f); // 팔의 크기 조정

        //armCube1.transform.Rotate(new Vector3(0f, 0f, 20f)); // 첫 번째 팔 회전
        //armCube2.transform.Rotate(new Vector3(0f, 0f, -20f)); // 두 번째 팔 회전

        GameObject legCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        legCube1.transform.parent = goalkeeperInstance.transform;
        legCube1.transform.localPosition = new Vector3(-0.15f, -0.5f, 0f);
        legCube1.transform.localScale = new Vector3(0.25f, 0.75f, 0.2f); // 다리의 크기 조정

        GameObject legCube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        legCube2.transform.parent = goalkeeperInstance.transform;
        legCube2.transform.localPosition = new Vector3(0.15f, -0.5f, 0f);
        legCube2.transform.localScale = new Vector3(0.25f, 0.75f, 0.2f); // 다리의 크기 조정


        goalkeeperInstance.transform.position = transform.position;

        // 수비수의 모든 큐브에 빨간색 머티리얼을 적용합니다.
        Renderer[] renderers = goalkeeperInstance.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Color.red;
        }
    }
}