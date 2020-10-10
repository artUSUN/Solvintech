using UnityEngine;

[CreateAssetMenu(menuName = "States/Bypass Obstacle State")]
public class BypassObstacleState : State
{
    [SerializeField] private LayerMask whatIsObstacle;
    [SerializeField] private float checkingSphereRadius = 2.5f;

    public override void Init()
    {
        base.Init();


        if (Character.Obstacles.Count == 1)
        {
            Vector3 relative = Character.CachedTransform.InverseTransformPoint(Character.Obstacles[0].transform.position);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            Character.SetDirectionOfView(-angle);
        }
        else
        {
            Vector3 sum = Vector3.zero;
            foreach (var item in Character.Obstacles)
            {
                sum += Character.CachedTransform.InverseTransformPoint(item.transform.position);
            }
            float angle = Mathf.Atan2(sum.x, sum.z) * Mathf.Rad2Deg;
            Character.SetDirectionOfView(angle);
        }
    }

    public override void Run()
    {
        Character.MoveForward();
        if (!CheckObstacleAround())
        {
            IsFinished = true;
        }
    }

    private bool CheckObstacleAround()
    {
        Vector3 pos = Character.CachedTransform.position + Character.CachedTransform.forward * (Character.CheckingBombSize / 2);
        return Physics.CheckSphere(pos, checkingSphereRadius, whatIsObstacle);
    }
}
