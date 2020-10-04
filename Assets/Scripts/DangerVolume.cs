using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerVolume : MonoBehaviour
{


    [SerializeField]
    private AudioSource damageSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 40) * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            damageSound.Play();
        }
    }
}
