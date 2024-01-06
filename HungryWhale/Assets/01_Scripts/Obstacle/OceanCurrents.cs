using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OceanCurrents : MonoBehaviour
{
    private GameObject player;
    private bool isOceanCurrents;

	[SerializeField] private ParticleSystem waveParticleL;
	[SerializeField] private ParticleSystem waveParticleR;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(ActiveOceanCurrents());
    }

    public IEnumerator ActiveOceanCurrents()
    {
        while(true)
		{
            yield return new WaitForSeconds(10);
            int rand = Random.Range(0, 2) == 0 ? 1 : -1;
            StartCoroutine(PlayParticle(rand, 10));
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(rand * 500, 0, 0));
            yield return new WaitForSeconds(10);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 0, 0));
		}
    }

    IEnumerator PlayParticle(int i, int time)
	{
        if(i == -1)
		{
            waveParticleL.gameObject.SetActive(true);
            waveParticleL.Play();
            yield return new WaitForSeconds(time);
            waveParticleL.Stop();
            waveParticleL.gameObject.SetActive(false);
		}
		else if(i == 1)
		{
            waveParticleR.gameObject.SetActive(true);
            waveParticleR.Play();
            yield return new WaitForSeconds(time);
            waveParticleR.Stop();
            waveParticleR.gameObject.SetActive(false);
        }

	}
}
