using CuaHangDAL;
using SubSonic;
using System.Collections.Generic;

namespace BLL
{
    public class CtPnMager
    {
        public static Ctpn insert(Ctpn item)
        {
            return new CtpnController().Insert(item);
        }
        public static IEnumerable<Ctpn> insertall (IEnumerable<Ctpn> lst)
        {
            foreach( var item in lst)
            {
                CtPnMager.insert(item);
            }
            return lst;
        }
        public static Ctpn uppdate(Ctpn item)
        {
            return new CtpnController().Update(item);
        }

        public static bool destoy(int id) // xoa ;luon
        {
            return new CtpnController().Destroy(id);
        }

    
        public static Ctpn GetItemById(int id)
        {
            return new Select().From(Ctpn.Schema.TableName)
                .Where(Ctpn.Columns.MaCTPn).IsEqualTo(id)
                .ExecuteSingle<Ctpn>();
        }
        public static List<Ctpn> GetItembyMapn(int? id)
        {
            return new Select().From(Ctpn.Schema.TableName)
                .Where(Ctpn.Columns.MaPN).IsEqualTo(id)
                .ExecuteTypedList<Ctpn>();
        }
        public static List<Ctpn> getAll()
        {
            return new Select().From(Ctpn.Schema.TableName)
                .ExecuteTypedList<Ctpn>();
        }
    }
}