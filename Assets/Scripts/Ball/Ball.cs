using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    private int _score;
    private int _money;

    public static event UnityAction<int> ScoreChanged;
    public static event UnityAction<int> MoneyChanged;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSegment platformSegment))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }

    public void AddMoney(int prize)
    {
        _money += prize;
        MoneyChanged?.Invoke(_money);
    }
    
    public void AddScore(int reward)
    {
        _score += reward;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
 
    public void ChangeColor(Color newColor)
    {
        _meshRenderer.material.color = newColor;
    }
}
