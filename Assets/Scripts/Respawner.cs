using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public abstract class Respawner : MonoBehaviour
{
    protected Spawner spawner;

    protected virtual void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    public abstract void Respawn(Transform obj);
}
