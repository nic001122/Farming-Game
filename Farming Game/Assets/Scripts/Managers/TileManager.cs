using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;

    [SerializeField] GameObject player;
    Vector2 playerPos;
    Vector2 cursorPos;

    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {   
            TileBase tile = interactableMap.GetTile(position);

            if(tile != null && tile.name == "Interactable Visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    void Update()
    {
        playerPos = player.transform.position;
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public int isInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(cursorInRange())
            {
                if(tile.name == "Interactable")
                {
                    return 2;
                }
            }
            if(!cursorInRange())
            {
                if(tile.name == "Interactable")
                {
                    return 1;
                }
            }
        }

        return 0;
    }

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }

    public bool cursorInRange()
    {
        if(Vector2.Distance(playerPos, cursorPos) < 2.5 && Vector2.Distance(playerPos, cursorPos) > 0)
        {
            return true;
        }
        return false;
    }
}
