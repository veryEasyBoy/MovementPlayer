using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "CharacterStats", order = 51)]
public class CharacterStats : ScriptableObject
{
    public float speed = 8;
    public float sensetivity;
    public float hp;
    public float hpMax;
    public KeyCode slide; 
    public float Hp { get { return hp; } set { if (value != hp) hp = value; } }
    public float HpMax { get { return hpMax; } set { hpMax = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float Sensetivity { get { return sensetivity; } set { sensetivity = value; } }
}
