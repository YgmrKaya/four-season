using UnityEngine;

public class PaintableArea : MonoBehaviour
{
    public Color paintColor = Color.red; // Boya rengi
    public int brushSize = 10; // F�r�a boyutu
    private Texture2D paintTexture; // Boyanacak texture
    private SpriteRenderer spriteRenderer;
    private Collider2D paintableCollider; // Collider2D bile�eni

    void Start()
    {
        // SpriteRenderer bile�enini al
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Collider2D bile�enini al
        paintableCollider = GetComponent<Collider2D>();

        // Mevcut sprite'�n texture'�n� kopyala
        Texture2D originalTexture = spriteRenderer.sprite.texture;
        paintTexture = new Texture2D(originalTexture.width, originalTexture.height, TextureFormat.RGBA32, false);
        paintTexture.SetPixels(originalTexture.GetPixels());
        paintTexture.Apply();

        // Yeni texture'� sprite'a ata
        spriteRenderer.sprite = Sprite.Create(paintTexture, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f));
    }

    void Update()
    {
        // F�r�an�n pozisyonunu al
        Vector2 brushPosition = GameObject.FindGameObjectWithTag("Brush").transform.position;

        // F�r�an�n paintablearea i�inde olup olmad���n� kontrol et
        if (paintableCollider.OverlapPoint(brushPosition))
        {
            // F�r�an�n pozisyonunu texture koordinatlar�na �evir
            Vector2 textureCoord = WorldToTextureCoord(brushPosition);

            // Texture'� boya
            PaintTexture((int)textureCoord.x, (int)textureCoord.y);
        }
    }

    Vector2 WorldToTextureCoord(Vector2 worldPosition)
    {
        // D�nya koordinatlar�n� lokal koordinatlara �evir
        Vector2 localPosition = transform.InverseTransformPoint(worldPosition);

        // Sprite'�n s�n�rlar�n� ve pivot noktas�n� dikkate alarak texture koordinatlar�n� hesapla
        Rect spriteRect = spriteRenderer.sprite.rect;
        Vector2 textureCoord = new Vector2(
            (localPosition.x / spriteRenderer.bounds.size.x + 0.5f) * paintTexture.width,
            (localPosition.y / spriteRenderer.bounds.size.y + 0.5f) * paintTexture.height
        );

        return textureCoord;
    }

    void PaintTexture(int x, int y)
    {
        // F�r�a boyutu kadar geni� bir alan� boya
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                // Daire �eklinde boyama
                if (i * i + j * j <= brushSize * brushSize)
                {
                    int pixelX = x + i;
                    int pixelY = y + j;

                    // Texture'�n s�n�rlar�n� kontrol et
                    if (pixelX >= 0 && pixelX < paintTexture.width && pixelY >= 0 && pixelY < paintTexture.height)
                    {
                        // Texture'� boya
                        paintTexture.SetPixel(pixelX, pixelY, paintColor);
                    }
                }
            }
        }

        paintTexture.Apply(); // De�i�iklikleri uygula
    }
}