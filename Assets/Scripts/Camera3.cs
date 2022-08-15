using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera3 : MonoBehaviour
{
    [SerializeField] Transform characterPosition;
    [SerializeField] Text count;
    [SerializeField] AudioSource backGroundSound;
    [SerializeField] GameObject next;


    // Start is called before the first frame update
    void Start()
    {
        backGroundSound.Play();

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(next.active == true)
        {
            Vector3 pos = new Vector3(transform.position.x,
            characterPosition.position.y + 150, -2941);
            transform.position = pos;
        }
        
       
    }
}
