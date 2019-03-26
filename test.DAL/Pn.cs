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
	/// Strongly-typed collection for the Pn class.
	/// </summary>
    [Serializable]
	public partial class PnCollection : ActiveList<Pn, PnCollection>
	{	   
		public PnCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCollection</returns>
		public PnCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Pn o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the PN table.
	/// </summary>
	[Serializable]
	public partial class Pn : ActiveRecord<Pn>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Pn()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Pn(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Pn(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Pn(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("PN", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMaPN = new TableSchema.TableColumn(schema);
				colvarMaPN.ColumnName = "MaPN";
				colvarMaPN.DataType = DbType.Int32;
				colvarMaPN.MaxLength = 0;
				colvarMaPN.AutoIncrement = true;
				colvarMaPN.IsNullable = false;
				colvarMaPN.IsPrimaryKey = true;
				colvarMaPN.IsForeignKey = false;
				colvarMaPN.IsReadOnly = false;
				colvarMaPN.DefaultSetting = @"";
				colvarMaPN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaPN);
				
				TableSchema.TableColumn colvarNgayNhap = new TableSchema.TableColumn(schema);
				colvarNgayNhap.ColumnName = "NgayNhap";
				colvarNgayNhap.DataType = DbType.DateTime;
				colvarNgayNhap.MaxLength = 0;
				colvarNgayNhap.AutoIncrement = false;
				colvarNgayNhap.IsNullable = true;
				colvarNgayNhap.IsPrimaryKey = false;
				colvarNgayNhap.IsForeignKey = false;
				colvarNgayNhap.IsReadOnly = false;
				colvarNgayNhap.DefaultSetting = @"";
				colvarNgayNhap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgayNhap);
				
				TableSchema.TableColumn colvarMaNCC = new TableSchema.TableColumn(schema);
				colvarMaNCC.ColumnName = "MaNCC";
				colvarMaNCC.DataType = DbType.Int32;
				colvarMaNCC.MaxLength = 0;
				colvarMaNCC.AutoIncrement = false;
				colvarMaNCC.IsNullable = true;
				colvarMaNCC.IsPrimaryKey = false;
				colvarMaNCC.IsForeignKey = true;
				colvarMaNCC.IsReadOnly = false;
				colvarMaNCC.DefaultSetting = @"";
				
					colvarMaNCC.ForeignKeyTableName = "NhaCungCap";
				schema.Columns.Add(colvarMaNCC);
				
				TableSchema.TableColumn colvarMaNV = new TableSchema.TableColumn(schema);
				colvarMaNV.ColumnName = "MaNV";
				colvarMaNV.DataType = DbType.Int32;
				colvarMaNV.MaxLength = 0;
				colvarMaNV.AutoIncrement = false;
				colvarMaNV.IsNullable = true;
				colvarMaNV.IsPrimaryKey = false;
				colvarMaNV.IsForeignKey = true;
				colvarMaNV.IsReadOnly = false;
				colvarMaNV.DefaultSetting = @"";
				
					colvarMaNV.ForeignKeyTableName = "NhanVien";
				schema.Columns.Add(colvarMaNV);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "status";
				colvarStatus.DataType = DbType.String;
				colvarStatus.MaxLength = 50;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"('trong')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("PN",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("MaPN")]
		[Bindable(true)]
		public int MaPN 
		{
			get { return GetColumnValue<int>(Columns.MaPN); }
			set { SetColumnValue(Columns.MaPN, value); }
		}
		  
		[XmlAttribute("NgayNhap")]
		[Bindable(true)]
		public DateTime? NgayNhap 
		{
			get { return GetColumnValue<DateTime?>(Columns.NgayNhap); }
			set { SetColumnValue(Columns.NgayNhap, value); }
		}
		  
		[XmlAttribute("MaNCC")]
		[Bindable(true)]
		public int? MaNCC 
		{
			get { return GetColumnValue<int?>(Columns.MaNCC); }
			set { SetColumnValue(Columns.MaNCC, value); }
		}
		  
		[XmlAttribute("MaNV")]
		[Bindable(true)]
		public int? MaNV 
		{
			get { return GetColumnValue<int?>(Columns.MaNV); }
			set { SetColumnValue(Columns.MaNV, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CuaHangDAL.CtpnCollection CtpnRecords()
		{
			return new CuaHangDAL.CtpnCollection().Where(Ctpn.Columns.MaPN, MaPN).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a NhaCungCap ActiveRecord object related to this Pn
		/// 
		/// </summary>
		public CuaHangDAL.NhaCungCap NhaCungCap
		{
			get { return CuaHangDAL.NhaCungCap.FetchByID(this.MaNCC); }
			set { SetColumnValue("MaNCC", value.MaNCC); }
		}
		
		
		/// <summary>
		/// Returns a NhanVien ActiveRecord object related to this Pn
		/// 
		/// </summary>
		public CuaHangDAL.NhanVien NhanVien
		{
			get { return CuaHangDAL.NhanVien.FetchByID(this.MaNV); }
			set { SetColumnValue("MaNV", value.MaNV); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime? varNgayNhap,int? varMaNCC,int? varMaNV,string varStatus)
		{
			Pn item = new Pn();
			
			item.NgayNhap = varNgayNhap;
			
			item.MaNCC = varMaNCC;
			
			item.MaNV = varMaNV;
			
			item.Status = varStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varMaPN,DateTime? varNgayNhap,int? varMaNCC,int? varMaNV,string varStatus)
		{
			Pn item = new Pn();
			
				item.MaPN = varMaPN;
			
				item.NgayNhap = varNgayNhap;
			
				item.MaNCC = varMaNCC;
			
				item.MaNV = varMaNV;
			
				item.Status = varStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn MaPNColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NgayNhapColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MaNCCColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MaNVColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string MaPN = @"MaPN";
			 public static string NgayNhap = @"NgayNhap";
			 public static string MaNCC = @"MaNCC";
			 public static string MaNV = @"MaNV";
			 public static string Status = @"status";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}