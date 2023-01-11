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
    [SerializeField] private float RotationSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] Transform FireTransform;
    [SerializeField] GameObject Fire;
    [SerializeField] public float AttackRate;
    [SerializeField] public float AttackSecond;
    [SerializeField] public GameObject RestartLevel;
    [SerializeField] public ParticleSystem particlewalk;
    private bool HasFlame;
    public bool _isJumped = true;
    public float JumpCdTimer = 1f;
    private bool _IsDead = false;
    public bool _isGround = true;
    public GameObject endingmenu;
    private float Horizontal;
    private float Vertical;
    private float NextAttackTime;
    public AudioSource walking;
    private CinemachineVirtualCamera _cinemachineCamera;
    private CinemachineTransposer _transposer;
    public float TurnSpeed;
    public float Jspeed = 300f;
    Vector3 movement;
    Rigidbody rb;
    Animator anim;
    Vector3 distance;
    public int Elxyr = 0;
    Vector3 direction;
    private bool FinishEnabled = false;


    void Start()
    {
        
        transform.position = ESDataManager.Instance.GetLastCheckPoint();
        particlewalk = GetComponentInChildren<ParticleSystem>();
        walking = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        _cinemachineCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        // _transposer = _cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>();
        particlewalk.Stop();
        // Awakening
        Speed = 0;
        RotationSpeed = 0;
        JumpForce = 0;
        StartCoroutine("StartGame");
    }
    void Update()
    {
        GameObject[] chests = GameObject.FindGameObjectsWithTag("ChestOpened");

        if (chests.Length == 3)
        {
            Debug.Log("You now can finish the game");
            FinishEnabled = true;
        }
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && _isJumped == true)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
            StartCoroutine("JumpCd");
            _isJumped = false;
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
        if (movementVector.magnitude > 0)
        {
            particlewalk.Play();
        }
        else
        {
            particlewalk.Stop();
        }
    }
    //TurnFace
    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }

        anim.SetFloat("Run", movementVector.magnitude);
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
    //Movement 
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
        if (other.transform.CompareTag("Finish") && FinishEnabled)
        {
            //Rotation on Finish
            other.transform.GetChild(0).gameObject.SetActive(true);
            transform.DOLocalRotate(new Vector3(0, -220, 0), 0.3f);
            anim.SetTrigger("Ending");
            // _transposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTargetOnAssign;
            // _transposer.m_FollowOffset = new Vector3(10f,7f,1.5f);
            Speed = 0f;
            TurnSpeed = 0f;
            walking.enabled = false;
            particlewalk.Stop(true);
            endingmenu.SetActive(true);
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

        if (other.CompareTag("Wind"))
        {
            Fire.SetActive(false);
            HasFlame = false;
        }

        if (other.CompareTag("Campfire"))
        {
            Fire.SetActive(true);
            HasFlame = true;
            anim.SetTrigger("Torch");
        }

        // Collecting Candys
        // if (other.transform.CompareTag("Candy"))
        // {

        //     CandyCount++;
        //     candytext.text = CandyCount.ToString();
        //     Destroy(other.gameObject);
        // }       
    }

    IEnumerator BackToReal()
    {
        yield return new WaitForSeconds(3);
        CameraManager.Instance.OpenCamera("PlayerCamera");
        Speed = 5;
        RotationSpeed = 6;
        JumpForce = 6;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(6);
        Speed = 5;
        RotationSpeed = 6;
        JumpForce = 6;
    }
    IEnumerator JumpCd()
    {
        yield return new WaitForSeconds(JumpCdTimer);
        _isJumped = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Tramp"))
        {
            other.transform.DOShakeScale(1,0.3f);
            Jspeed += 200;
            if (Jspeed >= 700)
            {
                Jspeed = 700;
            }
            rb.AddForce(new(0, Jspeed));
        }

        if (other.transform.CompareTag("ChestBurnable") && HasFlame)
        {
            HasFlame = false;
            Fire.SetActive(false);
            other.transform.tag = "Chest";
            other.gameObject.GetComponent<Burning>().ChestBurn();
        }
    }

    private void OnCollisionStay(Collision other)
    {

        //Chest Opening
        if (other.transform.CompareTag("Chest") && Input.GetKeyDown(KeyCode.E))
        {
            other.transform.tag = "ChestOpened";
            other.transform.GetComponent<Animator>().SetTrigger("Open");
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.transform.GetChild(0).gameObject,2);
            Speed = 0;
            RotationSpeed = 0;
            JumpForce = 0;
            CameraManager.Instance.OpenCamera("ChestCamera1");
            StartCoroutine("BackToReal");
            GameObject chestobh = other.transform.gameObject;
        }
        if (other.transform.CompareTag("Chest2") && Input.GetKeyDown(KeyCode.E))
        {
            other.transform.tag = "ChestOpened";
            other.transform.GetComponent<Animator>().SetTrigger("Open");
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.transform.GetChild(0).gameObject,2);
            Speed = 0;
            RotationSpeed = 0;
            JumpForce = 0;
            CameraManager.Instance.OpenCamera("ChestCamera2");
            StartCoroutine("BackToReal");
            GameObject chestobh = other.transform.gameObject;
        }
        if (other.transform.CompareTag("Chest3") && Input.GetKeyDown(KeyCode.E))
        {
            other.transform.tag = "ChestOpened";
            other.transform.GetComponent<Animator>().SetTrigger("Open");
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.transform.GetChild(0).gameObject,2);
            Speed = 0;
            RotationSpeed = 0;
            JumpForce = 0;
            CameraManager.Instance.OpenCamera("ChestCamera3");
            StartCoroutine("BackToReal");
            GameObject chestobh = other.transform.gameObject;
        }
    }
    // Restarting
    public void Restart()
    {
        //SceneManager.LoadScene(1);
    }
}
