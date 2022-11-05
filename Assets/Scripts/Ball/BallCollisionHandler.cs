using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    private Ball _ball;
    private AudioManager _audioManager;

    private void Start()
    {
        _ball = GetComponent<Ball>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
        {
            _ball.AddScore(scoreZone.Reward);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string segmentName = collision.transform.GetComponent<MeshRenderer>().material.name;
        
        if (segmentName == "LoseSegment (Instance)")
        {
            GameManager.GameOver = true;
            _audioManager.Play("Lose");
        }
        else if(segmentName == "FinishPlatform (Instance)")
        {
            GameManager.LevelCompleted = true;
            _ball.AddMoney(100);
            _audioManager.Play("Finish");
        }
    }
}
