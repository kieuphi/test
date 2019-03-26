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
    }
}
