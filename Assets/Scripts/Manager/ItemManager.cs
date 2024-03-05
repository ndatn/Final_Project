using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Collectable;

public class ItemManager : MonoBehaviour
{
    public Collectable[] collectablesItems;

    private Dictionary<CollectableType, Collectable> collectableItemsDist = new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        foreach (Collectable item in collectablesItems)
        {
            AddItem(item);
        }
    }
    private void AddItem(Collectable item)
    {
        if (!collectableItemsDist.ContainsKey(item.type))
        {
            collectableItemsDist.Add(item.type, item);
        }
    }
    public Collectable GetItemByType(CollectableType type)
    {
        if (collectableItemsDist.ContainsKey(type))
        {
            return collectableItemsDist[type];
        }
        return null;
    }
}
