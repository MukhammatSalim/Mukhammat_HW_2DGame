using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Danger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
       protected virtual void KillPlayer(IPlayer player)
    {
        player.MakeDamage();
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player)
        {
            KillPlayer(player);
        }
    }

        public virtual void PlayAnimation(string name)
    {
        if (_animator)
        {
            _animator.Play(name, 0, 0);
        }
        else
        {
            Debug.LogError($"{this} Animator is null!");
        }
    }
}
