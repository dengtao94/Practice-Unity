using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BD
{
    public class BaseOperation : MonoBehaviour
    {
        public GameObject Target;

        Type type = Type.GetType("BD.OperationList");

        void CallMethod(string MethodName,ArrayList templist)
        {
            MethodInfo method = type.GetMethod(MethodName);

            object obj = Activator.CreateInstance(type);

            object[] parameters = new object[] { templist };

            method.Invoke(obj, parameters);
        }

        private void Start()
        {
            ArrayList test = new ArrayList();
            test.Add(Target);
            test.Add(Vector3.zero);
            CallMethod("Move", test);
        }
    }

    public class OperationList
    {
        public void Move(ArrayList parameters)
        {
            //foreach (object p in parameters)
            //{
            //    Debug.Log(p.ToString());
            //}
            Move((GameObject)parameters[1], (Vector3)parameters[2]);
        }

        void Move(GameObject Target,Vector3 Force)
        {
            Debug.Log("Target is" + Target.name + "MoveX is" + Force.x);
        }
    }
}
