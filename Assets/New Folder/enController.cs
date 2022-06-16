using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enController : MonoBehaviour
{
    bool _right = true;
    // Start is called before the first frame update
    Rigidbody2D m_rb = default;
    [SerializeField] float _speed = 1f;
    [SerializeField] GameObject m_effectPrefab = default;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        RLCheck();
        Move();
    }


    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Player")
        {
            // �G�t�F�N�g�ƂȂ�v���n�u���ݒ肳��Ă�����A����𐶐�����
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }

            // �������g��j������
            Destroy(this.gameObject);
        }
    }
    void RLCheck()
    {
        if (transform.position.x < 0)
        {
            _right = true;
        }
        else
        {
            _right = false;
        }
    }
    private void Move()
    {
        if (_right)
        {
            m_rb.velocity = Vector2.right * _speed;
        }
        else
        {
            m_rb.velocity = Vector2.left * _speed;
        }
    }
    public void StopMove()
    {
        m_rb.velocity = Vector2.zero;
    }
}