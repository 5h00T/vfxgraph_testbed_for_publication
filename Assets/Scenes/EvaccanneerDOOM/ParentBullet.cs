using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParentBullet : MonoBehaviour
{
    [SerializeField]
    ChildBullet childBullet;

    int count = 0;
    public float speed = 0.01f;
    public float lifeTime;
    private float age;
    public Gradient color;
    private VisualEffect visualEffect;
    public Vector3 initialChildAngle;

    void Start()
    {
        visualEffect = GetComponent<VisualEffect>();

        visualEffect.SetGradient("BulletColor", color);
        visualEffect.SetFloat("LifeTime", lifeTime);

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        count++;

        if (count % 8 == 0)
        {
            ChildBullet obj = Instantiate(childBullet, transform.position, Quaternion.Euler(initialChildAngle));
            obj.color = color;

            initialChildAngle.x += 3;
            initialChildAngle.y += 3;
            initialChildAngle.z += 3;
        }

        transform.position += transform.forward * speed;

        age += Time.deltaTime;
    }
}
