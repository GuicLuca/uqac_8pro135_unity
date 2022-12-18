using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class Spaceship : MonoBehaviour
{
    public float normalSpeed = 25f;
    public float accelerationSpeed = 45f;
    public Transform cameraPosition;
    public Camera mainCamera;
    public Transform spaceshipRoot;
    public float rotationSpeed = 2f;
    public float cameraSmooth = 4f;
    public RectTransform crosshairTexture;
    public ObjectPool objectPool;
    public Transform bulletSpawner;
    public float fireRate = 0.25f;
    public AudioSource audioSource;

    float speed;
    Rigidbody r;
    Quaternion lookRotation;
    float rotationZ = 0;
    float rotationY = 0;
    float rotationX = 0;
    float mouseXSmooth = 0;
    float mouseYSmooth = 0;
    Vector3 defaultShipRotation;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
        lookRotation = transform.rotation;
        defaultShipRotation = spaceshipRoot.localEulerAngles;
        rotationZ = defaultShipRotation.z;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void FixedUpdate()
    {
        //Press Right Mouse Button to accelerate
        if (Input.GetMouseButton(1))
        {
            speed = Mathf.Lerp(speed, accelerationSpeed, Time.deltaTime * 3);
        }
        else
        {
            speed = Mathf.Lerp(speed, normalSpeed, Time.deltaTime * 10);
        }

        //Set moveDirection to the vertical axis (up and down keys) * speed
        Vector3 moveDirection = new Vector3(0, 0, speed);
        //Transform the vector3 to local space
        moveDirection = transform.TransformDirection(moveDirection);
        //Set the velocity, so you can move
        r.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

        //Camera follow
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition.position, Time.deltaTime * cameraSmooth);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, cameraPosition.rotation, Time.deltaTime * cameraSmooth);

        //Rotation
        float rotationYTmp = 0;
        if (Input.GetKey(KeyCode.A))
        {
            rotationYTmp = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationYTmp = -1;
        }
        
        mouseXSmooth = Mathf.Lerp(mouseXSmooth, Input.GetAxis("Mouse X") * (rotationSpeed * 5), Time.deltaTime * cameraSmooth);
        mouseYSmooth = Mathf.Lerp(mouseYSmooth, Input.GetAxis("Mouse Y") * (rotationSpeed * 5), Time.deltaTime * cameraSmooth);
        
        Quaternion localRotation = Quaternion.Euler(-mouseYSmooth, mouseXSmooth, rotationYTmp * rotationSpeed);
        transform.rotation = lookRotation * localRotation;
        rotationZ += rotationYTmp * rotationSpeed;
        rotationZ = Mathf.Clamp(rotationZ, -45, 45);
        rotationY += mouseXSmooth;
        rotationX -= mouseYSmooth;
        spaceshipRoot.transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);
        rotationZ = Mathf.Lerp(rotationZ, defaultShipRotation.z, Time.deltaTime * cameraSmooth);

        //Update crosshair texture
        if (crosshairTexture)
        {
            crosshairTexture.position = mainCamera.WorldToScreenPoint(transform.position + transform.forward * 100);
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = ObjectPool.Instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = bulletSpawner.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().SetForwardVector(transform);
                audioSource.PlayOneShot(audioSource.clip);
                bullet.GetComponent<Bullet>().destroyTime = Time.time + bullet.GetComponent<Bullet>().lifeTime;
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("EndScreen");
    }
}