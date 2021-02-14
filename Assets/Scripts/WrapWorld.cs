using System;
using UnityEngine;

public class WrapWorld : MonoBehaviour
{
    public Transform player;
    public WrapWorldTag[] wrappables;
    public Vector2 extents = new Vector2(0.5f, 0.5f);
    public Vector2 size = Vector2.one;
    public Vector2 playerTilePosition = Vector2.zero;
    public Vector2 playerTileSubposition = Vector2.zero;

    private void OnEnable()
    {
        wrappables = FindObjectsOfType<WrapWorldTag>();
    }

    private void Update()
    {
        playerTilePosition.x = Mathf.Floor(player.position.x / size.x);
        playerTilePosition.y = Mathf.Floor(player.position.z / size.y);
        playerTileSubposition.x = (player.position.x - playerTilePosition.x * size.x) / size.x;
        playerTileSubposition.y = (player.position.z - playerTilePosition.y * size.y) / size.y;

        if (playerTileSubposition.x < extents.x) MoveWrappablesLeft();
        else MoveWrappablesRight();
        if (playerTileSubposition.y < extents.y) MoveWrappablesDown();
        else MoveWrappablesUp();
    }

    private void MoveWrappablesRight()
    {
        foreach (var wrappable in wrappables)
            if (Mathf.Floor((wrappable.transform.position.x - wrappable.transform.lossyScale.x / 2) / size.x) < playerTilePosition.x)
                wrappable.transform.position += new Vector3(size.x * 2, 0, 0);
    }

    private void MoveWrappablesLeft()
    {
        foreach (var wrappable in wrappables)
            if (Mathf.Floor((wrappable.transform.position.x - wrappable.transform.lossyScale.x / 2) / size.x) > playerTilePosition.x)
                wrappable.transform.position -= new Vector3(size.x * 2, 0, 0);
    }

    private void MoveWrappablesDown()
    {
        foreach (var wrappable in wrappables)
            if (Mathf.Floor((wrappable.transform.position.z - wrappable.transform.lossyScale.z / 2) / size.y) > playerTilePosition.y)
                wrappable.transform.position -= new Vector3(0, 0, size.y * 2);
    }

    private void MoveWrappablesUp()
    {
        foreach (var wrappable in wrappables)
            if (Mathf.Floor((wrappable.transform.position.z - wrappable.transform.lossyScale.z / 2) / size.y) < playerTilePosition.y)
                wrappable.transform.position += new Vector3(0, 0, size.y * 2);
    }
}
