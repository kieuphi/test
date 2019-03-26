using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace CuaHangDAL
{
    /// <summary>
    /// Controller class for HD
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class HdController
    {
        // Preload our schema..
        Hd thisSchemaLoad = new Hd();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HdCollection FetchAll()
        {
            HdCollection coll = new HdCollection();
            Query qry = new Query(Hd.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public HdCollection FetchByID(object MaHD)
        {
            HdCollection coll = new HdCollection().Where("MaHD", MaHD).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public HdCollection FetchByQuery(Query qry)
        {
            HdCollection coll = new HdCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object MaHD)
        {
            return (Hd.Delete(MaHD) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object MaHD)
        {
            return (Hd.Destroy(MaHD) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public Hd Insert(Hd item)
	    {
		
		    item.Save(UserName);
         return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public Hd Update(Hd item2)
	    {
		    Hd item = new Hd();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.MaHD = item2.MaHD;
				
			item.NgayDat = item2.NgayDat;
				
			item.MaKH = item2.MaKH;
				
			item.MaNV = item2.MaNV;
				
			item.Status = item2.Status;
				
	        item.Save(UserName);
            return item;
	    }
    }
}