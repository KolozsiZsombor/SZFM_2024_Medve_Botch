using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AutomaticDoor : MonoBehaviour
{
    public Vector2 endPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
    private Vector2 startPos;
    private float delay = 0.0f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            if (opening)
            {
                MoveDoor(endPos);
            }
            else
            {
                MoveDoor(startPos);
            }
        }
    }

    void MoveDoor(Vector2 goalPos)
    {
        float distance = Vector2.Distance(transform.position, goalPos);
        if (distance > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, goalPos, speed * (Time.deltaTime * 2));
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay > 0.5)
                {
                    opening = false;
                }
            }
            else
            {
                moving = false;
                opening = true;
            }
        }
    }

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}
