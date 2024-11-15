using UnityEngine;

public class HomingBullet : Bullet
{
    [SerializeField] private float _offsetScale;
    [SerializeField] private float _forceScale;

    protected override void FixedUpdate()
    {
        Rigidbody.AddForce(Duration * _forceScale * Time.deltaTime);
        Rigidbody.velocity = Vector3.zero;
    }
}
