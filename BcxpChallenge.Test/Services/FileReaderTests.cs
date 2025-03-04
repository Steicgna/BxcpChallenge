using BcxpChallenge.Services;

namespace BcxpChallenge.Test.Services
{
    public class FileReaderTests
    {
        [Fact]
        public void GetReader_ValidFile_ReturnsStreamReader()
        {
            string filePath = "testfile.txt";
            var fileReader = new FileReader(filePath);

            TextReader reader = fileReader.GetReader();

            Assert.IsType<StreamReader>(reader);
            reader.Dispose();
        }

        [Fact]
        public void GetReader_FileNotFound_ThrowsFileNotFoundException()
        {
            string filePath = "nofile.txt";
            var fileReader = new FileReader(filePath);

            Assert.Throws<FileNotFoundException>(() => fileReader.GetReader());
        }

        [Fact]
        public void GetReader_InvalidFilePath_ThrowsException()
        {
            string filePath = "";
            FileReader fileReader = new(filePath);

            Assert.Throws<ArgumentException>(() => fileReader.GetReader());
        }
    }
}