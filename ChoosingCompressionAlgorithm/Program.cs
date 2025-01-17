using System.IO.Compression;

namespace ChoosingCompressionAlgorithm
{
    /*
    Рассмотрим ситуацию, когда ваше приложение должно поддерживать различные методы сжатия файлов: ZIP, RAR и 7z. С помощью паттерна Стратегия вы сможете легко изменять метод компрессии файла.
    using System.IO.Compression;
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] originData = new byte[] { 1, 2, 3, 4, 5 }; // Данные для компрессии

            // Использование ZIP-компрессии
            var zipCompressor = new FileCompressor(new ZipCompression());
            byte[] compressedZipData = zipCompressor.CompressFile(originData);
            byte[] decompressedZipData = zipCompressor.DecompressFile(compressedZipData);

            // Проверка данных
            if (originData.SequenceEqual(decompressedZipData))
            {
                Console.WriteLine("ZIP-compression successfull done");
            }

            // Использование RAR-компрессии
            var rarCompressor = new FileCompressor(new RarCompression());
            byte[] compressedRarData = rarCompressor.CompressFile(originData);
            byte[] decompressedRarData = rarCompressor.DecompressFile(compressedRarData);

            // Проверка данных
            if (originData.SequenceEqual(decompressedRarData))
            {
                Console.WriteLine("RAR-compression successfull done");
            }
        }
    }

    // Интерфейс стратегии
    public interface ICompressionStrategy
    {
        byte[] Compress(byte[] data);
        byte[] Decompress(byte[] compressedData);
    }

    // Контекст
    public class FileCompressor
    {
        private readonly ICompressionStrategy _compressionStrategy;

        public FileCompressor(ICompressionStrategy compressionStrategy)
        {
            _compressionStrategy = compressionStrategy;
        }

        public byte[] CompressFile(byte[] fileData)
        {
            return _compressionStrategy.Compress(fileData);
        }

        public byte[] DecompressFile(byte[] compressedFileData)
        {
            return _compressionStrategy.Decompress(compressedFileData);
        }
    }

    // Конкретная стратегия: ZIP компрессия
    public class ZipCompression : ICompressionStrategy
    {
        public byte[] Compress(byte[] data)
        {
            using MemoryStream outputStream = new();
            using (DeflateStream compressionStream = new(outputStream, CompressionLevel.Optimal))
            {
                compressionStream.Write(data, 0, data.Length);
            }
            return outputStream.ToArray();
        }

        public byte[] Decompress(byte[] compressedData)
        {
            using MemoryStream inputStream = new(compressedData);
            using MemoryStream outputStream = new();
            using (DeflateStream decompressionStream = new(inputStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(outputStream);
            }
            return outputStream.ToArray();
        }
    }

    // Конкретная стратегия: RAR компрессия (имитируется компрессия)
    public class RarCompression : ICompressionStrategy
    {
        public byte[] Compress(byte[] data)
        {
            // Здесь можно реализовать логику для RAR-компрессии
            return data;
        }

        public byte[] Decompress(byte[] compressedData)
        {
            // Здесь можно реализовать логику для распаковки RAR-файла
            return compressedData;
        }
    }
}
