using System;
using System.Collections.Generic;
using UnityEngine;

//�̺�Ʈ ������(Subject)
public class EventManager : MonoBehaviour
{
    //�̱��� ����
    private static EventManager _instance;

    public static EventManager Instance
    {
        get{
            if(_instance == null)
            {
                GameObject go = new GameObject("EventManager");
                _instance = go.AddComponent<EventManager>();
                DontDestroyOnLoad(go);  //���� ��ȯ�ص� �ı����� ���� �ٸ��������� ��밡����
            }
            return _instance;
        }
    }


    //�̺�Ʈ�� �������� �����ϴ� ��ųʸ�
    private Dictionary<string,Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

    //�̺�Ʈ�� ������ �߰�
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

    //�̺�Ʈ���� ������ ����
    public void Removelistener(string eventName, Action<object> listener)
    {
        if(_eventDictionary.TryGetValue(eventName,out Action<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = thisEvent;
        }
    }

    //�̺�Ʈ�߻�(��� ���������� �˸�)
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
