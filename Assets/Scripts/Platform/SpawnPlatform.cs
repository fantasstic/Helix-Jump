using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    /*[SerializeField] private MeshRenderer _meshRenderer;*/

    private void Awake()
    {
        var ball = Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
        ball.ChangeColor(GameManager.CurrentLevelSettings.BallColor);
    }

    /*public void ChangeColor(Color newColor)
    {
        _meshRenderer.material.color = newColor;
    }*/
}
