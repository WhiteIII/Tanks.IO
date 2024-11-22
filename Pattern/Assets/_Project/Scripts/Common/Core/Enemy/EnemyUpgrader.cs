using UnityEngine;
using System;
using TanksIO.Common.Services;

namespace TanksIO.Common.Core.Enemy
{
    public class EnemyUpgrader
    {
        private EnemyStatsInRunTime _enemyStatsInRunTime;
        private EntityHealth _entityHealth;
        private IUpgradable _playerData;

        public EnemyUpgrader(EnemyStatsInRunTime enemyStatsInRunTime, EntityHealth entityHealth, IUpgradable playerData)
        {
            _enemyStatsInRunTime = enemyStatsInRunTime;
            _entityHealth = entityHealth;
            _playerData = playerData;

            _entityHealth.Reborn += UpgradeTankUnitlReborn;
        }

        private void UpgradeTankUnitlReborn()
        {
            _enemyStatsInRunTime.ResetStats();
            _enemyStatsInRunTime.ResetThePoints();
            _enemyStatsInRunTime.AddPoints(UnityEngine.Random.Range(_playerData.CountOfPoints, Mathf.RoundToInt(Convert.ToSingle(_playerData.CountOfPoints) * 1.25f)));
            Debug.Log("Reborn");
        }
    }
}