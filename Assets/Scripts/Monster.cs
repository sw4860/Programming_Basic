using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Monster : MonoBehaviour
{

    private void Start()
    {
        /*int[] testArray = new int[10];

        for (int i = 0; i < testArray.Length; i++)
        {
            testArray[i] = i + 10;
            Debug.Log(testArray[i]);
        }*/

        /*
        List<int> testList = new();
        List<int> testList2 = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (int i = 0; i < 10; i++)
        {
            testList.Add(i);
        }

        Debug.Log(testList[4]);
        Debug.Log(testList2[4]);*/

    }
    void Update()
    {
        //transform.position += Vector3.right * 0.03f;
        //transform.position += Vector3.right * -0.03f;
        //transform.position += Vector3.up * 0.03f;
        //transform.Translate(Vector3.right * 0.03f);

        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))//(Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector3.forward * 0.03f);
        }
        if (Input.GetKey(KeyCode.A))//(Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector3.right * -0.03f);
        }
        if (Input.GetKey(KeyCode.S))//(Keyboard.current.sKey.isPressed)
        {
            transform.Translate(Vector3.forward * -0.03f);
        }
        if (Input.GetKey(KeyCode.D))//(Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector3.right * 0.03f);
        }
    }
}
