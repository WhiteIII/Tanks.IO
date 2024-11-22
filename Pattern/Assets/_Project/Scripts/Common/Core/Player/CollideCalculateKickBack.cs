using UnityEngine;

namespace TanksIO.Common.Core.Player
{
    public class CollideCalculateKickBack : TargetMovement
    {
        [SerializeField] private TankBodyDamage _tankBodyDamage;
        [SerializeField] private float _forceScale;

        protected override void Awake()
        {
            _tankBodyDamage.Collide += CollidePush;
        }

        private void OnDestroy()
        {
            _tankBodyDamage.Collide -= CollidePush;
        }

        private void CollidePush()
        {
            Rigidbody.AddForce(-transform.position.normalized * _forceScale);
        }
    }
}