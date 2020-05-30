using System;  
using NUnit.Framework;
using Dropbox_lab_test.Defenitions;
using TestDropboxApi.ApiFacade;
using Dropbox_lab_test.Auth;

namespace Dropbox_lab_test
{
    [TestFixture]
    class Tests
    {
        [SetUp]
        public void SetUp()
        {
            DotNetEnv.Env.Load("../../../../.env");
            //конечно, оно запускается только каждый раз - но работает 1))
            try
            {
                var token = ((Newtonsoft.Json.Linq.JValue)(new RequestToken().Execute().ContentAsJson["access_token"])).Value.ToString();
                //не бейте я просто не хочу менять код краденой программы
                Environment.SetEnvironmentVariable("token", "Bearer " + token);
            }
            catch { };
        }
        [Test]
        public void GetExsitingFileMetadata()
        {
            string filepath = "/";
            string filename = @"WS_Dropbox-master.zip";
            string fullpath = filepath + filename;
            ApiResponse meta1=GetFileInf.GetMeta(fullpath);
            ApiResponse meta2 = GetFileInf.GetMeta(filepath, filename);
            Assert.IsTrue(meta1.ContentAsString.Equals(meta2.ContentAsString) && meta1.IfSuccessful());
        }
        [Test]
        public void GetNonExsitingFileMetadata()
        {
            string filepath = "/";
            string filename = @"File";
            string fullpath = filepath + filename;
            ApiResponse meta1 = GetFileInf.GetMeta(fullpath);
            Assert.IsFalse(meta1.IfSuccessful());
        }
        [Test]
        public void DeleteFileTest()
        {
            string filepath = "/";
            string filename = @"Web services testing - episode 2.pptx";
            string fullpath = filepath + filename;
            DeleteFiles.UploadFile(fullpath);
            Assert.IsTrue(GetFileInf.CheckIfFileExcists(fullpath));
            DeleteFiles.DeleteFile(fullpath);
            Assert.IsFalse(GetFileInf.CheckIfFileExcists(fullpath));
        }
        
    
       
    }
}
