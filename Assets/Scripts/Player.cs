using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode _buttonShot;
    [SerializeField] private Pistol _pistol;

    private void Update()
    {
        if (Input.GetKeyDown(_buttonShot))
        {
            _pistol.Shot();
        }
    }
}
