using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] private GameObject dice;

    [SerializeField] private Vector3 spawnCoordinates;
    [SerializeField] private float forceModifier;
    [SerializeField] private float torqueModifier;

    // Start is called before the first frame update
    private void Start()
    {
        RollDice();
        RollDice();
    }

    private void RollDice()
    {
        var diceObj = Instantiate(dice, spawnCoordinates + new Vector3(Random.value, Random.value, Random.value) , Quaternion.identity);
        var rigidbody = diceObj.GetComponent<Rigidbody>();
        
        rigidbody.AddTorque(new Vector3(Random.value, Random.value, Random.value) * torqueModifier, ForceMode.Impulse);
        rigidbody.AddForce(new Vector3(Random.value, 0, Random.value) * forceModifier, ForceMode.Impulse);
    }
}