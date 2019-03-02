using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL_Helper
{
    public enum QueryParameterDirection : int
    {
        Input = 1,
        Output = 2,
        Return = 3
    }

    public class ProcedureExecute : IDisposable
    {
        private string strCommandText = string.Empty;
        private bool blnSP = true;
        private ArrayList oParameters = new ArrayList();
        private bool blnLocalConn = true;

        #region Constrator
        public ProcedureExecute(string StoredProcName)
            : this(StoredProcName, false)
        {

        }

        public ProcedureExecute(string SqlString, bool IsTextQuery)
        {
            blnSP = !IsTextQuery;
            strCommandText = SqlString;
        }
        #endregion

        #region DataTable
        // REturn a Datatable  
        public DataTable GetTable()
        {

            DataTable dt = null;
            SqlCommand oCmd = new SqlCommand();
            this.InitQuery(oCmd);
            oCmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();


            da.Fill(ds);
            if ((null != ds) && (ds.Tables.Count > 0))
            {
                dt = ds.Tables[0];
            }

            if (this.oConn.State == ConnectionState.Open)
            {
                this.oConn.Close();

            }
            oCmd.Dispose();


            return dt;
        }
        #endregion

        #region DataReader
        public SqlDataReader GetReader()
        {
            SqlDataReader dr = null;
            try
            {

                SqlCommand oCmd = new SqlCommand();
                this.InitQuery(oCmd);
                dr = oCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception v1)
            {
                return dr;

            }
        }
        #endregion

        #region DataSet
        // REturn a Datatable  
        public DataSet GetDataSet()
        {
            SqlCommand oCmd = new SqlCommand();
            this.InitQuery(oCmd);

            SqlDataAdapter da = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.oConn.State == ConnectionState.Open)
                {
                    this.oConn.Close();
                }
                oCmd.Dispose();
            }

            return ds;
        }
        #endregion

        #region NonQuery

        public int RunActionQuery()
        {
            int intRowsAffected = -1;

            SqlCommand oCmd = new SqlCommand();
            this.InitQuery(oCmd);

            try
            {
                intRowsAffected = oCmd.ExecuteNonQuery();
                oCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.oConn.State == ConnectionState.Open)
                {
                    this.oConn.Close();
                }
                oCmd.Dispose();
            }

            return intRowsAffected;
        }
        #endregion

        #region Scalar

        public object GetScalar()
        {
            object oRetVal = null;

            SqlCommand oCmd = new SqlCommand();
            this.InitQuery(oCmd);

            try
            {
                oRetVal = oCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.oConn.State == ConnectionState.Open)
                {
                    this.oConn.Close();
                }
                oCmd.Dispose();
            }

            return oRetVal;
        }
        #endregion

        #region Initializes a Query

        private void InitQuery(SqlCommand oCmd)
        {
            blnLocalConn = (this.oConn == null);
            if (blnLocalConn)
            {
                string conn = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                Open(conn);
                blnLocalConn = true;
            }
            oCmd.Connection = oConn;


            oCmd.CommandText = this.strCommandText;
            oCmd.CommandType = (this.blnSP ? CommandType.StoredProcedure : CommandType.Text);


            oCmd.CommandTimeout = (24 * 60 * 60);	// 1 Day

            foreach (object oItem in this.oParameters)
            {
                oCmd.Parameters.Add((SqlParameter)oItem);
            }
        }
        #endregion

        #region Parameter handling
        #region Type: Integer

        public void AddIntegerPara(string Name, int Value)
        {
            AddIntegerPara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddIntegerPara(string Name, int? Value, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Int);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = Value;
            this.oParameters.Add(oPara);
        }
        public void AddIntegerNullPara(string Name)
        {
            AddIntegerNullPara(Name, QueryParameterDirection.Input);
        }
        public void AddIntegerNullPara(string Name, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Int);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = DBNull.Value;
            this.oParameters.Add(oPara);
        }

        #endregion

        #region Type: BigInt

        public void AddBigIntegerPara(string Name, long Value)
        {
            AddBigIntegerPara(Name, Value, QueryParameterDirection.Input);
        }


        public void AddBigIntegerPara(string Name, long Value, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.BigInt);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = Value;
            this.oParameters.Add(oPara);
        }
        public void AddBigIntegerNullPara(string Name)
        {
            AddIntegerNullPara(Name, QueryParameterDirection.Input);
        }
        public void AddBigIntegerNullPara(string Name, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Int);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = DBNull.Value;
            this.oParameters.Add(oPara);
        }

        #endregion

        #region Type: Char

        public void AddCharPara(string Name, int Size, char Value)
        {
            AddCharPara(Name, Size, Value, QueryParameterDirection.Input);
        }

        public void AddCharPara(string Name, int Size, char Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value.Equals(null))
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Char, Size);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: NChar

        public void AddNCharPara(string Name, int Size, char Value)
        {
            AddNCharPara(Name, Size, Value, QueryParameterDirection.Input);
        }

        public void AddNCharPara(string Name, int Size, char Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value.Equals(null))
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.NChar, Size);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: Varchar

        public void AddVarcharPara(string Name, int Size, string Value)
        {
            AddVarcharPara(Name, Size, Value, QueryParameterDirection.Input);
        }

        public void AddVarcharPara(string Name, int Size, string Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
            {
                oValue = DBNull.Value;
            }

            SqlParameter oPara = new SqlParameter(Name, SqlDbType.VarChar, Size);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: NVarchar

        public void AddNVarcharPara(string Name, int Size, string Value)
        {
            AddNVarcharPara(Name, Size, Value, QueryParameterDirection.Input);
        }

        public void AddNVarcharPara(string Name, int Size, string Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.NVarChar, Size);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: Boolean

        public void AddBooleanPara(string Name, bool Value)
        {
            AddBooleanPara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddBooleanPara(string Name, bool Value, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Bit);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = Value;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: DateTime

        public void AddDateTimePara(string Name, DateTime Value)
        {
            AddDateTimePara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddDateTimePara(string Name, DateTime Value, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.DateTime);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = Value;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: Text

        public void AddTextPara(string Name, string Value)
        {
            AddTextPara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddTextPara(string Name, string Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Text);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: NText

        public void AddNTextPara(string Name, string Value)
        {
            AddNTextPara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddNTextPara(string Name, string Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.NText);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: Decimal

        public void AddDecimalPara(string Name, byte Scale, byte Precision, decimal Value)
        {
            AddDecimalPara(Name, Scale, Precision, Value, QueryParameterDirection.Input);
        }

        public void AddDecimalPara(string Name, byte Scale, byte Precision, decimal Value, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Decimal);
            oPara.Scale = Scale;
            oPara.Precision = Precision;
            oPara.Direction = GetParaType(Direction);
            oPara.Value = Value;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: Image

        public void AddImagePara(string Name, byte[] Value)
        {
            AddImagePara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddImagePara(string Name, byte[] Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Image);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: XML

        public void AddXMLPara(string Name, string Value)
        {
            AddXMLPara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddXMLPara(string Name, string Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
                oValue = DBNull.Value;

            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Xml);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Type: Structure
        public void AddStructurePara(string Name, DataTable Value)
        {
            AddStructurePara(Name, Value, QueryParameterDirection.Input);
        }

        public void AddStructurePara(string Name, DataTable Value, QueryParameterDirection Direction)
        {
            object oValue = (object)Value;
            if (Value == null)
            {
                oValue = DBNull.Value;
            }
            SqlParameter oPara = new SqlParameter(Name, SqlDbType.Structured);
            oPara.Direction = GetParaType(Direction);
            oPara.Value = oValue;
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Adds a NULL value Parameter

        public void AddNullValuePara(string Name)
        {
            SqlParameter oPara = new SqlParameter(Name, DBNull.Value);
            oPara.Direction = ParameterDirection.Input;
            this.oParameters.Add(oPara);
        }


        public void AddNullValuePara(string Name, QueryParameterDirection Direction)
        {
            SqlParameter oPara = new SqlParameter(Name, DBNull.Value);
            oPara.Direction = GetParaType(Direction);
            this.oParameters.Add(oPara);
        }
        #endregion

        #region Adds the Return Parameter

        public void AddReturnPara()
        {
            this.AddIntegerPara("ReturnIntPara", 0, QueryParameterDirection.Return);
        }
        #endregion

        #region Returns the value of the passed parameter

        public object GetParaValue(string ParaName)
        {
            object oValue = null;
            SqlParameter oPara = null;

            ParaName = ParaName.Trim().ToLower();
            foreach (object oItem in this.oParameters)
            {
                oPara = (SqlParameter)oItem;
                if (oPara.ParameterName.ToLower() == ParaName)
                {
                    oValue = oPara.Value;
                    break;
                }
            }

            return oValue;
        }
        #endregion

        #region Returns the value of the Return Parameter

        public object GetReturnParaValue()
        {
            return this.GetParaValue("ReturnIntPara");
        }
        #endregion

        #region Clears the parameters

        public void ClearParameters()
        {
            this.oParameters.Clear();
        }
        #endregion

        #region Converts enum to parameter direction

        private ParameterDirection GetParaType(QueryParameterDirection Direction)
        {
            switch (Direction)
            {
                case QueryParameterDirection.Output:
                    return ParameterDirection.InputOutput;
                case QueryParameterDirection.Return:
                    return ParameterDirection.ReturnValue;
                default:
                    return ParameterDirection.Input;
            }
        }
        #endregion
        #endregion

        #region Dispose

        public void Dispose()
        {
            this.oConn.Dispose();
            this.oParameters.Clear();
        }
        #endregion

        #region Opens a connection

        public bool Open(string ConnectionString)
        {
            blnIsOpen = false;
            oConn = new SqlConnection(ConnectionString);
            oConn.Open();
            blnIsOpen = true;
            return blnIsOpen;
        }
        #endregion

        #region Connection
        private SqlConnection oConn = null;

        public SqlConnection Connection
        {
            set
            {
                oConn = value;
            }
        }
        #endregion

        #region IsOpen
        private bool blnIsOpen = false;

        public bool IsOpen
        {
            get
            {
                return blnIsOpen;
            }
        }
        #endregion

    }
}
