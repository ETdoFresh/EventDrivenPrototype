using UnityEngine;

public class UnityEventsSO : MonoBehaviour
{
    [SerializeField] private EventListGameObject onEnable = null;
    [SerializeField] private EventListGameObject onDisable = null;
    [SerializeField] private EventListGameObjectCollision onCollisionEnter = null;
    [SerializeField] private EventListGameObjectCollision onCollisionStay = null;
    [SerializeField] private EventListGameObjectCollision onCollisionExit = null;
    [SerializeField] private EventListGameObjectCollider onTriggerEnter = null;
    [SerializeField] private EventListGameObjectCollider onTriggerStay = null;
    [SerializeField] private EventListGameObjectCollider onTriggerExit = null;

    private void OnEnable() => onEnable.Invoke(gameObject);
    private void OnDisable() => onDisable.Invoke(gameObject);
    private void OnCollisionEnter(Collision collision) => onCollisionEnter.Invoke(gameObject, collision);
    private void OnCollisionStay(Collision collision) => onCollisionStay.Invoke(gameObject, collision);
    private void OnCollisionExit(Collision collision) => onCollisionExit.Invoke(gameObject, collision);
    private void OnTriggerEnter(Collider other) => onTriggerEnter.Invoke(gameObject, other);
    private void OnTriggerStay(Collider other) => onTriggerStay.Invoke(gameObject, other);
    private void OnTriggerExit(Collider other) => onTriggerExit.Invoke(gameObject, other);
}
