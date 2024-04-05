using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    TileManager tileManager;

    Vector3 mousePos;

    [SerializeField] Texture2D defaultCursor;
    [SerializeField] Texture2D clickCursor;
    [SerializeField] Texture2D tappedCursor;
    [SerializeField] Texture2D transparentClickCursor;
    Vector2 clickPos;
    bool defaultClickSprite;

    private void Awake()
    {
        inventory = new Inventory(21);
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cursorPosition = new Vector3Int((int)mousePos.x, (int)mousePos.y, 0);

        if(GameManager.instance.tileManager.isInteractable(cursorPosition) == 2)
        {
            changeMouseClickPos();
            defaultClickSprite = false;
            Cursor.SetCursor(clickCursor, clickPos, CursorMode.Auto);
            if(Input.GetKeyDown(KeyCode.F))
            {
                GameManager.instance.tileManager.SetInteracted(cursorPosition);
            }
        }

        if(GameManager.instance.tileManager.isInteractable(cursorPosition) == 1)
        {
            changeMouseClickPos();
            defaultClickSprite = false;
            Cursor.SetCursor(transparentClickCursor, clickPos, CursorMode.Auto);
        }

        if(GameManager.instance.tileManager.isInteractable(cursorPosition) == 0)
        {
            changeMouseClickPos();
            defaultClickSprite = true;
            Cursor.SetCursor(defaultCursor, clickPos, CursorMode.Auto);
        }
    }

    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = Random.insideUnitCircle * 1.5f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }

    void changeMouseClickPos()
    {
        if(defaultClickSprite)
        {
            clickPos = new Vector2(0, 0);
        }

        if(!defaultClickSprite)
        {
            clickPos = new Vector2(8, 0);
        }
    }
}
