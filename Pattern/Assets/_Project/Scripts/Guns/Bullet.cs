using System;
using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected int BulletHealh;
    
    protected int CurrentDamage;
    protected Rigidbody Rigidbody;
    protected ITank PlayerData;
    protected Bullet BulletSrtipt;
    protected GunsDataList GunData;
    protected float DamageScale;
    protected int MaxHealth;
    
    public Vector3 Duration { get; private set; }

    public virtual event Action<Bullet> BulletTouchedTheTarget;

    [Inject] private void Construct(GunsDataList gunsDataList)
    {
        GunData = gunsDataList;
    }

    private void Awake()
    {
        MaxHealth = BulletHealh;
        
        Rigidbody = GetComponent<Rigidbody>();
        BulletSrtipt = GetComponent<Bullet>();
    }

    protected virtual void FixedUpdate()
    {
        Rigidbody.MovePosition(transform.position + Duration * PlayerData.BulletSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {   
        if (other.TryGetComponent<IEntityHealthInteractional>(out IEntityHealthInteractional health))
        {
            CurrentDamage = Mathf.RoundToInt((float)PlayerData.Damage * DamageScale);

            health.TakeDamage(CurrentDamage, PlayerData);
            other.GetComponent<TargetMovement>().Push(Duration);
            transform.localScale = Vector3.one;
            BulletHealh = MaxHealth;
            BulletTouchedTheTarget?.Invoke(BulletSrtipt);
        }
    }

    public virtual void Init(Vector3 duration, float damageScale, float sizeScale, ITank tank)
    {
        Duration = duration;
        DamageScale = damageScale;
        PlayerData = tank;

        transform.localScale *= sizeScale;
        BulletHealh += PlayerData.BulletPenetration;

        StartCoroutine(KillTheBullet());
    }

    protected virtual IEnumerator KillTheBullet()
    {
        yield return new WaitForSeconds(GunData.CurrentGun.BulletTimeLife);
        transform.localScale = Vector3.one;
        BulletTouchedTheTarget?.Invoke(BulletSrtipt);
    }
}
