using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class NhanVienMager
    {
        public static NhanVien insert(NhanVien item)
        {
            return new NhanVienController().Insert(item);
        }

        public static NhanVien uppdate(NhanVien item)
        {
            return new NhanVienController().Update(item);
        }

        public static bool destoy(int id)
        {
            return new NhanVienController().Destroy(id);
        }

        public static List<NhanVien> getAll()
        {
            return new Select().From(NhanVien.Schema.TableName).Where(NhanVien.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<NhanVien>();
        }

        public static NhanVien GetItemById(int? id)
        {
            return new Select().From(NhanVien.Schema.TableName)
                .Where(NhanVien.Columns.MaNV).IsEqualTo(id)
                .ExecuteSingle<NhanVien>();
        }

        public static NhanVien delete(int? id)
        {
            NhanVien item = new Select().From(NhanVien.Schema.TableName)
                 .Where(NhanVien.Columns.MaNV).IsEqualTo(id)
                 .ExecuteSingle<NhanVien>();
            item.Status = "xoa";
            return new NhanVienController().Update(item);
        }
        public static NhanVien saveTK(int id,int tk)
        {
            NhanVien item = new Select().From(NhanVien.Schema.TableName)
                .Where(NhanVien.Columns.MaNV).IsEqualTo(id)
                .ExecuteSingle<NhanVien>();
            item.MaTk = tk;
            return new NhanVienController().Update(item);
        }
        public static NhanVien GetbyTK(int id)
        {
            NhanVien item = new Select().From(NhanVien.Schema.TableName)
                .Where(NhanVien.Columns.MaTk).IsEqualTo(id)
                .ExecuteSingle<NhanVien>();
            return item;
        }

    }
}