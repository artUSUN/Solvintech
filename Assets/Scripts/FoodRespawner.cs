using UnityEngine;

public class FoodRespawner : Respawner
{
    public override void Respawn(Transform obj) { }

    public void Respawn()
    {
        spawner.Spawn();
    }
}
