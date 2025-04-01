using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    //이벤트 리스너 (옵저버)
    void Start()
    {
        //이벤트 구독
        EventManager.Instance.AddListener("PlayerHealthChanged",OnPlayerHealthcHanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }


    private void Oestroy()
    {
        //객체가 삭제될때 동작하는 함수
        EventManager.Instance.Removelistener("PlayerHealthChanged",OnPlayerHealthcHanged);
        EventManager.Instance.Removelistener("PlayerDied", OnPlayerDied); 
    }

    private void OnPlayerHealthcHanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI 업데이트 : 플레이어 체력이 {health}로 변경되었습니다.");
        //실제로는 여기서 UI요소를 업데이트 함
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI 업데이트 : 플레이어가 사망했습니다!");
        //게임 오버 화면 표시 등의 동작 수행
    }
}
