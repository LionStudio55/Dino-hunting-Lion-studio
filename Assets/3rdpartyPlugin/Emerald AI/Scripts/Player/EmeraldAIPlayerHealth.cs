using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EmeraldAI.CharacterController;
using UnityEngine.UI;

namespace EmeraldAI.Example
{
    /// <summary>
    /// An example health script that the EmeraldAIPlayerDamage script calls.
    /// Various events can be created and used to cause damage to a 3rd party character controllers via the inspector.
    /// You can also edit the EmeraldAIPlayerDamage script directly and add custom functions.
    /// </summary>
    public class EmeraldAIPlayerHealth : MonoBehaviour
    {
        public int TotalHealth = 100;
        public int CurrentHealth = 100; [Space]
        public UnityEvent DamageEvent;
        public UnityEvent DeathEvent;
        public Image Healthbar;
        [HideInInspector]
        public int StartingHealth;
        int currhealth, totalhealth;
        public GameObject bloodSplatter;
        public AudioClip hitsound;
        public AudioSource audioSource;
        private void Start()
        {
            StartingHealth = CurrentHealth;
            
        }

        public void DamagePlayer (int DamageAmount)
        {
            CurrentHealth -= DamageAmount;
            DamageEvent.Invoke();

            //if (GetComponent<EmeraldAICharacterControllerTopDown>() != null)
            //{
            //    GetComponent<EmeraldAICharacterControllerTopDown>().DamagePlayer(DamageAmount);
            //}
            //if (Healthbar)
            //{

            //Healthbar.fillAmount = (CurrentHealth / StartingHealth);
            //}

                if (CurrentHealth <= 0)
            {
                PlayerDeath();
            }
        }
        public void ApplyDamage(float damageReceived)
        {
            if (this.gameObject.tag == "Player")
            {
                //audioSource.PlayOneShot(hitsound);
            }
           // HealthBar.transform.parent.gameObject.SetActive(true);
            Debug.Log("DamageCalled");
            //currentHealth -= damageReceived;
            audioSource.PlayOneShot(hitsound);
            if (Healthbar)
            {
                float current = (float)CurrentHealth;
                float total = (float)TotalHealth;
                Healthbar.fillAmount = (current / total);
                    //(current / total);
                print("check health");
            }
            StartCoroutine(Blood());
        }
            public void PlayerDeath ()
        {
            DeathEvent.Invoke();
        }
        IEnumerator Blood()
        {
            bloodSplatter.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            bloodSplatter.SetActive(false);

        }
    }
}
