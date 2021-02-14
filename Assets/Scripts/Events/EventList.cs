using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventList : ScriptableObject
{
    public abstract void Update();
}

public abstract class EventList<TSender> : EventList
{
    public List<EventArgs<TSender>> events = new List<EventArgs<TSender>>();
    public List<EventArgs<TSender>> queue = new List<EventArgs<TSender>>();
    public UnityEvent<TSender> onRaise = new UnityEvent<TSender>();

    private void OnDisable()
    {
        events.Clear();
        queue.Clear();
    }

    public bool Contains(TSender sender)
    {
        return events.Any(x => x.sender.Equals(sender));
    }

    public void Invoke(TSender sender)
    {
        var eventArgs = (EventArgs<TSender>)Activator.CreateInstance(typeof(EventArgs<TSender>));
        eventArgs.sender = sender;
        queue.Add(eventArgs);
    }

    public override void Update()
    {
        events.Clear();
        var newEvents = queue;
        queue = events;
        events = newEvents;
        foreach (var ev in events)
            onRaise.Invoke(ev.sender);
    }

    public override string ToString()
    {
        var output = "";
        foreach (var ev in events)
        {
            if (output != "") output += "\n";
            output += $"{name}: {ev.sender}";
        }
        return output;
    }
}

public abstract class EventList<TSender, T0> : EventList
{
    public List<EventArgs<TSender, T0>> events = new List<EventArgs<TSender, T0>>();
    public List<EventArgs<TSender, T0>> queue = new List<EventArgs<TSender, T0>>();
    public UnityEvent<TSender, T0> onRaise = new UnityEvent<TSender, T0>();

    private void OnDisable()
    {
        events.Clear();
        queue.Clear();
    }

    public bool Contains(TSender sender)
    {
        return events.Any(x => x.sender.Equals(sender));
    }

    public void Invoke(TSender sender, T0 parameter0)
    {
        var eventArgs = (EventArgs<TSender, T0>)Activator.CreateInstance(typeof(EventArgs<TSender, T0>));
        eventArgs.sender = sender;
        eventArgs.paramter0 = parameter0;
        queue.Add(eventArgs);
    }

    public override void Update()
    {
        events.Clear();
        var newEvents = queue;
        queue = events;
        events = newEvents;
        foreach (var ev in events)
            onRaise.Invoke(ev.sender, ev.paramter0);
    }

    public override string ToString()
    {
        var output = "";
        foreach (var ev in events)
        {
            if (output != "") output += "\n";
            output += $"{name}: {ev.sender} {ev.paramter0}";
        }
        return output;
    }
}
