using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playermovm : MonoBehaviour
{
	float speed;
	Rigidbody2D rb;
	SpriteRenderer sr;
	public bool onground; 
	public Text Score_Text, highscore_Text;  
	public static int score, highscore;
	Animator anim;
	float health;
	public Image Health_Bg;
	public GameObject Bullet;
	public GameObject button_retry;        
	int bulletforce;            
	public GameObject Coinparticle, JumpParticle;
	bool left,right,up;
    // Start is called before the first frame update
    void Start()
    {
    	//Checking for highscore Starts
    	highscore = PlayerPrefs.GetInt("RecordScore");
    	highscore_Text.text = "HighScore :" + highscore;
    	//Checking for highscore Ends
        speed=15;
        bulletforce = 2500;
        health = 100;
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        score=0;
    }
    // Update is called once per frame
    void Update()
    {
       	anim.SetBool("walk", false);
	
    	if(right){
    		transform.Translate(new Vector2(0.2f*speed*Time.deltaTime,0));
        	sr.flipX=false;
        	bulletforce = 2500;
    	}
    	if(left)
    	{
    		transform.Translate(new Vector2(-0.2f*speed*Time.deltaTime,0));
        	sr.flipX=true;
        	bulletforce = -2500;
    	}
    	if(right && onground)
        {	
        	//Debug.Log("you there?");
        	anim.SetBool("walk", true);
        }
        if(left && onground)
         {
         	anim.SetBool("walk", true);
         }
        // if(!left)
        // {
        // 	anim.SetBool("walk", false);
        // }
        // if(!right)
        // {
        // 	anim.SetBool("walk", false);
        // }
        if(up && onground==true)
        {
        	anim.SetBool("jump", true);
        	Sounds.PlayAudio("Jump");
        	rb.AddForce(new Vector2(0,1200*speed*Time.deltaTime));
        	onground=false;
        }
        if(!up)
        {
        	anim.SetBool("jump", false);
        }


        if(Input.GetKey(KeyCode.RightArrow))
        {
        	transform.Translate(new Vector2(0.2f*speed*Time.deltaTime,0));
        	sr.flipX=false;
        	bulletforce = 2500;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
        	transform.Translate(new Vector2(-0.2f*speed*Time.deltaTime,0));
        	sr.flipX=true;
        	bulletforce = -2500;
        }
        if(Input.GetKey(KeyCode.RightArrow) && onground)
        {	
        	anim.SetBool("walk", true);
        }
        if(Input.GetKey(KeyCode.LeftArrow) && onground)
        {
        	anim.SetBool("walk", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
        	anim.SetBool("walk", false);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
        	anim.SetBool("walk", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && onground==true)
        {
        	anim.SetBool("jump", true);
        	Sounds.PlayAudio("Jump");
        	rb.AddForce(new Vector2(0,1200*speed*Time.deltaTime));
        	onground=false;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
        	anim.SetBool("jump", false);
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
        	//GameObject InstBullet = Instantiate(Bullet, transform.position, transform.rotation);
        	//InstBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletforce * speed * Time.deltaTime, 0));
        
        	if(sr.flipX==false)
        	{
        	Sounds.PlayAudio("Bullet");
        	GameObject InstBullet = Instantiate(Bullet, transform.position, transform.rotation);
        	InstBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletforce * 
        		speed * Time.deltaTime, 0));
            InstBullet.GetComponent<SpriteRenderer>().flipX=false;
            }
            else
            {
        		Sounds.PlayAudio("Bullet");
            	GameObject InstBullet = Instantiate(Bullet, transform.position, 
            		transform.rotation);
            	InstBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletforce * 
            		speed * Time.deltaTime, 0));
                InstBullet.GetComponent<SpriteRenderer>().flipX=true;  
            }
        }
        if(score>highscore){
    		highscore = score;	
    		highscore_Text.text = "Highscore :"+ highscore;
    		PlayerPrefs.SetInt("RecordScore", highscore);
    		Score_Text.text = "Score :" + score; 
    	}

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
    	if(col.gameObject.CompareTag("floor") || col.gameObject.CompareTag("tile"))
    	{
    		onground=true;
    	}
    	if(col.gameObject.CompareTag("coin"))
    	{
    		score++;
        	Sounds.PlayAudio("Coin");
        	
    		Destroy(col.gameObject);
    		Debug.Log("Score:"+score);
    		Score_Text.text = "Score :" + score; 
    	}
    	if(col.gameObject.CompareTag("danger"))
    	{

    		health-=50;
    		Health_Bg.fillAmount = health/100;
    		if(health==0)
    		{
    			Sounds.PlayAudio("Bullet");
    			anim.SetBool("dead", true);
    			StartCoroutine(gameover());

    		}
    		//Destroy(gameObject);
    		//Debug.Log("GameOver!!!");
    	}
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
    	if(collision.gameObject.CompareTag("Bullet"))
    	{
    		collision.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
    	}
    }   
    IEnumerator gameover()
    {
    	yield return new WaitForSeconds(3f); 
    	SceneManager.LoadScene("GameOver");
  
    }
    public void leftup()
    {
    	left=false;
    }
    public void leftdown()
    {
    	left=true;
    }
    public void rightup()
    {
    	right=false;
    }
    public void rightdown()
    {
    	right=true;
    }
    public void upup()
    {
    	up=false;
    }
    public void updown()
    {
    	up=true;
    }
}