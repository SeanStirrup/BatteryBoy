using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//thanks to Casey Mfkn Urso for this bitchin script

public class DizzyBar : MonoBehaviour
{
    public Slider DizzySlider;
    public static float DizzyValue = 3000f;
    public Animator animator;

    private void Start()
    {
        animator.SetBool("IsDizzy", false);
    }

    void Update()
    {
        DizzySlider.value = DizzyValue;
        DizzyValue--;

        if (DizzyValue <= 0)
        {
            DizzyValue = 0f;
            animator.SetBool("IsDizzy", true);
            StartCoroutine(dizzyTime());
        }
    }

    IEnumerator dizzyTime()
    {
        PhysicsMovement.runSpeed = 0f;
        yield return new WaitForSeconds(4f);
        PhysicsMovement.runSpeed = 10f;
        DizzyValue = 3000f;
        animator.SetBool("IsDizzy", false);
    }
}
