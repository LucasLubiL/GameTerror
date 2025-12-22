using UnityEngine;

public class CrosshairUI : MonoBehaviour
{
    public Color crosshairColor = Color.white;
    public float crosshairSize = 2f;
    public float crosshairThickness = 2f;

    private void OnGUI()
    {
        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;

        // Desenhar bolinha (c�rculo simples)
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, crosshairColor);
        texture.Apply();

        GUI.skin.box.normal.background = texture;

        // Desenhar crosshair como cruz simples
        GUI.Box(new Rect(centerX - crosshairSize, centerY - crosshairThickness / 2, crosshairSize * 2, crosshairThickness), GUIContent.none);
        GUI.Box(new Rect(centerX - crosshairThickness / 2, centerY - crosshairSize, crosshairThickness, crosshairSize * 2), GUIContent.none);
    }
}