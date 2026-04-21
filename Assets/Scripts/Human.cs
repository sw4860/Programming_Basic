using UnityEngine;

public class Human
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public void Walk()
    {

    }

    public void Eat()
    {

    }

    public void Sleep()
    {

    }

    public void Introduce()
    {
        Debug.Log($"안녕하세요 저는 {name}이고, {age}살 입니다.\n키는 {height}이고, 몸무게는 {weight}kg 입니다.");
    }
}
