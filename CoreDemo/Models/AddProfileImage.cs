using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
//Writer Entity deki alanı değiştirmek istemediğimiz için update bu class üzerinden yapıyoruz
namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        [Key]
        public int WriterId { get; set; }
        public string WriteName { get; set; }
        public string WriteAbout { get; set; }
        public IFormFile WriterImage { get; set; } //Dosya değeri seçmek için...
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterRePassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
