using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField]private float RotationSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] Transform FireTransform;
    [SerializeField] GameObject GranadePrefab;
    [SerializeField]public float AttackRate;
    [SerializeField]public float AttackSecond;
    [SerializeField]public GameObject RestartLevel;
    [SerializeField] int CandyCount = 0;
    private bool _IsDead=false;
    public bool _isGround= true;
    public GameObject endingmenu;
    private float Horizontal;
    private float Vertical;
    private float NextAttackTime;
    public AudioSource walking;
    public ParticleSystem particlewalk;
    private CinemachineVirtualCamera _cinemachineCamera;
    private CinemachineTransposer _transposer;
    public Text candytext;
    public Text Elxyrtext;
    public float TurnSpeed;
    public float Jspeed = 300f;
    Vector3 movement;
    Rigidbody rb;
    Animator anim;
    Vector3 distance;
    public int Elxyr = 0;
    Vector3 direction;
    
    // Getting Components
    void Start()
    {
        particlewalk = GetComponentInChildren<ParticleSystem>();
        walking = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        _cinemachineCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
       // _transposer = _cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>();
    }
    // Moving and Throwing Grenade
    void Update()
    {
        //Throw elyxr
         if (Input.GetKeyDown(KeyCode.Q) && Time.time > NextAttackTime && Elxyr >= 1)
        {
            Instantiate(GranadePrefab, FireTransform.position, FireTransform.rotation);
            NextAttackTime = Time.time + AttackSecond / AttackRate;
            Elxyr --;
            Elxyrtext.text = Elxyr.ToString();
        }

        // Jumping
         if (Input.GetKeyDown(KeyCode.Space))
         {
             rb.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
         }

         if (movement.magnitude >= 0.01f && _isGround == true)
         {
            anim.SetFloat("running",movement.magnitude);
            walking.enabled = true;
            particlewalk.Play(true);
         }
         else if (movement.magnitude == 0.0f && _isGround == true)
         {
            anim.SetFloat("running",movement.magnitude);
            walking.enabled = false;
            particlewalk.Stop(true);
         }

    }
    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(h, v);
        var targetVector = new Vector3(inputVector.x, 0, inputVector.y);
        var movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);
    }
        private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = Speed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, 0, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

        // Finish Line
         public void OnTriggerStay(Collider other)
         {
            if (other.transform.CompareTag("Finish"))
            {
                //Rotation on Finish
                transform.DOLocalRotate(new Vector3(0,-220,0),0.3f);    
                anim.SetTrigger("Ending");
                // _transposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTargetOnAssign;
                // _transposer.m_FollowOffset = new Vector3(10f,7f,1.5f);
                Speed = 0f;
                TurnSpeed = 0f;
                walking.enabled = false;
                particlewalk.Stop(true);
                endingmenu.SetActive(true);
                candytext.gameObject.SetActive(false);
                Elxyrtext.gameObject.SetActive(false);
        }
         }
        // Checking enemy
    public void OnTriggerEnter(Collider other) 
    {
        if (other.transform.CompareTag("Enemy"))
        {
            anim.SetTrigger("Fear");
            Speed = 0f;
            TurnSpeed = 0f;
            RestartLevel.SetActive(true);  
            _IsDead = true;
            walking.enabled = false;
            particlewalk.Stop(true);
            rb.isKinematic = true;
        }

        if (other.transform.CompareTag("Chest"))
        {
            CameraManager.Instance.OpenCamera("ChestCamera");
            StartCoroutine("BackToReal");
        }
        // Collecting Candys
        // if (other.transform.CompareTag("Candy"))
        // {
            
        //     CandyCount++;
        //     candytext.text = CandyCount.ToString();
        //     Destroy(other.gameObject);
        // } 
        // // Collecting Elxyr
        // if (other.transform.CompareTag("Elxyr"))
        // {
        //     Destroy(other.gameObject);
        //     Elxyr++;
        //     Elxyrtext.text = Elxyr.ToString();
        // }        
    }

    IEnumerator BackToReal()
    {
        yield return new WaitForSeconds(3);
        CameraManager.Instance.OpenCamera("PlayerCamera");
    }

        // Checking ground
     private void OnCollisionEnter(Collision other) 
     {
         if(other.transform.CompareTag("Ground"))
        {
            _isGround=true;   
        }

         if(other.transform.CompareTag("Tramp"))
        {
            Jspeed += 200;
            if (Jspeed >= 700)
            {
                Jspeed= 700;
            }
            rb.AddForce(new (0,Jspeed));   
        } 

        // Grenade Type Enemys
        if (other.transform.CompareTag("Enemy"))
        {
            anim.SetTrigger("Fear");
            Speed = 0f;
            TurnSpeed = 0f;
            RestartLevel.SetActive(true);  
            _IsDead = true;
            walking.enabled = false;
            particlewalk.Stop(true);
        }
    }
        // Restarting
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
