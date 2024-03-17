//Written for Sprite Fantasia. https://store.steampowered.com/app/1619220
using System.IO;
using System.IO.Compression;

namespace Sprite_Fantasia_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "\\extracted");
            BinaryReader br = new BinaryReader(File.OpenRead(args[0]));
            br.BaseStream.Position = 18;

            MemoryStream ms = new();
            using (var ds = new DeflateStream(new MemoryStream(br.ReadBytes((int)(br.BaseStream.Length - 18))), CompressionMode.Decompress))
                ds.CopyTo(ms);
            br = new(ms);
            br.BaseStream.Position = 0;
            using FileStream FS = File.Create(Path.GetDirectoryName(args[0]) + "\\extracted\\" + Path.GetFileName(args[0]));
            BinaryWriter bw = new(FS);
            bw.Write(br.ReadBytes((int)ms.Length));
            bw.Close();
        }
    }
}
