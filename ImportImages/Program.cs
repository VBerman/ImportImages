using ImportImages.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportImages
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Model1();
  
            var d = new DirectoryInfo(@"C:\Users\br_mn\Desktop\Туры фото");
            var files = d.GetFiles();
            foreach (var item in files)
            {
                var dataPicture = File.ReadAllBytes(item.FullName);
                var name = Path.GetFileNameWithoutExtension(item.FullName);
                var tour = db.Tours.Where(t => t.Name == name).FirstOrDefault();
                tour.ImagePreview = dataPicture;
                db.SaveChanges();
            }
            
            
        }
    }
}
