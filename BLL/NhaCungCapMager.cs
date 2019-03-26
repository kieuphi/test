using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class NhaCungCapMager
    {
        public static NhaCungCap insert(NhaCungCap item)
        {
            return new NhaCungCapController().Insert(item);
        }

        public static NhaCungCap uppdate(NhaCungCap item)
        {
            return new NhaCungCapController().Update(item);
        }

        public static bool destoy(int id)
        {
            return new TaiKhoanController().Destroy(id);
        }

        public static List<NhaCungCap> getAll()
        {
            return new Select().From(NhaCungCap.Schema.TableName).Where(NhaCungCap.Columns.Status)
                .IsNotEqualTo("xoa").ExecuteTypedList<NhaCungCap>();
        }

        public static NhaCungCap GetItemById(int id)
        {
            return new Select().From(NhaCungCap.Schema.TableName)
                .Where(NhaCungCap.Columns.MaNCC).IsEqualTo(id)
                .ExecuteSingle<NhaCungCap>();
        }

        public static NhaCungCap delete(int id)
        {
            NhaCungCap item = new Select().From(NhaCungCap.Schema.TableName)
                 .Where(NhaCungCap.Columns.MaNCC).IsEqualTo(id)
                 .ExecuteSingle<NhaCungCap>();
            item.Status = "xoa";
            return new NhaCungCapController().Update(item);
        }
    }
}