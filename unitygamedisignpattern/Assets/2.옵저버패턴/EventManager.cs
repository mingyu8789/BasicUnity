using System;
using System.Collections.Generic;
using UnityEngine;

//이벤트 관리자(Subject)
public class EventManager : MonoBehaviour
{
    //싱글톤 구현
    private static EventManager _instance;

    public static EventManager Instance
    {
        get{
            if(_instance == null)
            {
                GameObject go = new GameObject("EventManager");
                _instance = go.AddComponent<EventManager>();
                DontDestroyOnLoad(go);  //씬을 전환해도 파괴되지 않음 다른씬에서도 사용가능함
            }
            return _instance;
        }
    }


    //이벤트와 옵저버를 연결하는 딕셔너리
    private Dictionary<string,Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

    //이벤트에 옵저버 추가
    public void AddListener (String eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent += listener;
            _eventDictionary[eventName] = thisEvent;
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    //이벤트에서 옵저버 제거
    public void Removelistener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = thisEvent;
        }
    }

    //이벤트발생(모든 옵저버에게 알림)
    public void TriggerEvent(string eventName,object data = null)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }




    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
