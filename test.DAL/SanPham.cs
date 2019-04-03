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
	/// Strongly-typed collection for the SanPham class.
	/// </summary>
    [Serializable]
	public partial class SanPhamCollection : ActiveList<SanPham, SanPhamCollection>
	{	   
		public SanPhamCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SanPhamCollection</returns>
		public SanPhamCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SanPham o = this[i];
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
	/// This is an ActiveRecord class which wraps the SanPham table.
	/// </summary>
	[Serializable]
	public partial class SanPham : ActiveRecord<SanPham>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SanPham()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SanPham(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SanPham(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SanPham(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SanPham", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMasp = new TableSchema.TableColumn(schema);
				colvarMasp.ColumnName = "Masp";
				colvarMasp.DataType = DbType.Int32;
				colvarMasp.MaxLength = 0;
				colvarMasp.AutoIncrement = true;
				colvarMasp.IsNullable = false;
				colvarMasp.IsPrimaryKey = true;
				colvarMasp.IsForeignKey = false;
				colvarMasp.IsReadOnly = false;
				colvarMasp.DefaultSetting = @"";
				colvarMasp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMasp);
				
				TableSchema.TableColumn colvarTenSp = new TableSchema.TableColumn(schema);
				colvarTenSp.ColumnName = "TenSp";
				colvarTenSp.DataType = DbType.String;
				colvarTenSp.MaxLength = 255;
				colvarTenSp.AutoIncrement = false;
				colvarTenSp.IsNullable = true;
				colvarTenSp.IsPrimaryKey = false;
				colvarTenSp.IsForeignKey = false;
				colvarTenSp.IsReadOnly = false;
				colvarTenSp.DefaultSetting = @"";
				colvarTenSp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTenSp);
				
				TableSchema.TableColumn colvarGiaNhap = new TableSchema.TableColumn(schema);
				colvarGiaNhap.ColumnName = "GiaNhap";
				colvarGiaNhap.DataType = DbType.Decimal;
				colvarGiaNhap.MaxLength = 0;
				colvarGiaNhap.AutoIncrement = false;
				colvarGiaNhap.IsNullable = true;
				colvarGiaNhap.IsPrimaryKey = false;
				colvarGiaNhap.IsForeignKey = false;
				colvarGiaNhap.IsReadOnly = false;
				colvarGiaNhap.DefaultSetting = @"";
				colvarGiaNhap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGiaNhap);
				
				TableSchema.TableColumn colvarSoLuongTon = new TableSchema.TableColumn(schema);
				colvarSoLuongTon.ColumnName = "SoLuongTon";
				colvarSoLuongTon.DataType = DbType.Int32;
				colvarSoLuongTon.MaxLength = 0;
				colvarSoLuongTon.AutoIncrement = false;
				colvarSoLuongTon.IsNullable = true;
				colvarSoLuongTon.IsPrimaryKey = false;
				colvarSoLuongTon.IsForeignKey = false;
				colvarSoLuongTon.IsReadOnly = false;
				colvarSoLuongTon.DefaultSetting = @"";
				colvarSoLuongTon.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSoLuongTon);
				
				TableSchema.TableColumn colvarMaDm = new TableSchema.TableColumn(schema);
				colvarMaDm.ColumnName = "MaDm";
				colvarMaDm.DataType = DbType.Int32;
				colvarMaDm.MaxLength = 0;
				colvarMaDm.AutoIncrement = false;
				colvarMaDm.IsNullable = true;
				colvarMaDm.IsPrimaryKey = false;
				colvarMaDm.IsForeignKey = true;
				colvarMaDm.IsReadOnly = false;
				colvarMaDm.DefaultSetting = @"";
				
					colvarMaDm.ForeignKeyTableName = "DanHMuc";
				schema.Columns.Add(colvarMaDm);
				
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
				
				TableSchema.TableColumn colvarHinhanh = new TableSchema.TableColumn(schema);
				colvarHinhanh.ColumnName = "hinhanh";
				colvarHinhanh.DataType = DbType.AnsiString;
				colvarHinhanh.MaxLength = 50;
				colvarHinhanh.AutoIncrement = false;
				colvarHinhanh.IsNullable = true;
				colvarHinhanh.IsPrimaryKey = false;
				colvarHinhanh.IsForeignKey = false;
				colvarHinhanh.IsReadOnly = false;
				colvarHinhanh.DefaultSetting = @"";
				colvarHinhanh.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHinhanh);
				
				TableSchema.TableColumn colvarDonGiaBan = new TableSchema.TableColumn(schema);
				colvarDonGiaBan.ColumnName = "DonGiaBan";
				colvarDonGiaBan.DataType = DbType.Decimal;
				colvarDonGiaBan.MaxLength = 0;
				colvarDonGiaBan.AutoIncrement = false;
				colvarDonGiaBan.IsNullable = true;
				colvarDonGiaBan.IsPrimaryKey = false;
				colvarDonGiaBan.IsForeignKey = false;
				colvarDonGiaBan.IsReadOnly = false;
				colvarDonGiaBan.DefaultSetting = @"";
				colvarDonGiaBan.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDonGiaBan);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("SanPham",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Masp")]
		[Bindable(true)]
		public int Masp 
		{
			get { return GetColumnValue<int>(Columns.Masp); }
			set { SetColumnValue(Columns.Masp, value); }
		}
		  
		[XmlAttribute("TenSp")]
		[Bindable(true)]
		public string TenSp 
		{
			get { return GetColumnValue<string>(Columns.TenSp); }
			set { SetColumnValue(Columns.TenSp, value); }
		}
		  
		[XmlAttribute("GiaNhap")]
		[Bindable(true)]
		public decimal? GiaNhap 
		{
			get { return GetColumnValue<decimal?>(Columns.GiaNhap); }
			set { SetColumnValue(Columns.GiaNhap, value); }
		}
		  
		[XmlAttribute("SoLuongTon")]
		[Bindable(true)]
		public int? SoLuongTon 
		{
			get { return GetColumnValue<int?>(Columns.SoLuongTon); }
			set { SetColumnValue(Columns.SoLuongTon, value); }
		}
		  
		[XmlAttribute("MaDm")]
		[Bindable(true)]
		public int? MaDm 
		{
			get { return GetColumnValue<int?>(Columns.MaDm); }
			set { SetColumnValue(Columns.MaDm, value); }
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
		  
		[XmlAttribute("Hinhanh")]
		[Bindable(true)]
		public string Hinhanh 
		{
			get { return GetColumnValue<string>(Columns.Hinhanh); }
			set { SetColumnValue(Columns.Hinhanh, value); }
		}
		  
		[XmlAttribute("DonGiaBan")]
		[Bindable(true)]
		public decimal? DonGiaBan 
		{
			get { return GetColumnValue<decimal?>(Columns.DonGiaBan); }
			set { SetColumnValue(Columns.DonGiaBan, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CuaHangDAL.ChiTietSpCollection ChiTietSpRecords()
		{
			return new CuaHangDAL.ChiTietSpCollection().Where(ChiTietSp.Columns.Masp, Masp).Load();
		}
		public CuaHangDAL.CthdCollection CthdRecords()
		{
			return new CuaHangDAL.CthdCollection().Where(Cthd.Columns.MaSp, Masp).Load();
		}
		public CuaHangDAL.CtpnCollection CtpnRecords()
		{
			return new CuaHangDAL.CtpnCollection().Where(Ctpn.Columns.MaSp, Masp).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a DanHMuc ActiveRecord object related to this SanPham
		/// 
		/// </summary>
		public CuaHangDAL.DanHMuc DanHMuc
		{
			get { return CuaHangDAL.DanHMuc.FetchByID(this.MaDm); }
			set { SetColumnValue("MaDm", value.MaDM); }
		}
		
		
		/// <summary>
		/// Returns a NhanVien ActiveRecord object related to this SanPham
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
		public static void Insert(string varTenSp,decimal? varGiaNhap,int? varSoLuongTon,int? varMaDm,DateTime? varNgaycapnhap,int? varMaNVchinhsua,string varStatus,string varHinhanh,decimal? varDonGiaBan)
		{
			SanPham item = new SanPham();
			
			item.TenSp = varTenSp;
			
			item.GiaNhap = varGiaNhap;
			
			item.SoLuongTon = varSoLuongTon;
			
			item.MaDm = varMaDm;
			
			item.Ngaycapnhap = varNgaycapnhap;
			
			item.MaNVchinhsua = varMaNVchinhsua;
			
			item.Status = varStatus;
			
			item.Hinhanh = varHinhanh;
			
			item.DonGiaBan = varDonGiaBan;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varMasp,string varTenSp,decimal? varGiaNhap,int? varSoLuongTon,int? varMaDm,DateTime? varNgaycapnhap,int? varMaNVchinhsua,string varStatus,string varHinhanh,decimal? varDonGiaBan)
		{
			SanPham item = new SanPham();
			
				item.Masp = varMasp;
			
				item.TenSp = varTenSp;
			
				item.GiaNhap = varGiaNhap;
			
				item.SoLuongTon = varSoLuongTon;
			
				item.MaDm = varMaDm;
			
				item.Ngaycapnhap = varNgaycapnhap;
			
				item.MaNVchinhsua = varMaNVchinhsua;
			
				item.Status = varStatus;
			
				item.Hinhanh = varHinhanh;
			
				item.DonGiaBan = varDonGiaBan;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn MaspColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TenSpColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn GiaNhapColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SoLuongTonColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MaDmColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NgaycapnhapColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MaNVchinhsuaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn HinhanhColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DonGiaBanColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Masp = @"Masp";
			 public static string TenSp = @"TenSp";
			 public static string GiaNhap = @"GiaNhap";
			 public static string SoLuongTon = @"SoLuongTon";
			 public static string MaDm = @"MaDm";
			 public static string Ngaycapnhap = @"ngaycapnhap";
			 public static string MaNVchinhsua = @"MaNVchinhsua";
			 public static string Status = @"status";
			 public static string Hinhanh = @"hinhanh";
			 public static string DonGiaBan = @"DonGiaBan";
						
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
