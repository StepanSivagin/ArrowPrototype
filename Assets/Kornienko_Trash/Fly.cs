using System.Collections;
using UnityEngine;

public class Fly : MonoBehaviour

{
    public GameObject obj;
    public float movementSpeed = 100f;
    public float resetSpeed = 100f;
    public float shiftSpeed = 150f;
    public float controlSpeed = 50f;

    public float horizSensivity = 2f;
    public float vertSensivity = 2f;

    public float yaw = 0f;
    public float pitch = 0f;
    public bool IsFly = true;
    public bool IsFlyAway = false;
    public bool IsDead = false;
    //public ParticleSystem particleDeath;
    //public ParticleSystem particleLauncher;
    //public ParticleSystem particleLauncher1;
    //public ParticleSystem particleLauncher2;
    public Transform body;
    public ragdoll Rgdl;

    private RaycastHit hit;

    [SerializeField] private GameObject _endGameCanvas;
    [SerializeField] private SmoothFollowCamera _camera;
    [SerializeField] private float _force = 10000;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    private void ArrowFlyAway()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
    private IEnumerator CanvasTimer(GameObject canvas)
    {
        yield return new WaitForSeconds(0.5f);
        canvas.SetActive(true);
    }
    void Update()
    {
        if (!IsFly && IsFlyAway && !IsDead)
        {
            ArrowFlyAway();
        }
        if (!IsFly||IsDead) return;
        yaw += horizSensivity * Input.GetAxis("Mouse X");
        pitch -= horizSensivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, -10.375f);

        if (Input.anyKey) gameObject.GetComponent<MeshRenderer>().enabled = true;
        if (gameObject.GetComponent<MeshRenderer>().enabled||!IsDead) transform.localPosition += transform.forward * Time.deltaTime * controlSpeed;

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, 1)&& !IsDead)
        {

            if (hit.collider.CompareTag("Finish"))
            {
                IsDead = true;
                Rgdl.die();
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(Vector3.forward) * _force);
                //particleLauncher.enableEmission = false;
                //particleLauncher1.enableEmission = false;
                //particleLauncher2.enableEmission = false;
                //particleDeath.Emit(1);
                Time.timeScale = 0.3f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                gameObject.transform.SetParent(hit.collider.transform);
                gameObject.transform.localPosition = hit.collider.transform.localPosition;
                //gameObject.transform.rotation = Quaternion.Euler(hit.normal);
                _camera.enabled = false;
                StartCoroutine(CanvasTimer(_endGameCanvas));

            }
            //if (hit.collider.CompareTag("Enviroment"))
            //{
            //    StartCoroutine(CanvasTimer(_endGameCanvas));
            //    _camera.enabled = false;
            //    gameObject.GetComponent<MeshRenderer>().enabled = false;
            //    gameObject.GetComponent<Fly>().IsFly = false;
            //}
            //if (hit.collider.CompareTag("AirBorders"))
            //{
            //    StartCoroutine(CanvasTimer(_endGameCanvas));
            //    _camera.enabled = false;
            //    IsFlyAway = true;
            //    gameObject.GetComponent<Fly>().IsFly = false;
            //}
        }


        /*transform.localPosition += transform.forward * Time.deltaTime * controlSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = shiftSpeed;
        }
        else
        {
            movementSpeed = resetSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * Time.deltaTime * controlSpeed;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Destroy(obj);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * Time.deltaTime * controlSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
           transform.localPosition -= transform.forward * Time.deltaTime * controlSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += transform.right * Time.deltaTime * controlSpeed;
        }
        */
    }
    //public void AddImpulse()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    rb.AddForce(arrow.transform.localPosition * forceImpule, ForceMode.Impulse);
    //}
}
