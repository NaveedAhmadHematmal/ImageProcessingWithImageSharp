using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessingWithImageSharp.Core;

public class ImageProcessingCore
{
    public static async Task<Image> LoadImageFromUrlAndResize(string url, int width = 0, int height = 0)
    {
        Image image;
        using (HttpClient c = new HttpClient())
        {
            using (Stream s = await c.GetStreamAsync(url))
            {
                image = Image.Load(s);
            }
        }

        if (image is null)
        {
            throw new FileNotFoundException();
        }

        if (width != 0 && height != 0)
        {
            image.Mutate(x => x.Resize(new Size(width, height)));
        }

        return image;
    }

    public static async Task<Image> LoadAndResizeImage(string path, int width = 0, int height = 0)
    {
        Image image;
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }

        image = await Image.LoadAsync(path);

        if (width != 0 && height != 0)
        {
            image.Mutate(x => x.Resize(new Size(width, height)));
        }

        return image;
    }

    public static Image DrawTextAtImage(Image image, string text, Color color, float size, float x, float y, int fontAttribute = 0, string fontFamily = "resources/fonts/TitleFont.ttf")
    {
        if (!File.Exists(fontFamily))
        {
            throw new FileNotFoundException("Font not found!");
        }

        if (image is null)
        {
            throw new NullReferenceException();
        }

        FontCollection collection = new();
        FontFamily family = collection.Install(fontFamily);
        Font font = family.CreateFont(size, (FontStyle)fontAttribute);
        PointF point = new PointF(x, y);

        image.Mutate(x => x.DrawText(text, font, color, point));

        return image;
    }

    public static Image DrawFilledRect(Image image, float x, float y, float width, float height, Color color)
    {
        if (image is null)
        {
            throw new NullReferenceException();
        }

        RectangleF rect = new RectangleF(x, y, width, height);
        IPen pen = Pens.Solid(color, 1);
        image.Mutate(x => x.Draw(pen, rect)
                           .Fill(color, rect));

        return image;
    }

    public static Image DrawImageAt(Image baseImage, Image image, int x, int y)
    {
        GraphicsOptions g = new GraphicsOptions();
        Point logoPoint = new Point(x, y);
        baseImage.Mutate(x => x.DrawImage(image, logoPoint, g));

        return baseImage;
    }

    // public static Image ReadImageAsStreamAsync(string path)
    // {
    //     Image image;
    //     if (!File.Exists(path))
    //     {
    //         throw new FileNotFoundException();
    //     }

    //     FileStream fStream = new FileStream(path, FileMode.Open);
    //     try
    //     {
    //         image = Image.Load(fStream);
    //         return image;
    //     }
    //     finally
    //     {
    //         fStream.Close();
    //     }
    // }

    public static Image DrawProgressBar(Image image, float x, float y, int barWidth, int barHeight, int completed)
    {
        RectangleF rect = new RectangleF(x, y, barWidth, barHeight);
        IPen pen = Pens.Solid(Color.White, 1);
        image.Mutate(x => x.Draw(pen, rect));

        rect = new RectangleF(x, y, completed*5.5f, barHeight);
        pen = Pens.Solid(Color.Orange, 1);
        image.Mutate(x => x.Draw(pen, rect)
                           .Fill(Color.Orange, rect));
        return image;
    }
}