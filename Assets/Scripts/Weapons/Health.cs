using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float health = 100.0f;
	public float maxHealth = 100.0f;
	public float regenerateSpeed = 0.0f;
	public bool invincible = false;
	public bool dead = false;
	
	
	private bool regenerating = false;
	private float lastDamageTime = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("On Col  Enter:"+collision.collider.name);
		if(collision.collider.tag == "bullet")
		{
			
			Destroy(collision.collider.gameObject);
			
			OnDamage(20,Vector3.zero);
			//Destroy(gameObject);		
		}
		
		
	}	
	
//	void OnTriggerEnter(Collider other)
//	{
//		Debug.Log("On trigger Enter");
//		
//		if(other.tag == "bullet")
//		{
//			Debug.Log("Hit !!");
//		}
//	}
	
	public void OnDamage(float amount, Vector3 fromDirection)
	{
		if(invincible) return;
		if(dead) return;
		if(amount <= 0) return;
		
		
		health -= amount;
		
		if(regenerateSpeed > 0.0f)
			enabled = true;
		
		lastDamageTime = Time.time;
		
		if(health <= 0)
		{
			health = 0;
			dead = true;
			enabled = false;
			Destroy(gameObject);
		}
	}
	
	void OnEnable()
	{
		StartCoroutine(Regenerate());
	}
	
	IEnumerator Regenerate()
	{
		if(regenerateSpeed > 0.0f)
		{			
			while(enabled)
			{
				if(Time.time > lastDamageTime + 3)
				{
					health += regenerateSpeed;
					
					yield return 0;
					
					if(health >= maxHealth)
					{
						health = maxHealth;
						enabled = false;
					}
				}
				yield return new WaitForSeconds(1.0f);
			}
		}
	}
}
