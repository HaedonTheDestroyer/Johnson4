using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;



public class Beat : MonoBehaviour

{

    public float bpm;
    public float offset;
    public AudioSource audioSource;
    public AudioSource Boom;
    public ParticleSystem p1,p2,p3;
    public Intervals[] intervals;
    public int rx,ry,rz;
    public bool cube;
    GameObject manager;
    public int spawntime;
    public bool rando;
    GameManager gameManager;
    public Light l;
    public GameObject cubo;
    public GameObject bitch;
    public float spawnend;
    public int spawnfreq;
    void spawn()
    {
        GameObject [] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject x in enemy)
        {
            x.SetActive(true);
        }
    }
    public void random()
    {
        if (rando)
        {
            for (int i = 0; i < spawnfreq; i++)
            {
                Instantiate(bitch, new Vector3(Random.Range(-rx, rx), ry, Random.Range(-rz, rz)), new Quaternion());
            }
        }
    }
    public void randomon()
    {
        rando = true;
    }
    public void randomoff()
    {
        rando = false;
    }
    // Start is called before the first frame update

    void Start()
    {
        l=GameObject.Find("Directional Light").GetComponent<Light>();
        manager = GameObject.Find("Manager");
        gameManager = manager.GetComponent<GameManager>();
        Debug.Log(audioSource.clip.length);
        Invoke("explosion", audioSource.clip.length + 5);
        Invoke("boomer", audioSource.clip.length + 4);
        Invoke("spawn", spawntime);
        Invoke("randomon",spawntime);
        Invoke("randomoff",spawnend);

    }
    void explosion()
    {
        p1.Play();
        p2.Play();
        p3.Play();
        
        for(float i = 0; i < 3; i+=.5f) { 
        Invoke("lighter", i);
        }
        
        gameManager.Invoke("endGame", 3.5f);
    }
    void boomer()
    {
        Boom.Play();
    }
    void lighter()
    {
        l.intensity = 15;
        l.color=Color.yellow;
    }


    // Update is called once per frame

    void Update()
    {
        if (Time.timeSinceLevelLoad > spawnend)
        {
            randomoff();
        }
        foreach (Intervals interval in intervals)

        {

            float sampledTime = (audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm)))+offset;
            //Debug.Log(sampledTime);
            //Debug.Log(interval.lastInterval);
            interval.CheckForNewInterval(sampledTime);
            
        }
        
    }

}
[System.Serializable]
public class Intervals

{

    public float steps;

    public int lastInterval;
    
    public UnityEvent trigger;
    public UnityEvent trigger2;

    public float GetIntervalLength(float bpm)

    {

        return 60f / (bpm * steps);



    }

    public void CheckForNewInterval(float interval)

    {

        
        if (Mathf.FloorToInt(interval) != lastInterval)

        {
            //Debug.Log("shit went down");
            lastInterval = Mathf.FloorToInt(interval);
            //triggerer(); 
            //triggerer(); 
            trigger.Invoke();
            //Debug.Log("shit went down2");
            
            
           // Debug.Log("shit went down3");
        }

    }
    

}



