using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHallucination : MonoBehaviour
{
	public float startingHallucination = 0f;
	public float currentHallucination;
	//public Slider healthSlider;
	public Image hallucinationEffect;
	public AudioClip deathClip;
	//public float flashSpeed = 5f;
	//public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private const float coef = 10f;
	
	Animator anim;
	AudioSource playerAudio;
	FirstPersonController playerController;
	//PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	Color hallucinationEffectColor;
	
	
	void Awake()
	{
		//anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		playerController = GetComponent<FirstPersonController>();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHallucination = startingHallucination;
		hallucinationEffectColor = hallucinationEffect.color;
	}
	
	
	void Update()
	{

		currentHallucination += coef * Time.deltaTime;
		hallucinationEffectColor.a += 0.0008f;
		hallucinationEffect.color = hallucinationEffectColor;


		//playerAudio.Play();
		
		if (currentHallucination >= 100 && !isDead)
		{
			Death();
		}
		//if (Input.GetKeyDown("space"))
		//{

			//TakeDamage(10);
		//	hallucinationEffectColor.a += 0.08f;
			//hallucinationEffect.color = hallucinationEffectColor;
		//}
		
		//if (damaged)
		//{
		//	hallucinationEffect.color = flashColour;
		//}
		//else
		//{
		//damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		//}
		//damaged = false;
	}
	
	
	void Death()
	{
		isDead = true;
		
		//playerShooting.DisableEffects ();
		
		playerAudio.clip = deathClip;
		playerAudio.Play();
		
		playerController.Die();
		//playerShooting.enabled = false;
	}
	
	
	//public void RestartLevel()
	//{
	//	Application.LoadLevel(Application.loadedLevel);
	//}
}

/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHallucination : MonoBehaviour
{
	public int startingHallucination = 0;
	public int currentHallucination;
	//public Slider healthSlider;
	public Image hallucinationEffect;
	public AudioClip deathClip;
	//public float flashSpeed = 5f;
	//public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private const float coef = 0.2f;
	
	Animator anim;
	AudioSource playerAudio;
	FirstPersonController playerController;
	//PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	Color hallucinationEffectColor;
	
	
	void Awake()
	{
		//anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		playerController = GetComponent<FirstPersonController>();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHallucination = startingHallucination;
		hallucinationEffectColor = hallucinationEffect.color;
	}
	
	
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			
			TakeDamage(10);
			hallucinationEffectColor.a += 0.08f;
			hallucinationEffect.color = hallucinationEffectColor;
		}
		
		//if (damaged)
		//{
		//	hallucinationEffect.color = flashColour;
		//}
		//else
		//{
		//damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		//}
		//damaged = false;
	}
	
	
	public void TakeDamage(int amount)
	{
		//damaged = true;
		
		currentHallucination += amount;
		
		//healthSlider.value = currentHealth;
		
		playerAudio.Play();
		
		if (currentHallucination >= 100 && !isDead)
		{
			Death();
		}
	}
	
	
	void Death()
	{
		isDead = true;
		
		//playerShooting.DisableEffects ();
		
		playerAudio.clip = deathClip;
		playerAudio.Play();
		
		playerController.Die();
		//playerShooting.enabled = false;
	}
	
	
	//public void RestartLevel()
	//{
	//	Application.LoadLevel(Application.loadedLevel);
	//}
}
*/