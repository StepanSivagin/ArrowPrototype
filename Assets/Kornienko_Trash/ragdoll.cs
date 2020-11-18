using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;

    void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        setRigidbodyState(true);
    }

    public void die()
    {
        setRigidbodyState(false);
    }

    void setRigidbodyState(bool state)
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.tag = "Finish";
            rigidbody.isKinematic = state;
            GetComponent<Animator>().enabled = state;
        }
    }
}
