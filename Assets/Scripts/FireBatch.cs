using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[System.Serializable]
public class Section
{
    public FlyingProjectile projectile;
    public float spawnTime;
    public Section(FlyingProjectile flp, float time)
    {
        projectile = flp;
        spawnTime = time;
    }
}

[System.Serializable]
public class Spawner
{
    public Section[] sections;
    public GameObject postition;
}

public class FireBatch : MonoBehaviour
{
    public Spawner[] spawners;
    public float duration;
    private float timer;

    private void Start()
    {
        timer = duration;

        for (int i = 0; i < spawners.Length; i++)
        {
            StartCoroutine(Spawn(spawners[i]));
        }
    }

    private void Update()
    {
        if(timer < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    IEnumerator Spawn(Spawner spawner)
    {
        for(int i = 0; i < spawner.sections.Length;i++)
        {
            yield return new WaitForSeconds(spawner.sections[i].spawnTime);
            Instantiate(spawner.sections[i].projectile, spawner.postition.transform.position, Quaternion.identity);
        }
    }
}


