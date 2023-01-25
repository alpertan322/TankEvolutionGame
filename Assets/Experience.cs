using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private ProgressBar bar;
   [SerializeField] private ParticleSystem ps;
   [SerializeField] private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        bar = FindObjectOfType<ProgressBar>();
        ps = gameObject.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayParticle()
    {
        ps.transform.position = playerPos.position;
        ps.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("sdf123");
        if (other.gameObject.tag == "Player")
        {
            Collect();
        } 
    }

    private void Collect()
    {
        bar.IncreaseSlider();
        gameObject.SetActive(false);
    }
}