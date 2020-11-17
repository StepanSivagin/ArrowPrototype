using System;
using Model.Enemy;
using UnityEditor;
using UnityEngine;

namespace ExampleTemplate
{
    public sealed class BoneScore : MonoBehaviour
    {
        [SerializeField] private float _baseScore = 100f;

        private EnemyBehaviour _enemyBehaviour;

        private void Start()
        {
            _enemyBehaviour = transform.root.GetComponent<EnemyBehaviour>();
        }


        private void OnCollisionEnter(Collision other)
        {
            var hitObject = other.transform.GetComponent<CoefficientPoints>();
            if (hitObject == null) return;
            _enemyBehaviour.AddScore(_baseScore);
        }
    }
}