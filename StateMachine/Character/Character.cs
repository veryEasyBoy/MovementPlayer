using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [NonSerialized] public new Transform transform;
    [NonSerialized] public Rigidbody rb;
    [NonSerialized] public CapsuleCollider colliderCharacter;
    public float speed;

    private void Awake()
    {
        ListForCheck();
    }
    public void CheckParams<T>(out T param)
    {
        param = gameObject.GetComponent<T>();
    }
    public void ListForCheck()
    {
        CheckParams(out transform);
        CheckParams(out rb);
        CheckParams(out colliderCharacter);
    }
}
