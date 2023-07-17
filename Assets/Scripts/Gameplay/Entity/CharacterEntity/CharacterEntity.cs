using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : DamageableEntity
{
    public Tank tankData
    {
        get
        {
            if (data is Tank tank)
            {
                return tank;
            }
            else return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("bullet"))
        //{
        //    GameObject textMeshDamage = Instantiate(floatingPoints, transform.position, Quaternion.identity);

        //    textMeshDamage.GetComponentInChildren<TextMesh>().text = collision.GetComponent<BulletController>().Damage.ToString();
        //    textMeshDamage.transform.parent = transform;

        //    Destroy(textMeshDamage, 1f);


        //    Destroy(collision.gameObject);
        //}
    }
}
