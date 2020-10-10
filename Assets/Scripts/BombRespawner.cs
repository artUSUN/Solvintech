using System.Collections;
using UnityEngine;

public class BombRespawner : Respawner
{
    [SerializeField] private float timeBetweenRespawn = 5f;
    [SerializeField] private float timeBetweenFlashing = 0.2f;
    [SerializeField] private int numOfFlashIteration = 3;
    [SerializeField] private Material bombMaterial;
    private WaitForSeconds waitStartFlash;
    private WaitForSeconds waitEnd;
    private WaitForSeconds waitFlash;
    private Color baseColor;

    protected override void Start()
    {
        base.Start();
        waitStartFlash = new WaitForSeconds(timeBetweenRespawn - timeBetweenFlashing * numOfFlashIteration * 2);
        waitEnd = new WaitForSeconds(timeBetweenFlashing * numOfFlashIteration * 2);
        waitFlash = new WaitForSeconds(timeBetweenFlashing);
        baseColor = bombMaterial.color;
        
        StartCoroutine(PeriodicRespawn());
    }

    public override void Respawn(Transform obj)
    {
        spawner.SetRandomPosition(obj);
    }

    private IEnumerator PeriodicRespawn()
    {

        yield return waitStartFlash;
        StartCoroutine(Flashing());
        yield return waitEnd;
        foreach (var item in spawner.SpawnedObjects)
        {
            Respawn(item);
        }
        StartCoroutine(PeriodicRespawn());
    }

    private IEnumerator Flashing()
    {
        Color colorLowAplha = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a / 2);

        for (int i = 0; i < numOfFlashIteration; i++)
        {
            bombMaterial.SetColor("_Color", colorLowAplha);
            yield return waitFlash;
            bombMaterial.SetColor("_Color", baseColor);
            yield return waitFlash;
        }
    }

    private void OnDisable()
    {
        bombMaterial.color = baseColor;
    }
}
