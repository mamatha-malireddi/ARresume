using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sounds : MonoBehaviour
{
	public static AudioSource adsrc;
	public static AudioClip hit, coin, jump, bullet;
    // Start is called before the first frame update
    void Start()
    {
        adsrc = GetComponent<AudioSource>();
        hit = Resources.Load<AudioClip>("Hit");
        coin = Resources.Load<AudioClip>("Coin");
        jump = Resources.Load<AudioClip>("Jump");
        bullet = Resources.Load<AudioClip>("Bullet");
    }
    public static void PlayAudio(string clip){
    	switch(clip){
    		case "Hit":
    			adsrc.PlayOneShot(hit);
    			break;
    		case "Coin":
    			adsrc.PlayOneShot(coin);
    			break;
    		case "Jump":
    			adsrc.PlayOneShot(jump);
    			break;
    		case "Bullet":
    			adsrc.PlayOneShot(bullet);
    			break;
    	}
    }
}
