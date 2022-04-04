using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class slashVFX : MonoBehaviour
{
    public List<GameObject> slashesVFX = new List<GameObject>();
    public void startSlashVFX(){
        if(Player.instance.getAnimator().GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_1")){
            print("1");
            Normal1VFX();
        }
    }

    private void Normal1VFX(){
        print("2");

        GameObject slashVFX = slashesVFX.Where(obj => obj.name == "Normal1VFX").SingleOrDefault();
        print(slashVFX.name);
        slashVFX.SetActive(true);
    }
    private void Normal2VFX(){
        
    }
    private void Normal3VFX(){
        
    }
}
