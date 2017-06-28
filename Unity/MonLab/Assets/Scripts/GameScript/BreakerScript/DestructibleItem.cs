using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item destructible
// Si touché , se détruit
// et appele les callback score et item generator si il y en a

public class DestructibleItem : MonoBehaviour
{
    public List<GameObject> lParticleTouched;


    private ItemGenerator itemGen;
    private ScoreItem scoreItem;

    public void Start()
    {
        itemGen = this.gameObject.GetComponent<ItemGenerator>();
        scoreItem = this.gameObject.GetComponent<ScoreItem>();
    }

    private void PlaySplosion()
    {
        int random = Random.Range(0, lParticleTouched.Count-1);
        if (lParticleTouched[random].GetComponent<ParticleSystem>() == null)
        {
            lParticleTouched.RemoveAt(random);
            PlaySplosion();
        }
        else
        {
            Object.Instantiate(lParticleTouched[random], this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (itemGen)
                itemGen.GenerateItem();
            if (scoreItem)
                scoreItem.AddScore();

            PlaySplosion();

            Destroy(this.gameObject);
        }
    }
}
