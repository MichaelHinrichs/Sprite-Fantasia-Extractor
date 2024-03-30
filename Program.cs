//Written for games by X-Legend.
//Sprite Fantasia. https://store.steampowered.com/app/1619220/
//Eden Eternal-聖境伝説 https://store.steampowered.com/app/2229260/
//Aura Kingdom 2 https://store.steampowered.com/app/1258870/
//ASTRAL TALE-星界神話 https://store.steampowered.com/app/2591210/
//Laplace：拉普拉斯的神子 https://store.steampowered.com/app/819790/

using System.IO;
using System.IO.Compression;

namespace X_Legend_Extractor
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
