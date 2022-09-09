using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;
    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    public void AttackIfPossible()
    {
        if (!_status.IsAttackable) return;

        _status.GoToAttackStateIfPossible();
    }

    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    public void OnHitAttack(Collider collider)
    {
        var targeMob = collider.GetComponent<MobStatus>();

        if (null == targeMob) return;

        targeMob.Damage(1);
    }

    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GotoNormalStatrIfPossible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
