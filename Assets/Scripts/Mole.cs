using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private bool _dead = false;
    private Animator _animator;
    private AudioSource _audioSource;

    public AudioClip deadSound;
    public AudioClip fleeSound;
    public AudioClip giggleSound;

    public void Start()
    {
        _animator = transform.GetComponent<Animator>();
        _audioSource = transform.GetComponent<AudioSource>();
    }

    public bool IsAlive() => !_dead;
    
    public void Dead()
    {
        if (_dead)
        {
            return;
        }
        
        _dead = true;
        
        _animator.SetBool("isDead", true);
        _audioSource.clip = deadSound;
        _audioSource.Play();

        StartCoroutine(nameof (Dying));
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(.5f);
        
        transform.gameObject.SetActive(false);
    }
}
