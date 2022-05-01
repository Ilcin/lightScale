using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 10; //how many pixels
    public int height = 10;

    public float scale = 1;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float sampleRange = 0.4f;

    public Renderer tileRenderer;

    private void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        offsetX = Random.Range(0f, 999f);
        offsetY = Random.Range(0f, 999f);
    }

    private void Update()
    {
        tileRenderer.material.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        //Generate Perlin Noise map
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply(); //apply the changes texture
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        //we have pixelcoordinates = whole numbers (0 or 1)
        //but perlinnoise repeats at whole numbers
        //change interval [0-width] -> [0-1]

        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);

        //sample the PerlinNoise
        if (sample < sampleRange)
        {
            sample = 0;
        }
        else
        {
            sample = 1;
        }

        return new Color(sample, sample, sample);
    }
}
