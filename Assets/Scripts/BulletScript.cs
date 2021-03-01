using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript : MonoBehaviour
{
    public GameObject EnemyParticle;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
    	if(collision.gameObject.CompareTag("danger")){
            Sounds.PlayAudio("Hit");
            Instantiate(EnemyParticle, collision.gameObject.transform.position, 
                collision.gameObject.transform.rotation);
    		Destroy(collision.gameObject);
    		Destroy(gameObject);

            playermovm.score+=10;
    	}
    	else{
    		Destroy(gameObject, 2);
    	}
    
    }
}