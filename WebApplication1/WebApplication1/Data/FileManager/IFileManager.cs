using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
namespace WebApplication1.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);    
            Task<string>SaveImage(IFormFile image);
    }
}
