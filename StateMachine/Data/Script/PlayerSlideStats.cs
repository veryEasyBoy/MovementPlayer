using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerSlideStats", menuName = "PlayerSlideStats",order = 51)]
public class PlayerSlideStats : ScriptableObject
{
    public float DurationRide;
    public float AccelerationRide;
    public float StartDurationRide { get { return DurationRide; }}
}
