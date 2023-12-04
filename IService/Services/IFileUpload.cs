using Microsoft.AspNetCore.Components.Forms;

namespace inventory.IService.Services
{
   public interface IFileUpload
    {
        public Task<string> UploadFile(IBrowserFile file);

        public bool DeleteFile(string filePath);

    }
}
