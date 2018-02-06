using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnabler : MonoBehaviour
{
    Shop shop;
    public Texture2D aimTexture;
    public Texture2D cursorTexture;

    private void Awake()
    {
        shop = FindObjectOfType<Shop>();
    }

    private void OnMouseEnter()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = Color.blue;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnableShop();
        }
    }

    private void OnMouseExit()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = Color.red;
    }

    public void EnableShop()
    {
        if (shop.gameObject.activeSelf)
        {
            Cursor.SetCursor(aimTexture, new Vector2(0, 0), CursorMode.Auto);
            shop.gameObject.SetActive(false);
        }
        else
        {
            Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
            shop.gameObject.SetActive(true);
        }
    }
}
