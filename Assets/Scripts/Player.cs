using UnityEngine;

public class Player : MonoBehaviour
{
    private int _damage = 0;

    private void Start()
    {
        InfinitySpawn.Instans.OnBossSpawn += (X) => _damage += 10;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            foreach (var health in InfinitySpawn.Instans.Healths)
                health.Value -= Random.Range(10, 100) + _damage;
    }

    private void SpawnBossHandler(Health boss)
    {
        _damage += 10;
    }

    private void OnDestroy()
    {
        InfinitySpawn.Instans.OnBossSpawn -= (X) => _damage += 10;
    }
}
