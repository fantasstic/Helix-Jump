using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _jumpEffect;

    private Rigidbody _rigidbody;
    private AudioManager _audioManager;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            var hitPlane = Instantiate(_jumpEffect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
            Destroy(hitPlane, 1f);
            _audioManager.Play("Ball");
        }
            
    }
}
