using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class SanPhamMager
    {
        public static SanPham insertSanPham(SanPham item)
        {
            return new SanPhamController().Insert(item);
        }

        public static SanPham uppdateSanPham(SanPham item)
        {
            return new SanPhamController().Update(item);
        }

        public static bool destoySanPham(int id)
        {
            return new SanPhamController().Destroy(id);
        }

        public static List<SanPham> getAllSanPham()
        {
            return new Select().From(SanPham.Schema.TableName).Where(SanPham.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<SanPham>();
        }

        public static SanPham GetSanPhamByID(int? id)
        {
            return new Select().From(SanPham.Schema.TableName)
                .Where(SanPham.Columns.Masp).IsEqualTo(id)
                .ExecuteSingle<SanPham>();
        }

        public static SanPham delete(int id)
        {
            SanPham sp = new Select().From(SanPham.Schema.TableName)
                 .Where(SanPham.Columns.Masp).IsEqualTo(id)
                 .ExecuteSingle<SanPham>();
            sp.Status = "xoa";
            return new SanPhamController().Update(sp);
        }

        public static SanPham tinhgiaban(int? id)
        {
            SanPham sp = new Select().From(SanPham.Schema.TableName)
                 .Where(SanPham.Columns.Masp).IsEqualTo(id)
                 .ExecuteSingle<SanPham>();
            int slnv = (new Select().From(NhanVien.Schema.TableName) // tinh so luong nv
                .Where(NhanVien.Columns.Status).IsNotEqualTo("xoa")
                .ExecuteTypedList<NhanVien>()).Count;
            sp.DonGiaBan = (sp.GiaNhap * (decimal)0.1) + (sp.GiaNhap * (decimal)0.3) + (sp.GiaNhap * slnv * (decimal)0.012);
            return SanPhamMager.uppdateSanPham(sp);
        }

        public static List<SanPham> GetSPbyDM(int? id)
        {
            List<SanPham> sp = new Select().From(SanPham.Schema.TableName)
                .Where(SanPham.Columns.MaDm).IsEqualTo(id).And(SanPham.Columns.Status).IsNotEqualTo("xoa")
                .ExecuteTypedList<SanPham>();
            return sp;
        }

        public static List<SanPham> GetSPbytensp(string ten)
        {
            List<SanPham> sp = new Select().From(SanPham.Schema.TableName)
                .Where(SanPham.Columns.TenSp).Like(ten).And(SanPham.Columns.Status).IsNotEqualTo("xoa")
                .ExecuteTypedList<SanPham>();
            return sp;
        }

        public static List<SanPham> GetSpByGiaNhap(decimal gia)
        {
            List<SanPham> sp = new Select().From(SanPham.Schema.TableName)
                .Where(SanPham.Columns.GiaNhap).IsBetweenAnd(gia - 100, gia + 100).And(SanPham.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<SanPham>();
            return sp;
        }

        public static void capnhapgia(int? id)
        {
            SPs.TinhgiatatcaSP(id);
    ///        SanPham sp = new Select().fro


        }

        public static decimal? pirceSP(int? id)
        {
            SanPham sp = new Select().From(SanPham.Schema.TableName)
                 .Where(SanPham.Columns.Masp).IsEqualTo(id)
                 .ExecuteSingle<SanPham>();
            return sp.DonGiaBan;
        }
        
    }
}