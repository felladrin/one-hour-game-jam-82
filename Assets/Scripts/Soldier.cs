using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Soldier : MonoBehaviour
{
    public bool IsAttacking; // If not, it's definding.
    public int Team;
    public float speed;

    [SerializeField] private GameObject target;
    [SerializeField] private float timeout;

    private void Update()
    {
        if (target == null)
        {
            var tagBPrefix = IsAttacking ? "TowerFromTeam" : "SoldierFromTeam";

            var targets = GameObject.FindGameObjectsWithTag(tagBPrefix + GetRandomEnemyTeamNumber());

            var randomRange = Random.Range(0, targets.Length);

            if (targets.Length > randomRange)
            {
                target = targets[randomRange];
            }
        }
        else
        {
            if (Math.Abs(target.transform.position.magnitude - transform.position.magnitude) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                    target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if (timeout > 0)
                {
                    timeout -= Time.deltaTime;
                }
                else
                {
                    target.GetComponent<HP>().ApplyDamage();
                    ResetTimeout();
                }
            }
        }
    }

    private void ResetTimeout()
    {
        timeout = 1;
    }

    private void OnMouseDown()
    {
        IsAttacking = !IsAttacking;
        target = null;
    }

    private int GetRandomEnemyTeamNumber()
    {
        int enemyTeam;
        do
        {
            enemyTeam = Random.Range(1, 5);
        } while (enemyTeam == Team);
        return enemyTeam;
    }
}