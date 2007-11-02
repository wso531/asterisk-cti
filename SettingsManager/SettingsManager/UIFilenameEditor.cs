// Copyright (C) 2007 Bruno Salzano
// http://centralino-voip.brunosalzano.com
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
//
// As a special exception, you may use this file as part of a free software
// library without restriction.  Specifically, if other files instantiate
// templates or use macros or inline functions from this file, or you compile
// this file and link it with other files to produce an executable, this
// file does not by itself cause the resulting executable to be covered by
// the GNU General Public License.  This exception does not however
// invalidate any other reasons why the executable file might be covered by
// the GNU General Public License.
//
// This exception applies only to the code released under the name GNU
// SettingsManager.  If you copy code from other releases into a copy of GNU
// SettingsManager, as the General Public License permits, the exception does
// not apply to the code that you add in this way.  To avoid misleading
// anyone as to the status of such modified files, you must delete
// this exception notice from them.
//
// If you write modifications of your own for SettingsManager, it is your choice
// whether to permit this exception to apply to your modifications.
// If you do not wish that, delete this exception notice.
//


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Reflection;

namespace SettingsManager
{
    #region " Filename Editor "

    public class UIFilenameEditor : System.Drawing.Design.UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if ((context != null) && (context.Instance != null))
            {
                return UITypeEditorEditStyle.Modal;
            }
            return UITypeEditorEditStyle.None;
        }

        [RefreshProperties(RefreshProperties.All)]
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            if (context == null || provider == null || context.Instance == null)
            {
                return base.EditValue(provider, value);
            }

            FileDialog fileDlg;
            if (context.PropertyDescriptor.Attributes[typeof(SaveFileAttribute)] == null)
            {
                fileDlg = new OpenFileDialog();
            }
            else
            {
                fileDlg = new SaveFileDialog();
            }
            fileDlg.Title = "Select " + context.PropertyDescriptor.DisplayName;
            fileDlg.FileName = (string)value;

            FileDialogFilterAttribute filterAtt = (FileDialogFilterAttribute)context.PropertyDescriptor.Attributes[typeof(FileDialogFilterAttribute)];
            if ((filterAtt != null)) fileDlg.Filter = filterAtt.Filter;
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                value = fileDlg.FileName;
            }
            fileDlg.Dispose();
            return value;
        }
    }

    #region " Filter attribute "
    [AttributeUsage(AttributeTargets.Property)]
    public class FileDialogFilterAttribute : Attribute
    {
        private string _filter;

        public string Filter
        {
            get { return this._filter; }
        }

        public FileDialogFilterAttribute(string filter)
            : base()
        {
            this._filter = filter;
        }
    }
    #endregion

    #region " 'Save file' attribute - indicates that SaveFileDialog must be shown "
    [AttributeUsage(AttributeTargets.Property)]
    public class SaveFileAttribute : Attribute
    {
    }
    #endregion

    #endregion
}