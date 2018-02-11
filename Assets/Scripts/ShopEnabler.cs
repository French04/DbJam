using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnabler : MonoBehaviour
{
    /*Shop shop;
    public Texture2D aimTexture;
    public Texture2D cursorTexture;

    Animator sellerAnimator;

    public Color selectedColor, unselectedColor;

    [HideInInspector]
    public bool openShop = false;

    bool canClickOnSeller = true;

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
        if (Input.GetMouseButtonDown(0) && canClickOnSeller == true)
        {
            canClickOnSeller = false;
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(aimTexture, new Vector2(aimTexture.width / 2, aimTexture.height / 2), CursorMode.Auto);
            //shop.gameObject.SetActive(false);
            sellerAnimator.SetBool("IsClicked", true);
            openShop = false;
        }
        else
        {
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);
            //shop.gameObject.SetActive(true);
            sellerAnimator.SetBool("IsClicked", true);
            openShop = true;
        }
    }

    public void OpenShopFinish()
    {
        sellerAnimator.SetBool("IsClicked", false);
        sellerAnimator.SetBool("ShopIsClosed", false);
        shop.gameObject.SetActive(true);
        canClickOnSeller = true;
    }

    public void ClosedShopFinish()
    {
        sellerAnimator.SetBool("IsClicked", false);
        sellerAnimator.SetBool("ShopIsClosed", true);
        shop.gameObject.SetActive(false);
        canClickOnSeller = true;
    }*/
}
