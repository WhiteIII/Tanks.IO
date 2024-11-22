using TanksIO.Common.Core.Guns;
using UnityEngine;

namespace TanksIO.Common.Core.Player
{
    public class GunCalculateKickback
    {
        private Rigidbody _rigidbody;
        private IDiractionOfShot _gun;

        public GunCalculateKickback(Rigidbody rigidbody, Gun gun)
        {
            _rigidbody = rigidbody;
            _gun = gun;
        }

        public void GetKickback()
        {
            for (int i = 0; i < _gun.Durations.Count; i++)
            {
                _rigidbody.AddForce(-_gun.Durations[i] * 52f * _gun.KickBackScale[i]);
            }
        }

        public void SetRigidBody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
    }
}