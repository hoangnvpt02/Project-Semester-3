﻿using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);

        public Task PostMultiFileAsync(List<FileUploadModel> fileData);

        public String DownloadFileById(int fileName);

       
    }
}
