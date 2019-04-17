using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuaHangDAL;
using SubSonic;
namespace BLL
{
     public class DanhMucMager
    {
        public static List<DanHMuc> getAllDanhMuc()
        {
            return new Select().From(DanHMuc.Schema.TableName).Where(DanHMuc.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<DanHMuc>();
        }
        public static DanHMuc insert(DanHMuc item)
        {
            return new DanHMucController().Insert(item);
        }
        public static DanHMuc uppdate(DanHMuc item)
        {
            return new DanHMucController().Update(item);
        }

        public static bool destoy(int id) // xoa ;luon
        {
            return new DanHMucController().Destroy(id);
        }
        public static DanHMuc GetItemById(int? id)
        {
            return new Select().From(DanHMuc.Schema.TableName)
                .Where(DanHMuc.Columns.MaDM).IsEqualTo(id)
                .ExecuteSingle<DanHMuc>();
        }
        public static DanHMuc delete(int? id)
        {
            DanHMuc item = new Select().From(DanHMuc.Schema.TableName)
                 .Where(DanHMuc.Columns.MaDM).IsEqualTo(id)
                 .ExecuteSingle<DanHMuc>();
            item.Status = "xoa";
            return new DanHMucController().Update(item);
        }
    }
}
