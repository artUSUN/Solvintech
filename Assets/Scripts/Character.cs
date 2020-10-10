using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform world;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float checkingBombSize = 1f;
    [SerializeField] private LayerMask whatIsObstacle;

    [SerializeField] private State findFoodState;
    [SerializeField] private State moveToFoodState;
    [SerializeField] private State bypassObstacleState;


    [SerializeField] private State currentState;

    public Transform TargetFood { get; set; }
    public List<Collider> Obstacles { get; private set; }
    public float CheckingBombSize { get { return checkingBombSize; } }
    public Transform CachedTransform { get; private set; }

    private void Start()
    {
        CachedTransform = transform;
        SetState(findFoodState);
        Obstacles = new List<Collider>();
    }

    private void Update()
    {
        var temp = CheckObstacleForward();

        if (temp.Length != 0)
        {
            Obstacles.Clear();
            Obstacles.AddRange(temp);
            SetState(bypassObstacleState);
        }
        else if (!currentState.IsFinished)
        {
            currentState.Run();
        }
        else
        {
            if (TargetFood != null) SetState(moveToFoodState);
            else SetState(findFoodState);
        }
    }

    public void SetState(State state)
    {
        currentState = Instantiate(state);
        currentState.Character = this;
        currentState.Init();
    }

    public void SetDirectionOfView(float angle)
    {
        CachedTransform.Rotate(0, angle, 0, Space.Self);
    }

    public void MoveForward()
    {
        CachedTransform.RotateAround(world.position, transform.right, moveSpeed * Time.deltaTime);
    }

    private Collider[] CheckObstacleForward()
    {
        Vector3 center = CachedTransform.position + CachedTransform.forward * (CachedTransform.localScale.x / 2 + checkingBombSize / 2);
        Vector3 scale = new Vector3(CachedTransform.localScale.x / 2, checkingBombSize / 2, CachedTransform.localScale.z / 2);
        return Physics.OverlapBox(center, scale, CachedTransform.localRotation, whatIsObstacle);
    }

    //private void OnDrawGizmos()
    //{
    //    // if (currentState is FindFoodState) Gizmos.DrawSphere(transform.position, 3);
    //    Vector3 pos = CachedTransform.position + CachedTransform.forward * (CheckingBombSize / 2);
    //    Gizmos.DrawSphere(pos, 1.5f);

    //    Gizmos.DrawCube(CachedTransform.position + CachedTransform.forward * (CachedTransform.localScale.x / 2 + checkingBombSize / 2),
    //        new Vector3(CachedTransform.localScale.x, checkingBombSize, CachedTransform.localScale.z));
    //}
}
