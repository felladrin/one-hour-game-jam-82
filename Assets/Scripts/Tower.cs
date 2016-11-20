using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Team;
    public GameObject SoldierPrefab;

    private void Start ()
	{
	    gameObject.tag = "TowerFromTeam" + Team;
	    InvokeRepeating("instantiateSolder", 3, 3);
	}

    private void instantiateSolder()
    {
        var soldier = Instantiate(SoldierPrefab, transform.position, transform.rotation, transform) as GameObject;

        if (soldier == null) return;

        soldier.GetComponent<Soldier>().Team = Team;
        soldier.GetComponent<Soldier>().IsAttacking = Random.value > 0.5;
        soldier.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        soldier.tag = "SoldierFromTeam" + Team;
    }
}
