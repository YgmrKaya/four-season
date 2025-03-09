using UnityEngine;

public class PaintableArea : MonoBehaviour
{
    public Color paintColor = Color.red; // Boya rengi
    public int brushSize = 10; // Fýrça boyutu
    private Texture2D paintTexture; // Boyanacak texture
    private SpriteRenderer spriteRenderer;
    private Collider2D paintableCollider; // Collider2D bileþeni

    void Start()
    {
        // SpriteRenderer bileþenini al
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Collider2D bileþenini al
        paintableCollider = GetComponent<Collider2D>();

        // Mevcut sprite'ýn texture'ýný kopyala
        Texture2D originalTexture = spriteRenderer.sprite.texture;
        paintTexture = new Texture2D(originalTexture.width, originalTexture.height, TextureFormat.RGBA32, false);
        paintTexture.SetPixels(originalTexture.GetPixels());
        paintTexture.Apply();

        // Yeni texture'ý sprite'a ata
        spriteRenderer.sprite = Sprite.Create(paintTexture, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f));
    }

    void Update()
    {
        // Fýrçanýn pozisyonunu al
        Vector2 brushPosition = GameObject.FindGameObjectWithTag("Brush").transform.position;

        // Fýrçanýn paintablearea içinde olup olmadýðýný kontrol et
        if (paintableCollider.OverlapPoint(brushPosition))
        {
            // Fýrçanýn pozisyonunu texture koordinatlarýna çevir
            Vector2 textureCoord = WorldToTextureCoord(brushPosition);

            // Texture'ý boya
            PaintTexture((int)textureCoord.x, (int)textureCoord.y);
        }
    }

    Vector2 WorldToTextureCoord(Vector2 worldPosition)
    {
        // Dünya koordinatlarýný lokal koordinatlara çevir
        Vector2 localPosition = transform.InverseTransformPoint(worldPosition);

        // Sprite'ýn sýnýrlarýný ve pivot noktasýný dikkate alarak texture koordinatlarýný hesapla
        Rect spriteRect = spriteRenderer.sprite.rect;
        Vector2 textureCoord = new Vector2(
            (localPosition.x / spriteRenderer.bounds.size.x + 0.5f) * paintTexture.width,
            (localPosition.y / spriteRenderer.bounds.size.y + 0.5f) * paintTexture.height
        );

        return textureCoord;
    }

    void PaintTexture(int x, int y)
    {
        // Fýrça boyutu kadar geniþ bir alaný boya
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                // Daire þeklinde boyama
                if (i * i + j * j <= brushSize * brushSize)
                {
                    int pixelX = x + i;
                    int pixelY = y + j;

                    // Texture'ýn sýnýrlarýný kontrol et
                    if (pixelX >= 0 && pixelX < paintTexture.width && pixelY >= 0 && pixelY < paintTexture.height)
                    {
                        // Texture'ý boya
                        paintTexture.SetPixel(pixelX, pixelY, paintColor);
                    }
                }
            }
        }

        paintTexture.Apply(); // Deðiþiklikleri uygula
    }
}