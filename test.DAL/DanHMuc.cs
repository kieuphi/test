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
	/// Strongly-typed collection for the DanHMuc class.
	/// </summary>
    [Serializable]
	public partial class DanHMucCollection : ActiveList<DanHMuc, DanHMucCollection>
	{	   
		public DanHMucCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DanHMucCollection</returns>
		public DanHMucCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DanHMuc o = this[i];
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
	/// This is an ActiveRecord class which wraps the DanHMuc table.
	/// </summary>
	[Serializable]
	public partial class DanHMuc : ActiveRecord<DanHMuc>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DanHMuc()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DanHMuc(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DanHMuc(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DanHMuc(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DanHMuc", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMaDM = new TableSchema.TableColumn(schema);
				colvarMaDM.ColumnName = "MaDM";
				colvarMaDM.DataType = DbType.Int32;
				colvarMaDM.MaxLength = 0;
				colvarMaDM.AutoIncrement = true;
				colvarMaDM.IsNullable = false;
				colvarMaDM.IsPrimaryKey = true;
				colvarMaDM.IsForeignKey = false;
				colvarMaDM.IsReadOnly = false;
				colvarMaDM.DefaultSetting = @"";
				colvarMaDM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaDM);
				
				TableSchema.TableColumn colvarTenDM = new TableSchema.TableColumn(schema);
				colvarTenDM.ColumnName = "TenDM";
				colvarTenDM.DataType = DbType.String;
				colvarTenDM.MaxLength = 255;
				colvarTenDM.AutoIncrement = false;
				colvarTenDM.IsNullable = true;
				colvarTenDM.IsPrimaryKey = false;
				colvarTenDM.IsForeignKey = false;
				colvarTenDM.IsReadOnly = false;
				colvarTenDM.DefaultSetting = @"";
				colvarTenDM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTenDM);
				
				TableSchema.TableColumn colvarNgaycapnhap = new TableSchema.TableColumn(schema);
				colvarNgaycapnhap.ColumnName = "ngaycapnhap";
				colvarNgaycapnhap.DataType = DbType.DateTime;
				colvarNgaycapnhap.MaxLength = 0;
				colvarNgaycapnhap.AutoIncrement = false;
				colvarNgaycapnhap.IsNullable = true;
				colvarNgaycapnhap.IsPrimaryKey = false;
				colvarNgaycapnhap.IsForeignKey = false;
				colvarNgaycapnhap.IsReadOnly = false;
				colvarNgaycapnhap.DefaultSetting = @"";
				colvarNgaycapnhap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgaycapnhap);
				
				TableSchema.TableColumn colvarMaNVchinhsua = new TableSchema.TableColumn(schema);
				colvarMaNVchinhsua.ColumnName = "MaNVchinhsua";
				colvarMaNVchinhsua.DataType = DbType.Int32;
				colvarMaNVchinhsua.MaxLength = 0;
				colvarMaNVchinhsua.AutoIncrement = false;
				colvarMaNVchinhsua.IsNullable = true;
				colvarMaNVchinhsua.IsPrimaryKey = false;
				colvarMaNVchinhsua.IsForeignKey = true;
				colvarMaNVchinhsua.IsReadOnly = false;
				colvarMaNVchinhsua.DefaultSetting = @"";
				
					colvarMaNVchinhsua.ForeignKeyTableName = "NhanVien";
				schema.Columns.Add(colvarMaNVchinhsua);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("DanHMuc",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("MaDM")]
		[Bindable(true)]
		public int MaDM 
		{
			get { return GetColumnValue<int>(Columns.MaDM); }
			set { SetColumnValue(Columns.MaDM, value); }
		}
		  
		[XmlAttribute("TenDM")]
		[Bindable(true)]
		public string TenDM 
		{
			get { return GetColumnValue<string>(Columns.TenDM); }
			set { SetColumnValue(Columns.TenDM, value); }
		}
		  
		[XmlAttribute("Ngaycapnhap")]
		[Bindable(true)]
		public DateTime? Ngaycapnhap 
		{
			get { return GetColumnValue<DateTime?>(Columns.Ngaycapnhap); }
			set { SetColumnValue(Columns.Ngaycapnhap, value); }
		}
		  
		[XmlAttribute("MaNVchinhsua")]
		[Bindable(true)]
		public int? MaNVchinhsua 
		{
			get { return GetColumnValue<int?>(Columns.MaNVchinhsua); }
			set { SetColumnValue(Columns.MaNVchinhsua, value); }
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
        
		
		public CuaHangDAL.SanPhamCollection SanPhamRecords()
		{
			return new CuaHangDAL.SanPhamCollection().Where(SanPham.Columns.MaDm, MaDM).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a NhanVien ActiveRecord object related to this DanHMuc
		/// 
		/// </summary>
		public CuaHangDAL.NhanVien NhanVien
		{
			get { return CuaHangDAL.NhanVien.FetchByID(this.MaNVchinhsua); }
			set { SetColumnValue("MaNVchinhsua", value.MaNV); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTenDM,DateTime? varNgaycapnhap,int? varMaNVchinhsua,string varStatus)
		{
			DanHMuc item = new DanHMuc();
			
			item.TenDM = varTenDM;
			
			item.Ngaycapnhap = varNgaycapnhap;
			
			item.MaNVchinhsua = varMaNVchinhsua;
			
			item.Status = varStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varMaDM,string varTenDM,DateTime? varNgaycapnhap,int? varMaNVchinhsua,string varStatus)
		{
			DanHMuc item = new DanHMuc();
			
				item.MaDM = varMaDM;
			
				item.TenDM = varTenDM;
			
				item.Ngaycapnhap = varNgaycapnhap;
			
				item.MaNVchinhsua = varMaNVchinhsua;
			
				item.Status = varStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn MaDMColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TenDMColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NgaycapnhapColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MaNVchinhsuaColumn
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
			 public static string MaDM = @"MaDM";
			 public static string TenDM = @"TenDM";
			 public static string Ngaycapnhap = @"ngaycapnhap";
			 public static string MaNVchinhsua = @"MaNVchinhsua";
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
