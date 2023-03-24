using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace DiceMechanics
{
    public class DiceScript : MonoBehaviour
    {
        private int _sideId;

        private Rigidbody _rigidbody;
        
        private bool _rotationFinished;

        private Quaternion _previousRotation;

        private Vector3[] _sideVectors;

        private void Awake()
        {
            InitSideVectors();
        }

        private void Start()
        {
            
            _rigidbody = GetComponent<Rigidbody>();
            _rotationFinished = false;
        }

        private void InitSideVectors()
        {
            var vertexesPerSide = CalculateDodecahedronVertexesPerSide();
            _sideVectors = new Vector3[vertexesPerSide.Length];
            for (var i = 0; i < vertexesPerSide.Length; i++)
            {
                _sideVectors[i] = GetCenterVector(vertexesPerSide[i]);
            }
        }

        private void Update()
        {
            // Draws ray from center of the dice to the center of current side
            Debug.DrawRay(transform.position, transform.TransformDirection(_sideVectors[_sideId] * 10), Color.green);
        }

        private Vector3 GetCenterVector(Vector3[] vertexes)
        {
            Vector3 center = Vector3.zero;
            foreach (var vertex in vertexes)
            {
                center += Vector3.Normalize(vertex);
            }

            center /= vertexes.Length;
            return center;
        }

        private void FixedUpdate()
        {
            if (_rotationFinished)
            {
                return;
            }
        
            float speed = _rigidbody.velocity.magnitude;
            var rotation = _rigidbody.rotation;
        
            if (speed < MathHelper.SpeedDelta && Quaternion.Angle(_previousRotation, rotation) < MathHelper.AngleDelta)
            {
                _rotationFinished = true;
                //Debug.Log("Rotation finished");
        
                //Debug.Log(localUp);
                Debug.Log(GetSideId());
                //_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                _previousRotation = rotation;
            }
        }

        private int GetSideId()
        {
            Vector3 localUp = Vector3.up;

            float minAngle = 360;
            int minAngleId = -1;

            for (int i = 0; i < _sideVectors.Length; i++)
            {
                float angle;
                if ((angle = Vector3.Angle(transform.TransformDirection(_sideVectors[i]), (localUp))) < minAngle)
                {
                    minAngle = angle;
                    minAngleId = i;
                }
            }

            _sideId = minAngleId;
            return minAngleId;
        }

        private static Vector3[][] CalculateDodecahedronVertexesPerSide()
        {
            var fDouble = (1 + Math.Sqrt(5)) / 2;
            var gDouble = 1 / fDouble;

            var f = (float)fDouble;
            var g = (float)gDouble;

            // Hardcoded vertexes
            // https://en.wikipedia.org/wiki/Regular_dodecahedron
            var vertexes = new List<Vector3>
            {
                new(1, 1, 1),
                new(1, 1, -1),
                new(1, -1, 1),
                new(1, -1, -1),
                new(-1, 1, 1),
                new(-1, 1, -1),
                new(-1, -1, 1),
                new(-1, -1, -1),
                new(0, f, g),
                new(0, f, -g),
                new(0, -f, g),
                new(0, -f, -g),
                new(g, 0, f),
                new(g, 0, -f),
                new(-g, 0, f),
                new(-g, 0, -f),
                new(f, g, 0),
                new(f, -g, 0),
                new(-f, g, 0),
                new(-f, -g, 0)
            };

            // Hardcoded vertexes per side

            var vertexesPerSide = new Vector3[12][];
            vertexesPerSide[0] = new[] { vertexes[0], vertexes[1], vertexes[8], vertexes[9], vertexes[16] };
            vertexesPerSide[1] = new[] { vertexes[0], vertexes[2], vertexes[12], vertexes[16], vertexes[17] };
            vertexesPerSide[2] = new[] { vertexes[0], vertexes[4], vertexes[8], vertexes[12], vertexes[14] };
            vertexesPerSide[3] = new[] { vertexes[1], vertexes[3], vertexes[13], vertexes[16], vertexes[17] };
            vertexesPerSide[4] = new[] { vertexes[1], vertexes[5], vertexes[9], vertexes[13], vertexes[15] };
            vertexesPerSide[5] = new[] { vertexes[2], vertexes[3], vertexes[10], vertexes[11], vertexes[17] };
            vertexesPerSide[6] = new[] { vertexes[2], vertexes[6], vertexes[12], vertexes[10], vertexes[14] };
            vertexesPerSide[7] = new[] { vertexes[3], vertexes[7], vertexes[11], vertexes[13], vertexes[15] };
            vertexesPerSide[8] = new[] { vertexes[4], vertexes[6], vertexes[18], vertexes[19], vertexes[14] };
            vertexesPerSide[9] = new[] { vertexes[4], vertexes[5], vertexes[8], vertexes[9], vertexes[18] };
            vertexesPerSide[10] = new[] { vertexes[5], vertexes[7], vertexes[15], vertexes[19], vertexes[18] };
            vertexesPerSide[11] = new[] { vertexes[6], vertexes[7], vertexes[10], vertexes[11], vertexes[19] };

            return vertexesPerSide;
        }
    }
}