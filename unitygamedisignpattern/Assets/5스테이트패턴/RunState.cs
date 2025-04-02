using UnityEngine;

public class RunState : IState
{
    public void Enter()
	{
		Debug.Log("Run 상태 시작");
	}

	public void Update()
	{
		Debug.Log("Run 상태 유지즁");
	}

	public void Exit()
	{
		Debug.Log("Run 상태 종료");
	}
}
