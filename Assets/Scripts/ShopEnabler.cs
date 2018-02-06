using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnabler : MonoBehaviour
{
    Shop shop;
    public Texture2D aimTexture;
    public Texture2D cursorTexture;

    Animator sellerAnimator;

    public Color selectedColor, unselectedColor;

    private void Awake()
    {
        shop = FindObjectOfType<Shop>();
        sellerAnimator = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = selectedColor;
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
        myRenderer.color = unselectedColor;
    }

    public void EnableShop()
    {
        if (shop.gameObject.activeSelf)
        {
            Cursor.SetCursor(aimTexture, new Vector2(0, 0), CursorMode.Auto);
            shop.gameObject.SetActive(false);
            sellerAnimator.SetBool("IsClicked", true);
        }
        else
        {
            Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
            shop.gameObject.SetActive(true);
            sellerAnimator.SetBool("IsClicked", true);
        }
    }

    public void OpenShopFinish()
    {
        sellerAnimator.SetBool("IsClicked", false);
        sellerAnimator.SetBool("ShopIsClosed", false);
    }

    public void ClosedShopFinish()
    {
        sellerAnimator.SetBool("IsClicked", false);
        sellerAnimator.SetBool("ShopIsClosed", true);
    }
}
