using UnityEngine;

public class InputEvents : MonoBehaviour
{
    [SerializeField] private EventListGameObjectFloat horizontalEvent;
    [SerializeField] private EventListGameObjectFloat verticalEvent;
    [SerializeField] private EventListGameObjectBool fire1Event;
    [SerializeField] private EventListGameObjectBool fire2Event;
    [SerializeField] private EventListGameObjectBool jumpEvent;

    private float horizontal;
    private float vertical;

    private void Update()
    {
        if (horizontal != Input.GetAxisRaw("Horizontal"))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            horizontalEvent.Invoke(gameObject, horizontal);
        }
        if (vertical != Input.GetAxisRaw("Vertical"))
        {
            vertical = Input.GetAxisRaw("Vertical");
            verticalEvent.Invoke(gameObject, vertical);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            fire1Event.Invoke(gameObject, true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            fire1Event.Invoke(gameObject, false);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            fire2Event.Invoke(gameObject, true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            fire2Event.Invoke(gameObject, false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpEvent.Invoke(gameObject, true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpEvent.Invoke(gameObject, false);
        }
    }
}