using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public UnityEvent OnRaise;
    public GameEventScriptable GameEvent;
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        GameEvent.RemoveListener(this);
    }

    public void OnRaised()
    {
        Debug.Log($"Raised: {gameObject.name}");
        OnRaise?.Invoke();
    }
}
