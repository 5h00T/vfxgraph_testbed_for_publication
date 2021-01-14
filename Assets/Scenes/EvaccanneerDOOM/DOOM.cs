using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOM : MonoBehaviour
{
    [SerializeField]
    ParentBullet parentBullet;

    [GradientUsage(true)]
    public Gradient color1;
    [GradientUsage(true)]
    public Gradient color2;
    int count = 0;
    public float speed = 0.01f;

    private float xAngle1 = 0;
    private float yAngle1 = 0;
    private float zAngle1 = 0;
    private float xAngle2 = 0;
    private float yAngle2 = 0;
    private float zAngle2 = 0;
    private Vector3 initialChildAngle;

    void Start()
    {
        Application.targetFrameRate = 60;

        initialChildAngle = new Vector3(Random.Range(0, 360),
                                            Random.Range(0, 360),
                                            Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        count++;

        this.transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time/1) * 0.02f + transform.position.y, transform.position.z);

        if (count % 12 == 0)
        {
            xAngle1 += 7;
            yAngle1 += 8;
            zAngle1 += 9;

            ParentBullet obj = Instantiate(parentBullet, transform.position, Quaternion.Euler(xAngle1, yAngle1, zAngle1));
            obj.color = color1;
            obj.initialChildAngle = initialChildAngle;

            xAngle2 -= 5;
            yAngle2 -= 6;
            zAngle2 -= 7;

            obj = Instantiate(parentBullet, transform.position, Quaternion.Euler(xAngle2, yAngle2, zAngle2));
            obj.color = color2;
            obj.initialChildAngle = initialChildAngle;

            initialChildAngle.x += 3;
            initialChildAngle.y += 3;
            initialChildAngle.z += 3;
        }

        // transform.position += transform.forward * speed;
    }
}
