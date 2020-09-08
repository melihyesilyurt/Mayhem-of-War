using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    private Transform location;
    public  GameObject character;

    
    void Start()
    {
        location = GetComponent<Transform>();
    }
    void Update()
    {
        location.localPosition = new Vector3(character.transform.position.x, character.transform.position.y, -10f);
    }
}
