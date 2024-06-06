using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    private List<Collider> collidersInMe;

    public List<Collider> CollidersInMe
    {
        get { return collidersInMe; }
    }

    private void Awake()
    {
        collidersInMe = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        collidersInMe.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        collidersInMe.Remove(other);
    }
}
