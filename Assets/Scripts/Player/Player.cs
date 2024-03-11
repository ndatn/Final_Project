using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    private Tilemap interactableMap;
    private void Awake()
    {
        inventory = new Inventory(24);
        interactableMap = GameObject.Find("InteractableMap").GetComponent<Tilemap>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int cellPosition = interactableMap.WorldToCell(transform.position); // Chuyển đổi vị trí thế giới thành vị trí trong tilemap

            if (GameManager.instance.tileManager.IsInteractable(cellPosition))
            {
                Debug.Log("Tile is interactable");
                GameManager.instance.tileManager.SetInteracted(cellPosition);
            }
        }
    }
    public void DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;
        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
        droppedItem.rb.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }
}
