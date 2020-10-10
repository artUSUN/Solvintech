using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform sphere;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] [Tooltip("An object on the sphere, relative to which others will spawn")] private Transform relativeObject;
    [SerializeField] [Min(0)] private int quantity = 0;
    [SerializeField] [Range(0, 180)] private float limit;

    public List<Transform> SpawnedObjects { get; private set; }
    public GameObject SpawnObject { get { return spawnObject; } }

    private void Start()
    {
        SpawnedObjects = new List<Transform>();
        for (int i = 0; i < quantity; i++) Spawn();
    }

    public void Spawn()
    {
        var newObject = Instantiate(spawnObject, transform);
        SpawnedObjects.Add(newObject.transform);
        SetRandomPosition(newObject.transform);
    }

    public void SetRandomPosition(Transform obj)
    {
        PlaceOpposite(obj.transform, relativeObject);
        RotateAround(obj.transform);
    }

    private void PlaceOpposite(Transform obj, Transform relatival)
    {
        Vector3 direction = sphere.position - relatival.position;
        obj.position = direction * ((sphere.localScale.x / 2 + spawnObject.transform.localScale.y / 2) / (sphere.localScale.x / 2 + relatival.localScale.y / 2));
        obj.rotation = relatival.rotation;
        obj.localRotation *= Quaternion.Euler(180f, 0, 0);
    }

    private void RotateAround(Transform obj)
    {
        obj.RotateAround(sphere.position, obj.forward, Random.Range(-limit, limit));
        obj.RotateAround(sphere.position, obj.right, Random.Range(-limit, limit));
    }
}
