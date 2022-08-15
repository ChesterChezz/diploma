using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpikes : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> spikes;
    Vector2 vel;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        vel.Set(0, -6f);
       // spikes.Add(GetComponentInChildren<Rigidbody2D>());
        y = 0.82f;
    }
    private void FixedUpdate()
    {
        ResetSpikes();
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var q in spikes)
            q.velocity = vel;
    }

    void ResetSpikes()
    {
        foreach (var q in spikes)
            if (q.position.y < -5.61)
            {
                q.position = new Vector2(q.position.x, y);

            }

    }
}
