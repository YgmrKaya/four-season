using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    private Animator animator;
    private bool isRed = false; // Kare þu anda kýrmýzý mý?

    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (isRed)
        {
            // Eðer kare kýrmýzýysa, beyaza dön
            animator.SetTrigger("toori");
        }
        else
        {
            // Eðer kare beyazsa, kýrmýzýya dön
            animator.SetTrigger("tored");
        }

        // Durumu tersine çevir
        isRed = !isRed;
    }
}
