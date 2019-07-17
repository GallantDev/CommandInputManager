using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Unit : MonoBehaviour {
    [SerializeField] protected float moveSpeed = 0.0f;
    [SerializeField] protected float jumpPower = 0.0f;
    protected bool isInAir = false;
    protected Rigidbody2D rb = null;

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float JumpPower { get { return jumpPower; } set { jumpPower = value; } }
    public Rigidbody2D Rb { get { return rb; } set { rb = value; } }

    public virtual void Awake() {

    }

	public virtual void Start () {
        Init();
	}
	
	public virtual void Update () {
		
	}

    public virtual void FixedUpdate() {

    }

    public virtual void Init() {
        GameManager.Instance.AllUnits.Add(this);
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Move(Vector3 direction) {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public virtual void Jump() {
        if (!isInAir) {
            rb.AddForce(Vector3.up * jumpPower);
            isInAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision Occurred!");
        if (other.gameObject.tag == "Ground") {
            isInAir = false;
        }
    }
}