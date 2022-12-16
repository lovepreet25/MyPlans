namespace MyPlansLibrary.Models
{
    public class FormFile
    {
        public  FormFile(Stream fileStream, string fileName) 

        { 
            FileStream = fileStream;
            FileName= fileName;
        }  
        public string FileName { get; set; }
        public Stream FileStream { get; set; }

    }
}