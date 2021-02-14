using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance;
    public EventLists eventLists;

    [RuntimeInitializeOnLoadMethod]
    public static void CreateNewInstance()
    {
        if (instance) return;
        var gameObject = new GameObject("EventHandler");
        instance = gameObject.AddComponent<EventHandler>();
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            if (!eventLists) eventLists = Resources.Load<EventLists>("EventLists");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this == instance)
            instance = null;
    }

    private void LateUpdate()
    {
        foreach (var eventList in eventLists.lists)
            eventList?.Update();
    }
}
