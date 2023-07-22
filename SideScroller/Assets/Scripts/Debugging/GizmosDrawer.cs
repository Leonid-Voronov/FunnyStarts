using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class GizmosDrawer : MonoBehaviour
    {
        public static GizmosDrawer gizmos;
        private Vector3 StartLine;
        private Vector3 EndLine;
        private void Awake()
        {
            gizmos = this;
        }

        public void WriteData(Vector3 start, Vector3 end)
        {
            StartLine = start;
            EndLine = end;
        }
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(StartLine, EndLine);
            //Gizmos.DrawSphere(transform.position, 100f);
        }
    }
}
/*
[DrawGizmo(GizmoType.Active | GizmoType.NotInSelectionHierarchy)]
public static void DrawGizmos(Component positionData, GizmoType gizmoType)
{
    Gizmos.DrawSphere(new Vector3(0, 0, 0), 5);
}
}
*/

