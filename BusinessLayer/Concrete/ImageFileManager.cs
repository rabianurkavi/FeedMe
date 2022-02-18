using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ımageFileDal;
        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }
        public ImageFile GetById(int id)
        {
            return _ımageFileDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _ımageFileDal.List();
        }

        public void ImageFileAdd(ImageFile ımageFile)
        {
            _ımageFileDal.Insert(ımageFile);
        }

        public void ImageFileDelete(ImageFile ımageFile)
        {
            _ımageFileDal.Delete(ımageFile);
        }

        public void ImageFileUpdate(ImageFile ımageFile)
        {
            _ımageFileDal.Update(ımageFile);
        }
    }
}
