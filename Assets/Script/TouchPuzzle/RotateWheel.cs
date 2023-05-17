using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateWheel : MonoBehaviour , IPointerDownHandler
{
    private Vector3 dragStartPosition;
    private Vector3 dragEndPosition;
    private float swipeResist = 1f;
    private float swipeAngle = 0;
    [SerializeField] private float angleRotate = 45;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragEndPosition = Input.mousePosition;
            CalculateSide();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(ray);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    MoveWheel();
                }
            }
        }
    }
    private void CalculateSide()
    {
        //Check the Angle
        if (Mathf.Abs(dragEndPosition.x - dragStartPosition.x) > swipeResist)
        {
            swipeAngle = Mathf.Atan2(dragEndPosition.y - dragStartPosition.y, dragEndPosition.x - dragStartPosition.x) * 180 / Mathf.PI;
        }
    }
    private void MoveWheel()
    {
        if (swipeAngle > -90 && swipeAngle <= 90)
        {
            //Right Swipe
            transform.Rotate(0, -angleRotate,0);

        }
        else if ((swipeAngle > 90 || swipeAngle <= -90))
        {
            //Left Swipe
            transform.Rotate(0, angleRotate,0);
        }
    }

}
