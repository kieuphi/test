using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class KhachHangMager
    {
        public static KhachHang insertKhachhang(KhachHang kh)
        {
            return new KhachHangController().Insert(kh);
        }

        public static KhachHang uppdateKhachHang(KhachHang kh)
        {
            return new KhachHangController().Update(kh);
        }

        public static KhachHang GetKhachHangByID(int? id)
        {
            return new Select().From(KhachHang.Schema.TableName).Where(KhachHang.Columns.MaKh).IsEqualTo(id)
                .ExecuteSingle<KhachHang>();
        }

        public static List<KhachHang> GetAllKhachHang()
        {
            return new Select().From(KhachHang.Schema.TableName).ExecuteTypedList<KhachHang>();
        }

        public static bool DeleteKhachHang(int? id)
        {
            return new KhachHangController().Destroy(id);
        }
        public static KhachHang saveTK(int id, int tk)
        {
            KhachHang item = new Select().From(KhachHang.Schema.TableName)
                .Where(KhachHang.Columns.MaKh).IsEqualTo(id)
                .ExecuteSingle<KhachHang>();
            item.MaTk = tk;
            return new KhachHangController().Update(item);
        }
    }
}