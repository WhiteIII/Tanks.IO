using UnityEngine;
using Zenject;

public class UpgradeOnClick : MonoBehaviour
{
    [SerializeField] private int _points;
    [Inject] private PlayerData _playerData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerData.AddPoints(_points);
        }
    }
}
