using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedshot : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public int bulletWaynum = 3;
    public float bulletWayspace = 30;
    public float bulletWayAxis = 0;
    public float time = 1;
    public float delaytime = 1;
    float nowtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        nowtime = delaytime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        nowtime -= Time.deltaTime;
        if (nowtime <= 0)
        {
            float bulletWaySpaceSprit = 0;
            for (int i = 0; i < bulletWaynum; i++)
            {
                CreateShotObject(bulletWayspace - bulletWaySpaceSprit + transform.localEulerAngles.y);
                bulletWaySpaceSprit += (bulletWayspace / (bulletWaynum - 1)) * 2;
            }
            nowtime = time;
        }
    }
    private void CreateShotObject(float axis)
    {

        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
        var bulletObject = bulletClone.GetComponent<Enemybullet>();
        bulletObject.SetCharacterObject(gameObject);
        bulletObject.SetForwardAxis(  Quaternion.AngleAxis(axis, Vector3.up));

    }
}
