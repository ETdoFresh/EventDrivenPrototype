﻿using UnityEngine.Events;

public static class AddUnityEventListener
{
    public static void AddPersistentListener(this UnityEvent unityEvent, UnityAction call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.AddPersistentListener(unityEvent, call);
#else
        unityEvent.AddListener(call);
#endif
    }

    public static void AddPersistentListener<T0>(this UnityEvent<T0> unityEvent, UnityAction<T0> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.AddPersistentListener(unityEvent, call);
#else
        unityEvent.AddListener(call);
#endif
    }

    public static void AddPersistentListener<T0, T1>(this UnityEvent<T0, T1> unityEvent, UnityAction<T0, T1> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.AddPersistentListener(unityEvent, call);
#else
        unityEvent.AddListener(call);
#endif
    }

    public static void AddPersistentListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> unityEvent, UnityAction<T0, T1, T2> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.AddPersistentListener(unityEvent, call);
#else
        unityEvent.AddListener(call);
#endif
    }

    public static void AddPersistentListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> unityEvent, UnityAction<T0, T1, T2, T3> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.AddPersistentListener(unityEvent, call);
#else
        unityEvent.AddListener(call);
#endif
    }

    public static void RemovePersistentListener(this UnityEvent unityEvent, UnityAction call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.RemovePersistentListener(unityEvent, call);
#else
        unityEvent.RemoveListener(call);
#endif
    }

    public static void RemovePersistentListener<T0>(this UnityEvent<T0> unityEvent, UnityAction<T0> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.RemovePersistentListener(unityEvent, call);
#else
        unityEvent.RemoveListener(call);
#endif
    }

    public static void RemovePersistentListener<T0, T1>(this UnityEvent<T0, T1> unityEvent, UnityAction<T0, T1> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.RemovePersistentListener(unityEvent, call);
#else
        unityEvent.RemoveListener(call);
#endif
    }

    public static void RemovePersistentListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> unityEvent, UnityAction<T0, T1, T2> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.RemovePersistentListener(unityEvent, call);
#else
        unityEvent.RemoveListener(call);
#endif
    }

    public static void RemovePersistentListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> unityEvent, UnityAction<T0, T1, T2, T3> call)
    {
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.RemovePersistentListener(unityEvent, call);
#else
        unityEvent.RemoveListener(call);
#endif
    }
}