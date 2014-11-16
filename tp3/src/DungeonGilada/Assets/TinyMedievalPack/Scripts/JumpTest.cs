using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class JumpTest : MonoBehaviour {
    Animator animator, enemyAnimator;
    Transform tf;
    Vector3 startPosition, endPosition;
    public GameObject hitEffect;

	void Start () {
        animator = GetComponent<Animator>();
        enemyAnimator = GameObject.Find("Enemies/Dog").GetComponent<Animator>();
        tf = transform;
        startPosition = tf.position;
        endPosition = tf.localPosition + tf.forward * 3f;
    }

    void JumpMotion()
    {
        animator.SetTrigger("Jump");

        SequenceParms sparams = new SequenceParms(); //.OnComplete(gameObject, "OnCompleteJump");
        Sequence mySequence = new Sequence(sparams);
        TweenParms parms;

        tf.position = startPosition;

        parms = new TweenParms().Prop("position", startPosition).Ease(EaseType.EaseOutQuad).OnComplete(OnDoneTakeOff);
        mySequence.Append(HOTween.To(tf, 0.4f, parms));

        parms = new TweenParms().Prop("position", endPosition).Ease(EaseType.EaseOutQuad).OnComplete(OnDoneAir);
        mySequence.Append(HOTween.To(tf, 0.2f, parms));

        parms = new TweenParms().Prop("position", endPosition).Ease(EaseType.EaseOutQuad).OnComplete(OnDoneLanding);
        mySequence.Append(HOTween.To(tf, 0.6f, parms));

        mySequence.Play();

    }

    void JumpBackMotion()
    {
        animator.SetTrigger("Jump");

        SequenceParms sparams = new SequenceParms(); //.OnComplete(gameObject, "OnCompleteJump");
        Sequence mySequence = new Sequence(sparams);
        TweenParms parms;

        tf.position = endPosition;

        parms = new TweenParms().Prop("position", endPosition).Ease(EaseType.EaseOutQuad);
        mySequence.Append(HOTween.To(tf, 0.4f, parms));

        parms = new TweenParms().Prop("position", startPosition).Ease(EaseType.EaseOutQuad).OnComplete(OnDoneAir2);
        mySequence.Append(HOTween.To(tf, 0.2f, parms));

        parms = new TweenParms().Prop("position", startPosition).Ease(EaseType.EaseOutQuad);
        mySequence.Append(HOTween.To(tf, 0.6f, parms));

        mySequence.Play();

    }

    void OnCompleteJump()
    {

    }

    void OnDoneTakeOff()
    {

    }

    void OnDeal()
    {
        enemyAnimator.CrossFade("Damage", 0.2f);

        Instantiate(hitEffect, enemyAnimator.transform.position + Vector3.up * 1.2f, Quaternion.identity);

        StartCoroutine(DelayActoin(0.4f, () =>
        {
            JumpBackMotion();
        }));
    }

    void OnDoneAir()
    {
        animator.SetTrigger("Land");
        animator.SetTrigger("Attack");
    }

    void OnDoneAir2()
    {
        animator.SetTrigger("Land");
    }

    void OnDoneLanding()
    {
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) JumpMotion();
	}
    public IEnumerator DelayActoin(float dtime, System.Action callback)
    {
        yield return new WaitForSeconds(dtime);
        callback();
    }
}
