using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public MeshCollider glacier;
    public GameObject ice;
    public AudioSource hammerHit;
    public Transform iceSpawnPoint;
    private int timesHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //times hit is for when the hammer spawns in the world and we dont want to immediately spawn ice
        timesHit++;
        if (other.gameObject.tag.ToString() == "Glacier" && timesHit > 2)
        {
            SpawnIce();
            hammerHit.Play();
            

        }
    }

    private void SpawnIce()
    {

        System.Random rnd = new System.Random();
        GameObject toSpawn = ice;
        var force = 45;
        if (Random.value > .5)
        {
            
            var ice = Instantiate(toSpawn, iceSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = ice.GetComponent<Rigidbody>();
            rb.AddForce(rnd.Next(-force, force), rnd.Next(0, force), rnd.Next(-force, force));
        }
        
    }
}
