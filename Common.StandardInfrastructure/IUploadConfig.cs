using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Common.StandardInfrastructure
{
    public interface IUploadConfig
    {
        string SaveBase64(string imgBase64, string imgName, string folderName, Guid? _organizationId = null, bool imageMobile = false);
        string SaveBase64WithId(string imgBase64, string imgName, string folderName);
        string ConvertToBase64String(string fileName, string folderName, Guid? _organizationId = null);
        void RemoveFile(string fileName, string folderName, Guid? _organizationId = null);
        void RemoveFile(string fullPath);
        string SaveFile(IFormFile file, string folderName, List<string> pathAccept, string newFileName, out string fileName);
        string FileByFileName(string fileName, string folderName);
        Stream ConvertToStream(string fileName, string folderName, Guid? _organizationId = null);
        string ServerPath(string folderName = null);
        string SaveBinImage(byte[] binImage, string imageName, string folderName);
        string GetPath(string fileName, string folderName);
        byte[] ConvertToByteArray(string fileName, string folderName);

    }
}
