using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController5 : MonoBehaviour
{
    [SerializeField] private Transform characterPosition;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(characterPosition.position.x,
          characterPosition.position.y + 5, -10);
        cam.transform.position = pos;
    }
}
