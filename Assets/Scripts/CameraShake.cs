/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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