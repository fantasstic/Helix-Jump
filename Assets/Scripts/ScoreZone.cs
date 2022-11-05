using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int _reward;
    public int Reward => _reward;

    public void OnTriggerEnter(Collider colission)
    {
        if (colission.TryGetComponent(out Ball ball))
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Scorezone");
        }
    }
}
