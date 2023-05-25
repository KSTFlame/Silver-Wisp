using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisInputController : MonoBehaviour
{
    [SerializeField]
    private string _axis = "Horizontal";

    public float Axis => Input.GetAxis(_axis);
}
