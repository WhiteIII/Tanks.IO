using System;

namespace TanksIO.Common.Services
{
    public interface IEntityHealthInteractional
    {
        public event Action<Health> Death;

        public void TakeDamage(int Damage, ITankUpradable tankUpradable);
    }
}