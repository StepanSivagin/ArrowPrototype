using UnityEngine;

namespace ExampleTemplate
{
    public class CoefficientPoints
    {
        [SerializeField] private readonly float _coefficientPoints = 1;

        public float GetCoefficient()
        {
            return _coefficientPoints;
        }
    }
}