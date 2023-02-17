using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrownAxeProjectile : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private float speed = 0.5f;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private int damage = 70; 

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    public void SetDirection(float directionX, float directionY)
    {
        direction = new Vector2(directionX, directionY);
        //direction = new Vector2(directionX, Vector2.up.y * 20f);
        if(directionX < 0 )
        {
            Vector2 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }

        //_rigidbody2D.AddForce(direction + Vector2.up * _rigidbody2D.velocity * speed);
    }

    private void Update()
    {
        bool isHit = false;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.13f);
        foreach (var item in hitColliders)
        {
            Enemy enemy = item.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                isHit = true;
                break;
            }
        }

        //if(isHit)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void FixedUpdate()
    {
        //_rigidbody2D.velocity += direction * speed ;

        _rigidbody2D.AddForce((direction) * speed, ForceMode2D.Force);
        speed -= Time.fixedDeltaTime;
        //_rigidbody2D.AddForce((direction) * speed, ForceMode2D.Impulse);
        //speed -= 0.05f * Time.deltaTime;
        //_rigidbody2D.isKinematic = false;
        //_rigidbody2D.AddForce();
        //(direction.x, direction.y * speed), ForceMode2D.Impulse);
    }


}
