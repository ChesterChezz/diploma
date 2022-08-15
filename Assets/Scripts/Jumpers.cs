using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpers : MonoBehaviour
{
    [SerializeField] private LayerMask heroMask;
    [SerializeField] private Animator animJumper;
    private Time timer;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    //private void CheckPoint()
    //{
    //    Collider2D[] collider = Physics2D.OverlapCircleAll(dot.position, 0.2f, heroMask);
    //    if (collider.Length > 0)
    //    {
    //       animJumper.enabled = true;
    //      // animJumper.Play("Jumper");
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
      //  CheckPoint();
    }

}
