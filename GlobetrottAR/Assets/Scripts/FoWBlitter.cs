using UnityEngine;
using System.Collections;

public class FoWBlitter : MonoBehaviour {

    public Coordinator coordinator;
    public Material fowBlitter;
    public RenderTexture fowTexture1;
    public RenderTexture fowTexture2;

    private bool flip = false;

    void Start() {
        ResetTextures();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = coordinator.GetTextureOffset();
        fowBlitter.SetTextureOffset("_FoWTex", new Vector2(pos.x, pos.y));
        RenderTexture rt1 = flip ? fowTexture1 : fowTexture2;
        RenderTexture rt2 = !flip ? fowTexture1 : fowTexture2;
        flip = !flip;
        Graphics.Blit(rt1, rt2, fowBlitter);
	}

    void ResetTextures() {
        Graphics.SetRenderTarget(fowTexture1);
        GL.Clear(false, true, Color.black);
        Graphics.SetRenderTarget(fowTexture2);
        GL.Clear(false, true, Color.black);
        //Graphics.SetRenderTarget(null);
    }
}
