using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerSpawn : MonoBehaviour
{   

    public void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().enabled = true;
    }

}