using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{


	private Transform target;
	private NavMeshAgent navAgent;

	public void Awake()
	{
		//플레이어의 위치를 받음.
		target = GameObject.FindGameObjectWithTag("Player").transform;
		navAgent = GetComponent<NavMeshAgent>();
	}

	public void Update()
	{
		//플레이어의 위치를 목적지로 설정
		navAgent.SetDestination(target.position);
	}
}






























/*public Transform target;
public Vector3 direction;
public float moveSpeed = 5.0f;
public float rotSpeed = 50.0f;
private Rigidbody rbody;
private Transform tr;
private float h, v;

void Start()
{
	rbody = GetComponent<Rigidbody>();
	tr = GetComponent<Transform>();
	rbody.centerOfMass = new Vector3(0.0f, -0.5f, 0.0f); // 무게중심 Y를 -0.5 낮게 설정
}
// Update is called once per frame
void Update()
{
	MoveToTarget();
}

public void MoveToTarget()
{
	// Player의 현재 위치를 받아오는 Object
	target = GameObject.FindGameObjectWithTag("Player").transform;
	// Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
	direction = (target.position - transform.position).normalized;
	// 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
//	accelaration = 0.1f;
	// 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
//	velocity = (velocity + accelaration * Time.deltaTime);
	// Player와 객체 간의 거리 계산
	float distance = Vector3.Distance(target.position, transform.position);
	// 일정거리 안에 있을 시, 해당 방향으로 무빙

	if (distance > 100f)
	{
		this.transform.position = new Vector3(transform.position.x + (direction.x * moveSpeed),
											  0,
												 0);
		this.transform.Rotate(Vector3.up * rotSpeed * h * Time.deltaTime);
		// 일정거리 밖에 있을 시, 속도 초기화 
	}
}
}*/
