using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Transform spawnBulletPos, spawnBulletShellPos;
    [SerializeField] private GameObject bulletPrefab, bulletShellFX;
    public bool shooting;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        Vector3 mouseWorldPosition = Vector3.zero;


        Vector2 centerPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(centerPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f)) {
            mouseWorldPosition = raycastHit.point;    
        }

        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDir = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 20f);

        if (shooting) {
            
            Vector3 aimDirBullet = (mouseWorldPosition - spawnBulletPos.position).normalized;
            Instantiate(bulletShellFX, spawnBulletShellPos.position, Quaternion.Euler(aimDirBullet.x, aimDirBullet.y, aimDirBullet.z));
            Instantiate(bulletPrefab, spawnBulletPos.position, Quaternion.LookRotation(aimDirBullet, Vector3.up));
            //shooting = false;
        }
    }
}
