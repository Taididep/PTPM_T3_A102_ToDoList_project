using DTO;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CongViecDanhMucBLL
    {
        private readonly CongViecDanhMucDAL dalCongViecDanhMuc = new CongViecDanhMucDAL();

        public CongViecDanhMucBLL() { }

        public List<CongViecDanhMucDTO> GetAll()
        {
            return dalCongViecDanhMuc.GetAll();
        }
        public List<CongViecDanhMucDTO> GetByMaCongViec(int maCongViec)
        {
            return dalCongViecDanhMuc.GetByMaCongViec(maCongViec);
        }

        public List<CongViecDanhMucDTO> GetByMaDanhMuc(int maDanhMuc)
        {
            return dalCongViecDanhMuc.GetByMaDanhMuc(maDanhMuc);
        }

        public bool Insert(CongViecDanhMucDTO cvdmDTO)
        {
            return dalCongViecDanhMuc.Insert(cvdmDTO);
        }
        public bool Delete(int maCongViec, int maDanhMuc)
        {
            return dalCongViecDanhMuc.Delete(maCongViec, maDanhMuc);
        }

        public bool Update(CongViecDanhMucDTO cvdmDTO)
        {
            return dalCongViecDanhMuc.Update(cvdmDTO);
        }
    }
}
