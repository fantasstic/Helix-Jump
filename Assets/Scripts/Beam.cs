using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    public void ChangeColor(Color newColor)
    {
        _meshRenderer.material.color = newColor;
    }
}
