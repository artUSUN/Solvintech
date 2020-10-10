using UnityEngine;

public class RotateAroundCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 speed = Vector2.one;

    public void Rotate(Vector2 direction)
    {
        transform.RotateAround(target.position, transform.up, direction.x * speed.x);
        transform.RotateAround(target.position, transform.right * -1, direction.y * speed.y);
    }
}
