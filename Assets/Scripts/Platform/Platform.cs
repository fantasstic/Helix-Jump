using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    [SerializeField] private MeshRenderer[] _spawnMeshRenderer;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }

    public void ChangeColor(Color newColor)
    {
        for(int i = 0; i < _spawnMeshRenderer.Length; i++)
        {
            _spawnMeshRenderer[i].material.color = newColor;
        }
    }
}
