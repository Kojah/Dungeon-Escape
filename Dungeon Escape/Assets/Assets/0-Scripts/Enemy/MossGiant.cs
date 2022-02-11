using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    [SerializeField] private Vector3 currentTarget = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
