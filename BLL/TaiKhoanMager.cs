using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class TaiKhoanMager
    {
        public static TaiKhoan insert(TaiKhoan item)
        {
            return new TaiKhoanController().Insert(item);
        }

        public static TaiKhoan uppdate(TaiKhoan item)
        {
            return new TaiKhoanController().Update(item);
        }

        public static bool destoy(int id)
        {
            return new TaiKhoanController().Destroy(id);
        }

        public static List<TaiKhoan> getAll()
        {
            return new Select().From(TaiKhoan.Schema.TableName).Where(TaiKhoan.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<TaiKhoan>();
        }

        public static TaiKhoan GetItemById(int id)
        {
            return new Select().From(TaiKhoan.Schema.TableName)
                .Where(TaiKhoan.Columns.MaTK).IsEqualTo(id)
                .ExecuteSingle<TaiKhoan>();
        }

        public static TaiKhoan delete(int id)
        {
            TaiKhoan item = new Select().From(TaiKhoan.Schema.TableName)
                 .Where(TaiKhoan.Columns.MaTK).IsEqualTo(id)
                 .ExecuteSingle<TaiKhoan>();
            item.Status = "xoa";
            return new TaiKhoanController().Update(item);
        }

        public static TaiKhoan GetItemByTen(string id)
        {
            return new Select().From(TaiKhoan.Schema.TableName)
                .Where(TaiKhoan.Columns.TenTK).IsEqualTo(id)
                .ExecuteSingle<TaiKhoan>();
        }

        //public static TaiKhoan Login(string tk, string mk)
        //{
           
            //return new Select().From(TaiKhoan.Schema.TableName)
        //        .Where(TaiKhoan.Columns.TenTK).IsEqualTo(tk).And(TaiKhoan.Columns.MatKhau).IsEqualTo(mk)
        //        .ExecuteSingle<TaiKhoan>();
        //}
        public static bool login (string tk , string mk)
        {
            var result = new Select().From(TaiKhoan.Schema.TableName)
                .Where(TaiKhoan.Columns.TenTK).IsEqualTo(tk).And(TaiKhoan.Columns.MatKhau).IsEqualTo(mk);

            if (result.GetRecordCount() > 0)
            {
                return true;
            }
            else { return false; }
        }
        public static TaiKhoan MaHoaMK(int? id)
        {

            TaiKhoan item = new Select().From(TaiKhoan.Schema.TableName)
                 .Where(TaiKhoan.Columns.MaTK).IsEqualTo(id)
                 .ExecuteSingle<TaiKhoan>();
            item.MatKhau = Encryptormd5.MD5Hash(item.MatKhau);
            return new TaiKhoanController().Update(item);
        }
        public static NhanVien getNVbytk(int? id)
        {
            NhanVien item = new Select().From(NhanVien.Schema.TableName)
                .Where(NhanVien.Columns.MaTk).IsEqualTo(id)
                .ExecuteSingle<NhanVien>();
            return item;
        }

    }
}