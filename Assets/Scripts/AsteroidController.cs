using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class AsteroidController : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float _speed = 30.0f;
        [SerializeField] private float _maxLifeTime = 30.0f;         //
        public float _asteroidSize = 1.0f;
        public float _minSize = 1.0f;
        public float _maxSize = 2.5f;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rb;
        private Animator anim;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        void Start()
        {
            _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length - 1)];
            transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
            transform.localScale = Vector3.one * _asteroidSize;
            _rb.mass = _asteroidSize;
        }


        public void SetTrajectory(Vector2 direction)
        {
            _rb.AddForce(direction * _speed);
            Destroy(gameObject, _maxLifeTime);                    //
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            anim.SetTrigger("Crashed");
           FindObjectOfType<GameManager>().AsteroidDestroyed(this);
        if (collision.gameObject.tag == "Bullet")
            {
                if ((_asteroidSize * 0.5) >= _minSize)
                {
                    CreateSplit();
                    CreateSplit();
                }
                Destroy(gameObject, 1.1f);
            }
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NLO")
            {
                Destroy(gameObject, 1.1f);
            }
        }

        public void CreateSplit()
        {
            Vector2 pos = transform.position;
            pos += Random.insideUnitCircle * 0.5f;

            AsteroidController half = Instantiate(this, pos, transform.rotation);
            half._asteroidSize = _asteroidSize * 0.5f;
            half.SetTrajectory(Random.insideUnitCircle.normalized * _speed);
        }
    }

