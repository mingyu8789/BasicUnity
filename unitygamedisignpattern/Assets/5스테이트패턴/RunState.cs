using UnityEngine;

public class RunState : IState
{
    public void Enter()
	{
		Debug.Log("Run ���� ����");
	}

	public void Update()
	{
		Debug.Log("Run ���� �����O");
	}

	public void Exit()
	{
		Debug.Log("Run ���� ����");
	}
}
