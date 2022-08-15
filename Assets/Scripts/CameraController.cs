using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform characterPosition;
    [SerializeField] AudioSource backGroundSound;
    // Start is called before the first frame update
    void Start()
    {
        backGroundSound.Play();
    }
    private void DefaultCamera()
    {
        Vector3 pos = new Vector3(characterPosition.position.x,
           characterPosition.position.y + 5, -10);
        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        DefaultCamera();
    }
}
