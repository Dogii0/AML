using UnityEngine;

public class item : MonoBehaviour, IInteractable
{
private Animator _animator;
private bool _noMove;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        _noMove = true;
        _animator.SetTrigger("Move");
    }

    public bool CanInteract()
    {
        return !_noMove;
    }
}
