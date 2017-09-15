using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody
    {
        get { return _rigidbody; }
    }

	// Use this for initialization
	void Start ()
    {
        _moveSpeed = 5.0f;
        _rigidbody = GetComponent<Rigidbody2D>();
	}

    private void Move(float dx, float dy)
    {
        Rigidbody.velocity = new Vector2(dx * MoveSpeed, dy * MoveSpeed);
    }

    // Update is called once per frame
    void Update ()
    {
        float x = Input.GetAxis(HORIZONTAL);
        float y = Input.GetAxis(VERTICAL);

        Move(x, y);
	}
}
