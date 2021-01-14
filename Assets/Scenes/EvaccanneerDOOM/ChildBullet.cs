using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChildBullet : MonoBehaviour
{
    public float baseSpeed = 1;
    private Rigidbody rigidbody;
    public AnimationCurve speedCurve;
    public Vector3 direction;
    public float lifeTime;
    private float age;
    public Gradient color;
    private VisualEffect visualEffect;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        visualEffect = GetComponent<VisualEffect>();

        visualEffect.SetGradient("BulletColor", color);
        visualEffect.SetFloat("LifeTime", lifeTime);

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        age += Time.deltaTime;

        transform.position += transform.forward * baseSpeed * speedCurve.Evaluate(age / lifeTime); // new Vector3(xSpeed, ySpeed, zSpeed);
    }

    private void FixedUpdate()
    {
        
    }
}
