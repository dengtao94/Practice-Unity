using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager{

    private static EventManager instance;

    private Dictionary<string, List<IEventHandler>> dicHandler;

    private EventManager()
    {
        dicHandler = new Dictionary<string, List<IEventHandler>>();
    }

    public static EventManager GetInstance()
    {
        if (instance == null)
        {
            instance = new EventManager();
        }
        return instance;
    }

    /// <summary>  
    /// 注册事件监听  
    /// </summary>  
    /// <param name="type">监听类型</param>  
    /// <param name="listher">监听对象</param>  
    public void AddEventListener(string type, IEventHandler listher)
    {
        if (!dicHandler.ContainsKey(type))
        {
            dicHandler.Add(type, new List<IEventHandler>());
        }
        dicHandler[type].Add(listher);
    }

    /// <summary>  
    /// 移除对type的所有监听  
    /// </summary>  
    /// <param name="type"></param>  
    public void RemoveEventListener(string type)
    {
        if (dicHandler.ContainsKey(type))
        {
            dicHandler.Remove(type);
        }
    }

    /// <summary>  
    /// 移除监听者的所有监听  
    /// </summary>  
    /// <param name="listener">监听者</param>  
    public void RemoveEventListener(IEventHandler listener)
    {
        foreach (var item in dicHandler)
        {
            if (item.Value.Contains(listener))
            {
                item.Value.Remove(listener);
            }
        }
    }

    /// <summary>  
    /// 清空所有监听事件  
    /// </summary>  
    public void ClearEventListener()
    {
        Debug.Log("清空对所有所有所有事件的监听");
        if (dicHandler != null)
        {
            dicHandler.Clear();
        }
    }

    /// <summary>  
    /// 派发事件  
    /// </summary>  
    /// <param name="type">事件类型</param>  
    /// <param name="data">事件传达的数据</param>  
    public void DispachEvent(string type, object data)
    {
        if (!dicHandler.ContainsKey(type))
        {
            Debug.Log("Did not add any IEventHandler of " + type + " in EventManager!");
            return;
        }

        List<IEventHandler> list = dicHandler[type];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].OnEvent(type, data);
        }
    }
}
