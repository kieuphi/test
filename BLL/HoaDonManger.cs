using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class HoaDonManger
    {
        public static Hd insert(Hd item)
        {
            return new HdController().Insert(item);
        }

        public static Hd uppdate(Hd item)
        {
            return new HdController().Update(item);
        }

        public static bool destoy(int id) // xoa ;luon
        {
            return new HdController().Destroy(id);
        }

        public static List<Hd> getAll()
        {
            return new Select().From(Hd.Schema.TableName).Where(Hd.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<Hd>();
        }

        public static Hd GetItemById(int? id)
        {
            return new Select().From(Hd.Schema.TableName)
                .Where(Hd.Columns.MaHD).IsEqualTo(id)
                .ExecuteSingle<Hd>();
        }

        public static Hd delete(int? id)
        {
            Hd item = new Select().From(Hd.Schema.TableName)
                 .Where(Hd.Columns.MaHD).IsEqualTo(id)
                 .ExecuteSingle<Hd>();
            item.Status = "xoa";
            return new HdController().Update(item);
        }
    }
}