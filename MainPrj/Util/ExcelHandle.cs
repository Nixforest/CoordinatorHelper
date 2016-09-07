using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace MainPrj.Util
{
    public static class ExcelHandle
    {
        private const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=<FILENAME>;Extended Properties=\"Excel 8.0;HDR=Yes;\";";
        public static DataTable GetDataTableFromExcel(string filePath, ref string sheetName)
        {
            OleDbConnection objCon = new OleDbConnection();
            objCon = new OleDbConnection(CONNECTION_STRING.Replace("<FILENAME>", filePath));
            DataSet dsImport = new DataSet();
            try
            {
                objCon.Open();
                DataTable dtSchema = objCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if ((null == dtSchema) || (dtSchema.Rows.Count <= 0))
                {
                    // Raise exception
                }
                if ((null != sheetName) && (0 != sheetName.Length))
                {
                    if (!CheckIfSheetNameExists(sheetName, dtSchema))
                    {
                        // Raise exception
                    }
                }
                else
                {
                    // Read the first sheet name from excel
                    sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                }
                new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", objCon).Fill(dsImport);
            }
            catch (Exception)
            {
                // Raise exception
            }
            finally
            {
                // Clean
                if (objCon != null)
                {
                    objCon.Close();
                    objCon.Dispose();
                }
            }
            return dsImport.Tables[0];
        }

        /// <summary>
        /// This method checks if the user entered sheetName exists in the Schema Table
        /// </summary>
        /// <param name="sheetName">Sheet name to be verified</param>
        /// <param name="dtSchema">schema table </param>
        private static bool CheckIfSheetNameExists(string sheetName, DataTable dtSchema)
        {
            foreach (DataRow dataRow in dtSchema.Rows)
            {
                if (sheetName == dataRow["TABLE_NAME"].ToString())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
