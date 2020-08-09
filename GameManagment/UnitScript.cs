using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public IntVector2 cellIndex;
    public GridManager manager;

    public enum UnitStatus { Idle, ShowingRange};
    public UnitStatus status = UnitStatus.Idle;

    public ParticleSystem hitParticle;
    int health = 5;
    int attack = 2;
    public int team;

    public int range = 5;

    public void LeftClick()
    {
        switch (status)
        {
            case UnitStatus.Idle:
                manager.ShowUnitRange(this);
                status = UnitStatus.ShowingRange;
                break;
            case UnitStatus.ShowingRange:
                manager.RemoveAllUnitRanges();
                break;
        }
    }

    public void ProcessInteraction(UnitScript unit)
    {
        if (team != unit.team)
        {
            unit.TakeAttack(this);
        }
        manager.RemoveAllUnitRanges();
        if (team == unit.team)
        {
            unit.LeftClick();
        }
    }

    public void TakeAttack(UnitScript attacker)
    {

        ParticleSystem ob = Instantiate(hitParticle, transform.position, transform.rotation);
        ob.transform.LookAt(attacker.transform);
        health -= attacker.attack;
        if (health <= 0) { Destroy(gameObject); }
    }

    public void SetIdle() { status = UnitStatus.Idle; }
}
