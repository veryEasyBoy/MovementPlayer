using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MousStats", menuName = "MousStats", order = 51)]
public class MousStats : ScriptableObject
{
    public float sensitivity;
    public Vector3 playerEulerAngles;
    public float verticalMaxRangeRotate;
}
