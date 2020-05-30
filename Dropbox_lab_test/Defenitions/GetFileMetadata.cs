using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using Dropbox_lab_test.Api;

namespace Dropbox_lab_test.Defenitions
{
    class GetFileInf
    {
        public static ApiResponse GetMeta(string fileName)
        {
            var response = new DropboxApiLab().GetFileMeta(fileName);
            return response;
        }
        public static ApiResponse GetMeta(string path, string fileName)
        {
            var response = new DropboxApiLab().GetFileMeta(path + fileName);
            return response;

        }
        public static bool CheckIfFileExcists(string filepath)
        {
            var filesList = GetListOfFilesTest();
            foreach (var el in filesList.Entries)
            {
                if (el.PathDisplay.Equals(filepath)) return true;
            }
            return false;
        }
        public static FileListResponseDto GetListOfFilesTest()
        {
            var apiResponse = new DropboxApi().GetFilesList();
            apiResponse.EnsureSuccessful();
            var filesList = apiResponse.Content<FileListResponseDto>();
            return filesList;
        }
    }
}
