using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HelloWorld
{
    public class InputTest : MonoBehaviour
    {
        Test player;

        private void Start()
        {
            player = FindObjectOfType<Test>();
        }

        private void OnMove(InputValue value)
        {
            player.Move(value.Get<Vector2>());
        }

        private void OnFire()
        {
            player.Fire();
        }
    }
}
