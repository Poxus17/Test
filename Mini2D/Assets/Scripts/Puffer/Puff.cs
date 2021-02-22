using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Puff : MonoBehaviour
{
    public Collider2D collider;
    bool puffed;

    // Start is called before the first frame update
    void Start()
    {
        puffed = false;
        PlayerDistanceSensor.OnTriggerStatus += PuffUp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PuffUp(bool status)
    {
        puffed = status;
        collider.enabled = status;

        GetComponent<Animator>().SetTrigger("Status change");

    }
}
