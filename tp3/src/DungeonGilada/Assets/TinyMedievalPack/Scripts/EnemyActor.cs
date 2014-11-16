using UnityEngine;
using System.Collections;

public class EnemyActor : MonoBehaviour {
    public GameObject damageEffectPrefab;
    Animator animator;
    Transform tr;
    public Transform bone1, bone2, shadow;

	void Start () {
        animator = GetComponent<Animator>();
        bone1 = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        bone2 = animator.GetBoneTransform(HumanBodyBones.RightFoot);
        shadow = transform.FindChild("Shadow");
        tr = transform;
    }

    void OnDeal(int type)
    {
        //Debug.Log("OnDeal : " + type);
    }

	void Update () {
        if (animator && bone1 && bone2)
        {
            Vector3 pos = (bone1.position + bone2.position) / 2f;
            pos.y = tr.position.y + 0.01f;
            if (shadow)
                shadow.transform.position = pos;
        }
    }

    void OnDamage()
    {
        animator.CrossFade("Damage", 0.2f);
        if (damageEffectPrefab) Instantiate(damageEffectPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.tag == "Bullet")
            {
                OnDamage();
            }
        }
    }
}
