using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class EventLog : MonoBehaviour
{
    public string pattern = "^((?!OnCollisionStay)(?!OnTriggerStay).)*$";
    public EventLists events;

    private void Update()
    {
        foreach (var eventList in events.lists)
            if (eventList)
                if (eventList.ToString() != "")
                    if (string.IsNullOrEmpty(pattern))
                        Debug.Log(eventList);
                    else if (Regex.IsMatch(eventList.ToString(), pattern))
                        Debug.Log(eventList);
    }
}
