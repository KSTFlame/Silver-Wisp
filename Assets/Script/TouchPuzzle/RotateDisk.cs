using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RotateDisk : MonoBehaviour, IPointerDownHandler
{
    [System.Serializable]
    public struct otherDisks
    {
        public GameObject disksLink;
        public bool isSameRotation;
        public float addRotation;
    }
    [SerializeField]
    public List<otherDisks> correlateDisks;
    private Vector3 _dragStartPosition;
    private Vector3 _dragEndPosition;
    private float _swipeResist = 1f;
    private float _swipeAngle = 0;
    [SerializeField]
    private float _angleRotate = 45;

    private void Start()
    {
        //StartWheelGenerator random times between 1 and 5.
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            StartWheelGenerator();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _dragEndPosition = Input.mousePosition;
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

    /// <summary>
    /// Calculate the angle of the swipe
    /// </summary>
    private void CalculateSide()
    {
        //Check the Angle
        if (Mathf.Abs(_dragEndPosition.x - _dragStartPosition.x) > _swipeResist)
        {
            _swipeAngle = Mathf.Atan2(_dragEndPosition.y - _dragStartPosition.y, _dragEndPosition.x - _dragStartPosition.x) * 180 / Mathf.PI;
        }
    }

    /// <summary>
    /// Move the disk and the other correlate disk in clockwise or anticlockwise depending on the swipe angle
    /// </summary>
    private void MoveWheel()
    {
        float rotation;
        if (_swipeAngle > -90 && _swipeAngle <= 90)
        {
            //Right Swipe
            transform.Rotate(0, -_angleRotate, 0);
            for (int i = 0; i < correlateDisks.Count; i++)
            {
                //if change the rotation direction and there is a 
                if (!correlateDisks[i].isSameRotation) rotation = -1;
                else rotation = 1;
                correlateDisks[i].disksLink.transform.Rotate(0, rotation * (-_angleRotate + correlateDisks[i].addRotation), 0);
            }
        }
        else if ((_swipeAngle > 90 || _swipeAngle <= -90))
        {
            //Left Swipe
            transform.Rotate(0, _angleRotate, 0);
            for (int i = 0; i < correlateDisks.Count; i++)
            {
                if (!correlateDisks[i].isSameRotation) rotation = -1;
                else rotation = 1;
                correlateDisks[i].disksLink.transform.Rotate(0, rotation * (_angleRotate + correlateDisks[i].addRotation), 0);
            }
        }
    }

    private void StartWheelGenerator()
    {
        float rotation;
        transform.Rotate(0, -_angleRotate, 0);
        for (int i = 0; i < correlateDisks.Count; i++)
        {
            //if change the rotation direction and there is a 
            if (!correlateDisks[i].isSameRotation) rotation = -1;
            else rotation = 1;
            correlateDisks[i].disksLink.transform.Rotate(0, rotation * (-_angleRotate + correlateDisks[i].addRotation), 0);
        }
    }
}
