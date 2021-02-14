using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public enum Mode { FollowClose, FollowFar, OriginFar}
    public Mode mode = Mode.FollowClose;
    public Transform target;
    public EventListGameObjectBool changeCameraEvent;

    private void OnEnable()
    {
        changeCameraEvent.onRaise.AddPersistentListener(Toggle);
    }

    private void OnDisable()
    {
        changeCameraEvent.onRaise.RemovePersistentListener(Toggle);
    }

    private void Toggle(GameObject input, bool pressed)
    {
        if (pressed)
            mode = (Mode)(((int)mode + 1) % Enum.GetValues(typeof(Mode)).Length);
    }

    void LateUpdate()
    {
        if (mode == Mode.OriginFar)
            transform.position = new Vector3(0, 10, 0);
        if (mode == Mode.FollowClose)
            transform.position = new Vector3(target.position.x, .8f, target.position.z);
        if (mode == Mode.FollowFar)
            transform.position = new Vector3(target.position.x, 5, target.position.z);
    }
}
