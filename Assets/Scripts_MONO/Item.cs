using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInvoker
{
    public bool SetInvoker();
}

public class Item : MonoBehaviour, IInvoker
{
    private string nameItem = new("Unexpected Item Name");

    /// <summary>
    /// This stats sets if this Component have some tasks from others. If true, Invoke them in every Update
    /// </summary>
    private bool isInvoker = false; 
    public bool SetInvoker() { isInvoker = true; return isInvoker; }
    public List<UnityAction> Invokes = new();
    public bool testInvokes;

    //Method that used for test
    private void Test_Let_s_Doit()
    {
        name = "FuckedObject";
        Debug.Log("Say Something");
    }

    private void Update()
    {
        if (testInvokes)
        {
            Invokes.Add(Test_Let_s_Doit);
            isInvoker = true;
            testInvokes = false;
        }

        if (isInvoker)
        {
            for(int i = 0;i<Invokes.Count;i++)
            {
                Invokes[i].Invoke();
                Invokes.Remove(Invokes[i]);
                //Debug.Log(Invokes.Count);
            }
            isInvoker = false;
        }
    }
}
