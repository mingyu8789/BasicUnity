using UnityEngine;

public class JumpState : IState
{   
     public void Enter()
	{
		Debug.Log("Jump ���� ����");
	}

	public void Update()
	{
		Debug.Log("Jump ���� �����O");
	}

	public void Exit()
	{
		Debug.Log("Jump ���� ����");
	}
}
