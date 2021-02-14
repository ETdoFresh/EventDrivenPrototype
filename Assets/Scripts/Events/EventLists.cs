using System;
using System.Collections.Generic;
using UnityEngine;

public class EventLists : ScriptableObject
{
    public List<EventList> lists = new List<EventList>();
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(EventLists))]
public class EventsCustomEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(12);
        if (GUILayout.Button("Refresh and Add ALL EventLists"))
            RefreshAndAddAllEventTypes((EventLists)target);
    }

    private void RefreshAndAddAllEventTypes(EventLists events)
    {
        events.lists.Clear();
        foreach(var guid in UnityEditor.AssetDatabase.FindAssets("t:EventList"))
        {
            var assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<EventList>(assetPath);
            events.lists.Add(asset);
        }
    }
}
#endif