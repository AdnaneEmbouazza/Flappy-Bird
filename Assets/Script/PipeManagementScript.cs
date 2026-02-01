using UnityEditor;
using UnityEngine;

public class PipeDesactivateScript : MonoBehaviour
{
    public PipeMoveScript pipeMoveScript;

    void Start()
    {
    }

    void Update()
    {
        //DeactivateColliderPipe();
    }

    public void DeactivateColliderPipe()
    {

            // aller chercher les enfants "top pipe" et "bottom pipe"
            Transform topChildPipe = this.transform.Find("top pipe");
            Transform bottomChildPipe = this.transform.Find("bottom pipe");

            if (topChildPipe != null && bottomChildPipe != null)
            {
                // aller chercher le collider des tuyaux top et bottom

                BoxCollider2D topPipeCollider = topChildPipe.GetComponentInChildren<BoxCollider2D>();
                BoxCollider2D bottomPipeCollider = bottomChildPipe.GetComponentInChildren<BoxCollider2D>();

                if (topPipeCollider != null && bottomPipeCollider != null)
                {
                    //si les colliders des tuyaux sont actifs
                    if (topPipeCollider.enabled && bottomPipeCollider.enabled)
                    {
                        // les désactiver pour que le joueur puisse passer à travers
                        topPipeCollider.enabled = false;
                        bottomPipeCollider.enabled = false;
                    }
                }
            }
    }

    public void ReactivateColliderPipe()
    {
        Transform topChildPipe = this.transform.Find("top pipe");
        Transform bottomChildPipe = this.transform.Find("bottom pipe");

        if (topChildPipe != null && bottomChildPipe != null)
        {
            BoxCollider2D topPipeCollider = topChildPipe.GetComponentInChildren<BoxCollider2D>();
            BoxCollider2D bottomPipeCollider = bottomChildPipe.GetComponentInChildren<BoxCollider2D>();

            if(topPipeCollider != null && bottomPipeCollider != null)
            {
                topPipeCollider.enabled = true;
                bottomPipeCollider.enabled = true;
            }
        }
    }

}
