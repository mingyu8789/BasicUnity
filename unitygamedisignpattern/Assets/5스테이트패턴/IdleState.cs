using UnityEngine;

public class IdleState : IState
{
	public void Enter()
	{
		Debug.Log("Idle ���� ����");
	}

	public void Update()
	{
		Debug.Log("Idle ���� �����O");
	}

	public void Exit()
	{
		Debug.Log("Idle ���� ����");
	}
}

