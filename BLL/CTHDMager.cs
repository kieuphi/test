using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class CTHDMager
    {
        public static Cthd insert(Cthd item)
        {
            return new CthdController().Insert(item);
        }

        public static Cthd uppdate(Cthd item)
        {
            return new CthdController().Update(item);
        }

        public static bool destoy(int id) // xoa ;luon
        {
            return new CthdController().Destroy(id);
        }

        public static List<Cthd> getAll()
        {
            return new Select().From(Cthd.Schema.TableName)
                .ExecuteTypedList<Cthd>();
        }

        public static Cthd GetItemById(int id)
        {
            return new Select().From(Cthd.Schema.TableName)
                .Where(Cthd.Columns.MaCTHd).IsEqualTo(id)
                .ExecuteSingle<Cthd>();
        }
        public static List<Cthd> GetItembyMaHD(int? id)
        {
            return new Select().From(Cthd.Schema.TableName)
                .Where(Cthd.Columns.MaHD).IsEqualTo(id)
                .ExecuteTypedList<Cthd>();
        }


    }
}