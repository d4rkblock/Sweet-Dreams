using UnityEngine;
using UnityEditor;

public abstract class BaseWeapon : MonoBehaviour
{
    // public variables
    public Animation animationWeapon;
    public AnimationClip actionAnimation;
    public AnimationClip changeAnimation;
    public AudioClip actionSound;
    public float actionRate;
	public string weaponName;

    // private variables
    private Animation animationBase;
    private AudioSource audioSource;
    private bool canAction;
    private float currentTimeToAction;

    // abstract methods
    protected abstract void OnAction();

    // Use this for initialization
    protected void Start()
    {
        animationBase = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!canAction)
        {
            currentTimeToAction += Time.deltaTime;
            if (currentTimeToAction > actionRate)
            {
                currentTimeToAction = 0;
                canAction = true;
            }
        }
        if (animationWeapon.isPlaying)
            canAction = false;
        else
            canAction = true;
    }

    public void Action()
    {

    }

    public void Change()
    {
		
    }
}