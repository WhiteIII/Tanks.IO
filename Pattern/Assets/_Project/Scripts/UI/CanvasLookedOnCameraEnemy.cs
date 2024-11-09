using UnityEngine;

public class CanvasLookedOnCameraEnemy : MonoBehaviour
{
    private Camera _camera;
    private bool _isPlaying = false;

    private void Update()
    {
        if (_camera == null)
        {
            return;
        }

        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.back, _camera.transform.rotation * Vector3.up);
    }

    public void Init(Camera camera)
    {
        _camera = camera;
    }

    private void InTheLens(bool isPlaying)
    {
        _isPlaying = isPlaying;
    }
}