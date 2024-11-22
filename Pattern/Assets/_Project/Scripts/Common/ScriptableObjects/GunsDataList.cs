using UnityEngine;

namespace TanksIO.Common.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game", menuName = "Game/GunsList")]
    public class GunsDataList : ScriptableObject
    {
        [field: SerializeField] public GunData[] GunDatas { get; private set; }

        public GunData CurrentGun { get; private set; }

        public void ChangeCurrentGun(GunData gunData)
        {
            CurrentGun = gunData;
        }
    }
}