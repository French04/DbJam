using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnabler : MonoBehaviour
{
    Shop shop;

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
            shop.gameObject.SetActive(false);
        }
        else
        {
            shop.gameObject.SetActive(true);
        }
    }
}
