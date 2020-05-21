using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.Singleton;
public class Unit
{
    Transform transform;
    Animator anim;

    public Unit(Transform transform, Animator anim = null)
    {
        this.anim = anim;
        this.transform = transform;
    }
    public void MoveTo(Vector3 aimPos)
    {
       anim.SetBool("run", true);
       transform.MoveTo(aimPos, true).OnComplete += () => { anim.SetBool("run", false); }; ;
    }
}
public abstract class Commoand 
{
    protected Unit unit;
    public abstract void Execute();
}
public class InputHandler : Singleton<InputHandler>
{
    Unit unit;
    public void SelectUnit(Unit unit)
    {
        this.unit = unit;
    }
    public Commoand HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,LayerMask.GetMask("Ground")))
            {
                return new MoveToCommoand(unit, hit.point);
            }
            else
            {
                return null;
            }
        }
        return null;
    }
}

public class MoveToCommoand : Commoand
{
    Vector3 aimPos;
    public MoveToCommoand(Unit unit,Vector3 pos)
    {
        this.unit = unit;
        this.aimPos = pos;
    }
    public override void Execute()
    {
        unit.MoveTo(aimPos);
    }
}
