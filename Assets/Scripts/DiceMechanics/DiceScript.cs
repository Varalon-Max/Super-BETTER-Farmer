using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace DiceMechanics
{
    public class DiceScript : MonoBehaviour
    {
        [SerializeField] private GameObject side;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int sideId;

        private Rigidbody _rigidbody;

        private Vector3 _trueUp = Vector3.up;

        private bool _rotationFinished;

        private Quaternion _previousRotation;

        private Vector3[] _sideVectors;

        void Start()
        {
            InitSideVectors();
            _rigidbody = GetComponent<Rigidbody>();
            _rotationFinished = false;
        }

        private void InitSideVectors()
        {
            var vertexesPerSide = CalculateDodecahedronVertexes();
            _sideVectors = new Vector3[vertexesPerSide.Length];
            for (var i = 0; i < vertexesPerSide.Length; i++)
            {
                _sideVectors[i] = GetCenterVector(vertexesPerSide[i]);
            }
        }

        // Update is called once per frame


        private void Update()
        {
            // foreach (var sideVector in _sideVectors)
            // {
            //     Debug.DrawRay(transform.position, transform.TransformDirection(sideVector * 10), Color.green);
            //    // Debug.DrawLine(transform.position, GetCenterVector(sideVectors) * 10, Color.green);
            // }
            Debug.DrawRay(transform.position, transform.TransformDirection(_sideVectors[sideId] * 10), Color.green);
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

        private Vector3[][] CalculateDodecahedronVertexes()
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

        private Face GetTopFace()
        {
            var localUp = transform.up;
            Debug.Log(localUp);
            var angle = Vector3.Angle(_trueUp, localUp);
            Debug.Log(angle);

            Debug.Log(GetSideId());

            return Face.Fox;
        }

        private int GetSideId()
        {
            Vector3 localUp = transform.up;

            float minAngle = 360;
            int minAngleId = -1;

            float angle;
            for (int i = 0; i < _sideVectors.Length; i++)
            {
                if ((angle = Vector3.Angle(_sideVectors[i], localUp)) < minAngle)
                {
                    minAngle = angle;
                    minAngleId = i;
                }
            }

            return minAngleId;
        }
    }
}