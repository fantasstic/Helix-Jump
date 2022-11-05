using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _additionalScale;
    [SerializeField] private Beam _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platform;

    private float _startAndFinishAdditionalScale = 0.5f;
    public float BeamScaleY => GameManager.CurrentLevelSettings.LevelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        var beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
        beam.ChangeColor(GameManager.CurrentLevelSettings.BeamColor);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        var spawnPlatform = SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);
        spawnPlatform.ChangeColor(GameManager.CurrentLevelSettings.SpawnPlatformColor);

        for(int i = 0; i < GameManager.CurrentLevelSettings.LevelCount; i++)
        {
            var mainPlatform = SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
            mainPlatform.ChangeColor(GameManager.CurrentLevelSettings.MainPlatformColor1);
        }

        var finisgPlatform = SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
        finisgPlatform.ChangeColor(GameManager.CurrentLevelSettings.FinishPlatformColor);
    }

    private Platform SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        var createdPlatform = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
        return createdPlatform;

    }


}
