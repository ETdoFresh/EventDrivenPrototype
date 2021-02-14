using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Functions;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Listening to...")]
    public EventListGameObjectFloat horizontalEventList;
    public EventListGameObjectFloat verticalEventList;
    public EventListGameObjectBool jumpEventList;
    public EventListGameObjectBool fire1EventList;

    [Header("Invokes...")]
    public CharacterActionEvent punchEvent;
    public CharacterActionEvent kickEvent;
    public CharacterActionEvent jumpEvent;

    [Header("Data")]
    public new Rigidbody rigidbody;
    public float speed = 5;
    public float horizontal;
    public float vertical;
    public Queue<bool> jumpQueue = new Queue<bool>();
    public Queue<bool> fire1Queue = new Queue<bool>();

    [Header("Functions")]
    public bool pollHorizontal = true;
    public bool pollVertical = true;
    public bool pollJump = true;
    public bool pollFire1 = true;
    public bool invokePunch = true;
    public bool invokeJump = true;
    public bool movement = true;
    public bool jump = true;
    public bool rotation = true;

    void Update()
    {
        if (pollHorizontal) PollAndSet(horizontalEventList, horizontal, out horizontal);
        if (pollVertical) PollAndSet(verticalEventList, vertical, out vertical);
        if (pollJump) PollAndQueue(jumpEventList, jumpQueue);
        if (pollFire1) PollAndQueue(fire1EventList, fire1Queue);

        if (invokePunch) InvokeEventFromQueueBool(fire1Queue, punchEvent, gameObject);
        if (invokeJump) InvokeEventFromQueueBool(jumpQueue, jumpEvent, gameObject);

        if (movement) MoveRigidbody(rigidbody, horizontal, vertical, speed);
        if (jump) JumpRigidbody(jumpEvent, gameObject, rigidbody, speed);
        if (rotation) RotateTowardsInput(transform, horizontal, vertical);
    }
}
