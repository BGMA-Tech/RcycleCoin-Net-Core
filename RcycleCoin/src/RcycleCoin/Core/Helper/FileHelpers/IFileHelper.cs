using Core.Utilities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Helper.FileHelpers
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file, string root);
        IResult Delete(string filePath);
        IResult Update(IFormFile file, string filePath, string root);
    }
}
