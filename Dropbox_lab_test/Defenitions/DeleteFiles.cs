using System;
using System.IO;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;
using FluentAssertions;
using System.Reflection;
using TestDropboxApi.Extensions;
using Dropbox_lab_test.Api;

namespace Dropbox_lab_test.Defenitions
{
    class DeleteFiles
    {
        private static string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                              + Path.DirectorySeparatorChar
                              + ConfigurationHelper.DefaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));
            return fullPath;
        }
        public static void UploadFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            File.Exists(filePath)
                .Should()
                .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");
            var uploadFile = new UploadFileDto();
            uploadFile.Mode = "add";
            uploadFile.AutoRename = true;
            uploadFile.Mute = false;
            uploadFile.Path = fileName;
            var file = File.ReadAllBytes(filePath);
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
        }
        public static void DeleteFile( string fileName)
        {
            var response = new DropboxApiLab().DeleteFile(fileName);
            response.EnsureSuccessful();


        }

    }
}
