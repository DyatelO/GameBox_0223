using UnityEngine;

internal class AnimateViewModel
{
    private Animator animator;
    public Animator Animator { get => animator; set => animator = value; }

    public AnimateViewModel()
    {
        this.animator = Animator;
    }
}