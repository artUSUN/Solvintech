using UnityEngine;

[CreateAssetMenu(menuName = "States/Move To Food State")]
public class MoveToFoodState : State
{
    public override void Init()
    {
        base.Init();
        LookAtFood();
    }

    public override void Run()
    {
        if (Character.TargetFood == null)
        {
            IsFinished = true;
            return;
        }
        Character.MoveForward();
    }

    private void LookAtFood()
    {
        Vector3 relative = Character.CachedTransform.InverseTransformPoint(Character.TargetFood.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        Character.SetDirectionOfView(angle);
    }
}
