using UnityEngine;

namespace TanksIO.Common.Services
{
    public class RigidbodyFacroty
    {
        public void RigidbodyConfigure(Rigidbody rigidbody, float drag)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ
                | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
            rigidbody.drag = drag;
        }
    }
}