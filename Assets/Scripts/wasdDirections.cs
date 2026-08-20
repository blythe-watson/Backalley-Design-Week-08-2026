using UnityEngine;

public class wasdDirections : MonoBehaviour
{
    public SpriteRenderer WASDAntRenderer;
    public MoveWASD moveWASDScript;

    // Update is called once per frame
    void Update()
    {
        VisualsUpdate();
    }

    private void VisualsUpdate()
    {
        switch (moveWASDScript.GetFacingDirection())
        {
            case MoveWASD.FacingDirection.left:
                WASDAntRenderer.flipX = true;
                break;
            case MoveWASD.FacingDirection.right:
            default:
                WASDAntRenderer.flipX = false;
                break;
            case MoveWASD.FacingDirection.up:
                WASDAntRenderer.flipY = true;
                break;
            case MoveWASD.FacingDirection.down:
                WASDAntRenderer.flipY = false;
                break;
        }
    }
}
