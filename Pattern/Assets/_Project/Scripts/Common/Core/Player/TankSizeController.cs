using UnityEngine;
using Zenject;

public class TankSizeController : MonoBehaviour
{
    private IUpgradable _playerData;

    [Inject] private void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Awake()
    {
        _playerData.LevelChange += ChangeSize;
    }

    private void OnDestroy()
    {
        _playerData.LevelChange -= ChangeSize;
    }

    private void ChangeSize()
    {
        transform.localScale *= 1.001f;
        transform.position += new Vector3(0f, 0.001f, 0f);
    }
}
