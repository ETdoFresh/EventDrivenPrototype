using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Functions
{
    public static void SetImageColor(Image image, Color color)
    {
        image.color = color;
    }

    public static void SetImageSprite(Image image, Sprite sprite)
    {
        image.sprite = sprite;
    }

    public static void UpdateTimer(Timer timer, TimerFinishedEvent timerEvents)
    {
        var previousTime = timer.time;
        timer.time += Time.deltaTime;
        if (previousTime < timer.duration && timer.time >= timer.duration)
            timerEvents.Invoke(timer);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void FadeIn(Image image, Timer timer, float fadeInTime)
    {   
        if (timer.time >= fadeInTime && image.color.a == 1)
            return;
        
        var color = image.color;
        var t = timer.time / fadeInTime;
        t = Mathf.Clamp01(t);
        color.a = t;
        image.color = color;
    }

    public static void FadeOut(Image image, Timer timer, float fadeOutTime)
    {   
        if (timer.time < timer.duration - fadeOutTime)
            return;
        
        var color = image.color;
        var t = (timer.time - (timer.duration - fadeOutTime)) / fadeOutTime;
        t = Mathf.Clamp01(t);
        color.a = 1 - t;
        image.color = color;
    }

    public static void RestartTimer(Timer timer)
    {
        if (Input.GetKeyDown(KeyCode.R))
            timer.time = 0;
    }

    public static void JumpRigidbody(EventList<GameObject> evnt, GameObject gameObject, Rigidbody rigidbody, float jumpForce)
    {
        if (evnt.Contains(gameObject))
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public static void PollAndQueue<T0, T1>(EventList<T0, T1> eventList, Queue<T1> queue)
    {
        foreach (var ev in eventList.events)
            queue.Enqueue(ev.paramter0);
    }

    public static void PollAndSet<T0, T1>(EventList<T0, T1> eventList, T1 originalValue, out T1 output)
    {
        output = originalValue;
        foreach (var ev in eventList.events)
            output = ev.paramter0;
    }

    public static void InvokeEventFromQueueBool<T>(Queue<bool> queue, EventList<T> ev, T sender)
    {
        if (CheckAndDequeue(queue))
            ev.Invoke(sender);
    }

    public static void RotateTowardsInput(Transform transform, float horizontal, float vertical)
    {
        var input = new Vector3(horizontal, 0, vertical);
        if (input.sqrMagnitude > 0)
            transform.rotation = Quaternion.LookRotation(input);
    }

    public static void MoveRigidbody(Rigidbody rigidbody, float horizontal, float vertical, float speed)
    {
        var x = horizontal * speed;
        var z = vertical * speed;
        var velocity = new Vector3(x, 0, z);
        var position = rigidbody.position;
        var newPosition = position + velocity * Time.deltaTime;
        rigidbody.MovePosition(newPosition);
    }

    public static T CheckAndDequeue<T>(Queue<T> queue)
    {
        if (queue.Count > 0)
            return queue.Dequeue();
        else
            return default;
    }
}
