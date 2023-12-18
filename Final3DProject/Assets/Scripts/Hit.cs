using UnityEngine;

public class Hit : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    private GameObject soundplayer;
    public int soundnumber = 1;
    private PlayClips playclips;

    void Start()
    {    
        soundplayer = GameObject.FindWithTag("SoundPlayer");
        playclips = soundplayer.GetComponent<PlayClips>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "main_character")
        {
            Debug.Log("hit");
            Debug.Log(transform.position);
            Instantiate(explosionParticle, transform.position, transform.rotation);

                if (soundnumber == 1)
                    playclips.expl1start = true;
                else if (soundnumber == 2)
                    playclips.expl2start = true;
                else if (soundnumber == 3)
                    playclips.pickupstart = true;
                Destroy(gameObject, 0.05f);
            }
        }
    }
