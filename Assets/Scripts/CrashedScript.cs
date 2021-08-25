using UnityEngine;

public class CrashedScript : MonoBehaviour
{
    private Animator _anim; 
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

   
   public void CrashedAnimOn()
    {
        _anim.SetTrigger("Crashed");
    }    
}
