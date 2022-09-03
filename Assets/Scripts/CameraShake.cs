
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public float shakeDecayStart = 0.002f;
    public float shakeIntensityStart = 0.03f;

    private float _shakeDecay;
    private float _shakeIntensity;

    private Vector3 _originPosition;
    private Quaternion _originRotation;
    private bool _shaking;
    private Transform _transformAtOrigin;

    private void OnEnable()
    {
        _transformAtOrigin = transform;
    }

    private void Update()
    {
        if (!_shaking)
            return;
        if (_shakeIntensity > 0f)
        {
            _transformAtOrigin.localPosition = _originPosition + Random.insideUnitSphere * _shakeIntensity;
            _transformAtOrigin.localRotation = new Quaternion(
                _originRotation.x + Random.Range(-_shakeIntensity, _shakeIntensity) * .2f,
                _originRotation.y + Random.Range(-_shakeIntensity, _shakeIntensity) * .2f,
                _originRotation.z + Random.Range(-_shakeIntensity, _shakeIntensity) * .2f,
                _originRotation.w + Random.Range(-_shakeIntensity, _shakeIntensity) * .2f);
            _shakeIntensity -= _shakeDecay;
        }
        else
        {
            _shaking = false;
            _transformAtOrigin.localPosition = _originPosition;
            _transformAtOrigin.localRotation = _originRotation;
        }
    }

    public void Shake()
    {
        if (!_shaking)
        {
            _originPosition = _transformAtOrigin.localPosition;
            _originRotation = _transformAtOrigin.localRotation;
        }
        _shaking = true;
        _shakeDecay = shakeDecayStart;
        _shakeIntensity = shakeIntensityStart;
    }

}