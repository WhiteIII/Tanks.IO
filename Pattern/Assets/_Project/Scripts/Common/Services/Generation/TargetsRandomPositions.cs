using UnityEngine;

public sealed class TargetsRandomPositions
{
    private MeshRenderer _meshRenderer;
    private Vector2 _planeSize;
    private Vector3 _currentTargetPosition;
    
    public void Init(MeshRenderer planeMeshRenderer)
    {
        _meshRenderer = planeMeshRenderer;
        _planeSize = _meshRenderer.bounds.size;
        Debug.Log(_planeSize);
    }

    public void SetTarget(GameObject target)
    {
        _currentTargetPosition = GetRandomPostion();
        target.transform.position = _currentTargetPosition;
    }

    public void SetTargetOutOfCamera(GameObject target, Vector3 spawnPoint)
    {
        _currentTargetPosition = GetRandomPositionOnQuarter(spawnPoint);
        target.transform.position = _currentTargetPosition;
    }

    public void SetTargetCloseZero(GameObject target, Vector3 spawnPoint)
    {
        _currentTargetPosition = GetRandomPositionCloseZero(spawnPoint);
        target.transform.position = _currentTargetPosition;
    }

    private Vector3 GetRandomPostion()
    {
        float halfLengthOfPlane = _planeSize.x / 2;
        Vector3 randomPostion = new Vector3(Random.Range(-halfLengthOfPlane, halfLengthOfPlane), 0.5f, Random.Range(-halfLengthOfPlane, halfLengthOfPlane));

        return randomPostion;
    }

    private Vector3 GetRandomPositionOnQuarter(Vector3 spawnPoint) 
    {;
        float quartLengthOfPlane = _planeSize.x / 4;
        Vector3 randomPosition = new Vector3(Random.Range(-quartLengthOfPlane, quartLengthOfPlane), 0.5f, Random.Range(-quartLengthOfPlane, quartLengthOfPlane));

        if (spawnPoint.x < 0f && spawnPoint.z < 0f)
        {
            randomPosition += new Vector3(quartLengthOfPlane, 0f, quartLengthOfPlane);
        }
        else if (spawnPoint.x < 0f && spawnPoint.z > 0f)
        {
            randomPosition += new Vector3(quartLengthOfPlane, 0f, -quartLengthOfPlane);
        }
        else if (spawnPoint.x > 0f && spawnPoint.z < 0f)
        {
            randomPosition += new Vector3(-quartLengthOfPlane, 0f, quartLengthOfPlane);
        }
        else if (spawnPoint.x == 0 && spawnPoint.z == 0)
        {
            randomPosition = GetRandomPostion();
        }
        else
        {
            randomPosition += new Vector3(-quartLengthOfPlane, 0f, -quartLengthOfPlane);
        }

        return randomPosition;
    }

    private Vector3 GetRandomPositionCloseZero(Vector3 spawnPoint)
    {
        float halfLengthOfPlane = _planeSize.x / 2;
        float scale = 0.25f;
        Vector3 randomPostion = new Vector3(Random.Range(-halfLengthOfPlane * scale, halfLengthOfPlane * scale), 0.5f, Random.Range(-halfLengthOfPlane * scale, halfLengthOfPlane * scale));

        return randomPostion;
    }
}
