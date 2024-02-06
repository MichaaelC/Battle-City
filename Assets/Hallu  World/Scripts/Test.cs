using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HelloWorld
{
    public class Test : MonoBehaviour
    {
        PlayerInput playerInput;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        }


        public void Move(Vector2 input)
        {
            Debug.Log(input);
        }

        public void Fire()
        {
            Debug.Log("asdf");
            
        }
    }
}
