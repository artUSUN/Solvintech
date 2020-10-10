using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private VoidEvent foodFound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OrangeCube"))
        {
            foodFound.Raise();
            Destroy(transform.gameObject);
        }
    }
}
