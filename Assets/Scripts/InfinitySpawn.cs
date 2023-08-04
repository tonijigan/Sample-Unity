using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfinitySpawn : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    public HashSet<Health> Healths;

    private int _counter;

    public static InfinitySpawn Instans;

    public event UnityAction<Health> OnBossSpawn;

    private void Awake()
    {
        Instans = this;

        foreach (Health healths in GameObject.FindObjectsOfType<Health>())
        {
            healths.OnDeaded += ObjectDeadHandler;
            Healths.Add(healths);
        }
    }
  
    public void ObjectDeadHandler(Health healthDead)
    {
        _counter++;
        Healths.Remove(healthDead);
        GameObject newObject = new GameObject();
        Health health = newObject.AddComponent<Health>();
        health.OnDeaded += ObjectDeadHandler;
        Healths.Add(health);
        var spriteRenderer = newObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = _sprite;
        newObject.transform.position = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);

        if (_counter == 10)
        {
            spriteRenderer.color = Color.red;
            OnBossSpawn?.Invoke(health);
        }
    }
}
