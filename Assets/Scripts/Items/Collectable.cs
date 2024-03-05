using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    public Rigidbody2D rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            GameObject collectableObject = new GameObject("Collectable");
            Collectable collectable = collectableObject.AddComponent<Collectable>();
            collectable.type = type;
            collectable.icon = icon;

            player.inventory.Add(collectable);

            Destroy(this.gameObject);
        }
    }

    public enum CollectableType
    {
        NONE,
        CHEST
    }
}
