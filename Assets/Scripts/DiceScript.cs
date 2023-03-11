using DefaultNamespace;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private bool _rotationFinished;

    private Quaternion _previousRotation;

    // Start is called before the first frame update

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rotationFinished = false;
    }

    // Update is called once per frame

    void Update()
    {
        
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
            Debug.Log("Rotation finished");
            //_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            _previousRotation = rotation;
        }
    }
}