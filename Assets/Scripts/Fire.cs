using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public List<ParticleCollisionEvent> collisionEvents;
    ParticleSystem fire;

    // Use this for initialization
    void Start () {
        fire = this.GetComponent<ParticleSystem>();
        fire.Play();
    }
    /*void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = fire.GetCollisionEvents(other, collisionEvents);
        print(other.name);
        print("Number of Collisions: " + numCollisionEvents);
        int i = 0;
        while (i < numCollisionEvents + 1)
        {
            print(other.tag);
            if (other.tag == "Fire")
            {
                other.SetActive(false);
            }
            i++;
        }
    }*/
    public void Extinguish()
    {
        //ParticleSystem fire = this.GetComponent<ParticleSystem>();
        fire.Stop();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
