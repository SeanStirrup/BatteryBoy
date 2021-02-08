using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    private float trackSpeed = 10;



    // Track target
    void LateUpdate()
    {

        float x = IncrementTowards(transform.position.x, target.transform.position.x, trackSpeed);
        float y = IncrementTowards(transform.position.y, target.transform.position.y, trackSpeed);
        transform.position = new Vector3(x, y, transform.position.z);

    }

    // Increase n towards target by speed
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n
        }
    }
}
