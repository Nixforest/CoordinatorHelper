using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace MainPrj.Util
{
    /// <summary>
    /// Ini file handler.
    /// </summary>
    public class INIHandle
    {
        private string _path;
        private string _EXE = Assembly.GetExecutingAssembly().GetName().Name;
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path file</param>
        public INIHandle(string path = null)
        {
            _path = new FileInfo(path ?? _EXE + ".ini").FullName.ToString();
        }
        /// <summary>
        /// Read a key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="section">Section</param>
        /// <returns>Value of key</returns>
        public string Read(string key, string section = null)
        {
            var retVal = new StringBuilder(255);
            GetPrivateProfileString(section ?? _EXE, key, "", retVal, 255, _path);
            return retVal.ToString();
        }
        /// <summary>
        /// Write value to a key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="section">Section</param>
        public void Write(string key, string value, string section = null)
        {
            WritePrivateProfileString(section ?? _EXE, key, value, _path);
        }
        /// <summary>
        /// Delete a key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="section">Section</param>
        public void DeleteKey(string key, string section = null)
        {
            Write(key, null, section ?? _EXE);
        }
        /// <summary>
        /// Delete a section.
        /// </summary>
        /// <param name="section">Section</param>
        public void DeleteSection(string section = null)
        {
            Write(null, null, section ?? _EXE);
        }
        /// <summary>
        /// Check if key is exist.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="section">Section</param>
        /// <returns>TRUE if value of key has length greater than 0, FALSE otherwise</returns>
        public bool IsKeyExist(string key, string section = null)
        {
            return Read(key, section).Length > 0;
        }
    }
}
