//Written for Sprite Fantasia. https://store.steampowered.com/app/1619220
using System.IO;
using System.IO.Compression;

namespace Sprite_Fantasia_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(args[0]));

            Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "\\extracted");
            br.BaseStream.Position = 18;
            using (var ds = new DeflateStream(new MemoryStream(br.ReadBytes((int)(br.BaseStream.Length - 18))), CompressionMode.Decompress))
                ds.CopyTo(File.Create(Path.GetDirectoryName(args[0]) + "\\extracted\\" + Path.GetFileName(args[0])));
        }
    }
}
