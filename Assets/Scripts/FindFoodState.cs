using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Find Food State")]
public class FindFoodState : State
{
    [SerializeField] private LayerMask whatIsFood;
    [SerializeField] private float checkingSphereRadius;

    public override void Run()
    {
        Character.MoveForward();
        FindFood();
    }

    private void FindFood()
    {
        var food = Physics.OverlapSphere(Character.CachedTransform.position, checkingSphereRadius, whatIsFood);
        
        if (food.Length != 0)
        {
            Character.TargetFood = food[0].transform;
            IsFinished = true;
        }
    }
}
