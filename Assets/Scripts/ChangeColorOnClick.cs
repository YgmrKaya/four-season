using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    private Animator animator;
    private bool isRed = false; // Kare �u anda k�rm�z� m�?

    void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (isRed)
        {
            // E�er kare k�rm�z�ysa, beyaza d�n
            animator.SetTrigger("toori");
        }
        else
        {
            // E�er kare beyazsa, k�rm�z�ya d�n
            animator.SetTrigger("tored");
        }

        // Durumu tersine �evir
        isRed = !isRed;
    }
}
