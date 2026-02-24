using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Start()
    {
        float numA = 5.5f;
        int numB = 10;
        // int sum = (int)numA + numB;
        float sum = numA + numB;
        Debug.Log("Hello, Salah! The sum of " + numA + " and " + numB + " is: " + sum);
    }
}
