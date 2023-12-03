using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour
{
    [SerializeField]
    LayerMask wallLayer;
    private bool isGrabbed = false;
    private Vector3 offset;

    public static Action OnCollisionHappen;
    public static Action OnReachEnd;
    void OnMouseDown()
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            offset = transform.position - GetMouseWorldPos();
        }
    }

    void OnMouseUp()
    {
        if (isGrabbed)
        {
            isGrabbed = false;
        }
    }

    public void LetItGo()
    {
        isGrabbed = false;
    }

    void Update()
    {
        if (isGrabbed)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;
            GetComponent<Rigidbody2D>().MovePosition(targetPos);
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wallLayer == (wallLayer | (1 << collision.gameObject.layer)))
        {
            OnCollisionHappen?.Invoke();
        } else
        {
            OnReachEnd?.Invoke();
        }
    }
}
