using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterfollower : MonoBehaviour
{
    private Transform location;
    public GameObject character;
    void Start()
    {
        location = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        location.localPosition = new Vector3(character.transform.position.x, character.transform.position.y, -10f);
    }
}
