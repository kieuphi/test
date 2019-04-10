using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class PhieuNhapMager
    {
        public static Pn insert(Pn item)
        {
            return new PnController().Insert(item);
        }

        public static Pn uppdate(Pn item)
        {
            return new PnController().Update(item);
        }

        public static bool destoy(int id) // xoa ;luon
        {
            return new PnController().Destroy(id);
        }

        public static List<Pn> getAll()
        {
            return new Select().From(Pn.Schema.TableName).Where(Pn.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<Pn>();
        }

        public static Pn GetItemById(int id)
        {
            return new Select().From(Pn.Schema.TableName)
                .Where(Pn.Columns.MaPN).IsEqualTo(id)
                .ExecuteSingle<Pn>();
        }

        public static Pn delete(int id)
        {
            Pn item = new Select().From(Pn.Schema.TableName)
                 .Where(Pn.Columns.MaPN).IsEqualTo(id)
                 .ExecuteSingle<Pn>();
            item.Status = "xoa";
            return new PnController().Update(item);
        }
        public static bool ktthamso(int? id, int? soluongnhap)
        {
            SanPham sp = new Select().From(SanPham.Schema.TableName).Where(SanPham.Columns.Masp)
                .IsEqualTo(id).ExecuteSingle<SanPham>();
            int? kq = sp.SoLuongTon + soluongnhap;
            if (kq <= sp.ThamSoN)
            {
                return true;
            }
            else return false;
        }
    }
}