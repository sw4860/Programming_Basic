using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] int num1 = 10;
    [SerializeField] int num2 = 20;

    void Start()
    {
        Debug.Log($"Plus: {Plus(num1, num2)}");
        Debug.Log($"Plus1: {Calculate(num1, num2, "+")}");
        Debug.Log($"Minus: {Minus(num1, num2)}");
        Debug.Log($"Minus1: {Calculate(num1, num2, "-")}");
        Debug.Log($"Divide: {Divide(num1, num2)}");
        Debug.Log($"Multiply: {Multiply(num1, num2)}");
        Debug.Log($"GetBig: {GetBig(num1, num2)}");
    }

    int Plus(int x, int y) => x + y;
    int Minus(int x, int y) => x - y;
    int Multiply(int x, int y) => x * y;
    int Divide(int x, int y) => x / y;
    int PlusMinus(int x, int y, bool isPlus)
    {
        if (isPlus)
        {
            return x + y;
        }
        else return x - y;
    }
    int Calculate(int x, int y, string z)
    {
        if (z == "+") return x + y;
        else if (z == "-") return x - y;
        else if (z == "x") return x * y;
        else if (z == "/") return x / y;
        else return 0;
    }

    int GetBig(int x, int y) => x > y ? x : y;
}
