using UnityEngine;

public class ArrowDirections : MonoBehaviour
{
    public SpriteRenderer arrowAntRenderer;
    public MoveArrows moveArrowsScript;

    // Update is called once per frame
    void Update()
    {
        VisualsUpdate();
    }

    private void VisualsUpdate()
    {
        switch (moveArrowsScript.GetFacingDirection())
        {
            case MoveArrows.FacingDirection.left:
                arrowAntRenderer.flipX = true;
                break;
            case MoveArrows.FacingDirection.right:
            default:
                arrowAntRenderer.flipX = false;
                break;
            case MoveArrows.FacingDirection.up:
                arrowAntRenderer.flipY = true;
                break;
            case MoveArrows.FacingDirection.down:
                arrowAntRenderer.flipY = false;
                break;
        }
    }

}
