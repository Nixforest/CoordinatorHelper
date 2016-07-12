using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.Model
{
    [DataContract]
    public class MaterialBitmap : ICloneable
    {
        [DataMember(Name = "model", IsRequired = false)]
        private MaterialModel model;
        //[DataMember(Name = "bitmap", IsRequired = false)]
        private Bitmap bitmap;
        [DataMember(Name = "color", IsRequired = false)]
        private Color color;
        [DataMember(Name = "text", IsRequired = false)]
        private string text;
        /// <summary>
        /// Text.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        /// <summary>
        /// Material model.
        /// </summary>
        public MaterialModel Model
        {
            get { return model; }
            set { model = value; }
        }
        /// <summary>
        /// Bitmap object.
        /// </summary>
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }
        /// <summary>
        /// Background color of bitmap.
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        /// <summary>
        /// Close method.
        /// </summary>
        /// <returns>Clone object</returns>
        public object Clone()
        {
            return new MaterialBitmap()
            {
                Model  = this.model,
                Bitmap = this.bitmap,
                Color  = this.color,
                Text   = this.text
            };
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MaterialBitmap));
            try
            {
                js.WriteObject(ms, this);
                ms.Position = 0;
                var sr = new StreamReader(ms);
                retVal = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
            }
            return retVal;
        }
    }
}
