using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameEvent", menuName = "JW/GameEvent")]
public class GameEventScriptable : ScriptableObject
{
    public List<EventListener> listeners = new List<EventListener>();

    public void AddListener(EventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(EventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnRaised();
        }
    }
}
