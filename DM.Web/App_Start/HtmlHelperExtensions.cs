using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Reflection;
using Km.HCM.PosCloud.Tools;
using Km.HCM.PosCloud.Web;
using Km.HCM.PosCloud.Models;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        #region Label
        #region 显示一个label
        /// <summary>
        /// 功能描述:显示一个label
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strText">文本</param>
        /// <param name="blnShowStar">是否显示红星</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString LabelEx(
            this HtmlHelper htmlHelper,
            string strText,
            bool blnShowStar = false)
        {
            string strHtml = string.Format("<div class=\"layui-form-label\">{0}<label>{1}</label></div>", blnShowStar ? "<label style=\"color:red\">*</label>" : "", strText);
            return new MvcHtmlString(strHtml);
        }
        #endregion

        #region 显示一个辅助提示信息Label
        /// <summary>
        /// 功能描述:显示一个辅助提示信息Label
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strText">文本</param>
        /// <param name="blnShowStar">是否显示红星</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString LabelAuxEx(
            this HtmlHelper htmlHelper,
            string strText)
        {
            string strHtml = string.Format("<div class=\"layui-form-mid layui-word-aux\">{0}</div>", strText);
            return new MvcHtmlString(strHtml);
        }
        #endregion
        #endregion

        #region 下拉列表
        #region 根据控制器产生一个下拉列表
        /// <summary>
        /// 功能描述:根据控制器产生一个下拉列表
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="blnIsNotNull">不允许空</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DropDownListEx(
            this HtmlHelper htmlHelper,
            string strName,
            bool blnIsNotNull,
            string strPlaceholder = "",
            bool blnReadOnly = false,
            bool blnDisabled = false)
        {
            if (string.IsNullOrEmpty(strPlaceholder))
                strPlaceholder = "-请选择-";
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format("<select name=\"{0}\" id=\"{0}\" lay-filter=\"{0}\" {1} {2} {3} >", strName, (blnIsNotNull ? "lay-verify=\"required\"" : ""),
                blnReadOnly ? "readonly" : "", blnDisabled ? "disabled" : ""));
            strHtml.AppendLine("<option value=\"\">" + strPlaceholder + "</option>");

            //strHtml.AppendLine("<option value=\"浙江\">浙江省</option>");
            //strHtml.AppendLine("<option value=\"你的工号\">江西省</option>");
            //strHtml.AppendLine("<option value=\"你最喜欢的老师\">福建省</option>");

            strHtml.AppendLine(" </select>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 根据字典生成下拉框
        /// <summary>
        /// 功能描述:根据字典生成下拉框
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="blnIsNotNull">不允许空</param>
        /// <param name="strDicID">字典id</param>
        /// <param name="strSelectValue">选中值</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DropDownListWithSource(
            this HtmlHelper htmlHelper,
            string strName,
            bool blnIsNotNull,
            Dictionary<string, object> lstSource,
            string strSelectValue = "",
            bool blnReadOnly = false,
            bool blnDisabled = false
            )
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format("<select name=\"{0}\" id=\"{0}\" {1} {2} {3} lay-search=\"\">", strName, (blnIsNotNull ? "lay-verify=\"required\"" : ""),
                blnReadOnly ? "readonly" : "", blnDisabled ? "disabled" : ""));
            strHtml.AppendLine(" <option value=\"\">-请选择-</option>");

            foreach (var item in lstSource)
            {
                strHtml.AppendLine(string.Format(" <option value=\"{0}\" {1}>{2}</option>", item.Key, !strSelectValue.IsEmpty() && strSelectValue == item.Key ? "selected" : "", item.Value));
            }

            strHtml.AppendLine(" </select>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion
        #endregion

        #region 文本框
        #region 文本框
        /// <summary>
        /// 功能描述:生成一个TextBox
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strValue">值</param>
        /// <param name="strplaceholder">水印文字</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TextBoxEx(
            this HtmlHelper htmlHelper,
            string strName,
            VerifyType verifyType,
            string strValue = "",
            string strPlaceholder = "",
            bool blnReadOnly = false,
            bool blnDisabled = false,
            string strVerificationRegex = "",
            string strVerificationMsg = "")
        {
            string strHtml = string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3} {4} value=\"{5}\" verify-custom=\"{6}\" verify-custom-msg=\"{7}\"/>",
                strName, (verifyType == VerifyType.none ? "" : verifyType.ToEnumString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                blnReadOnly ? "readonly" : "", blnDisabled ? "disabled" : "", strValue, strVerificationRegex, strVerificationMsg);
            return new MvcHtmlString(strHtml);
        }
        /// <summary>
        /// 功能描述:生成一个TextBox
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strValue">值</param>
        /// <param name="strplaceholder">水印文字</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TextBoxEx(
            this HtmlHelper htmlHelper,
            string strName,
            string verifyType,
            string strValue = "",
            string strPlaceholder = "",
            bool blnReadOnly = false,
            bool blnDisabled = false,
            string strVerificationRegex = "",
            string strVerificationMsg = "")
        {
            string strHtml = string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3} {4} value=\"{5}\" verify-custom=\"{6}\" verify-custom-msg=\"{7}\"/>",
                strName, verifyType, (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                blnReadOnly ? "readonly" : "", blnDisabled ? "disabled" : "", strValue, strVerificationRegex, strVerificationMsg);
            return new MvcHtmlString(strHtml);
        }
        #endregion

        /// <summary>
        /// 功能描述:弹出选择
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <param name="strName">strName</param>
        /// <param name="verifyType">verifyType</param>
        /// <param name="strValue">strValue</param>
        /// <param name="strPlaceholder">strPlaceholder</param>
        /// <param name="blnReadOnly">blnReadOnly</param>
        /// <param name="blnDisabled">blnDisabled</param>
        /// <param name="strVerificationRegex">strVerificationRegex</param>
        /// <param name="strVerificationMsg">strVerificationMsg</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TextBoxExEject(
           this HtmlHelper htmlHelper,
           string strName,
           string verifyType,
           string strValue = "",
           string strPlaceholder = "",
           bool blnReadOnly = false,
           bool blnDisabled = false,
           string strVerificationRegex = "",
           string strVerificationMsg = ""
           )
        {
            string strHtml = string.Format(" <input style=\"position:absolute;right:24px;left:0px;top:0px;border-right-width: 0px;\" type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3} {4} value=\"{5}\" verify-custom=\"{6}\" verify-custom-msg=\"{7}\"/> "
                + "<div class=\"layui-btn layui-btn-primary layui-icon layui-icon-more-vertical\" style=\"position:absolute;right:0px;top:0px;padding-left: 0px;padding-right: 0px;width: 25px;cursor: pointer;\"></div>",

                strName, verifyType, (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                blnReadOnly ? "readonly" : "", blnDisabled ? "disabled" : "", strValue, strVerificationRegex, strVerificationMsg);
            return new MvcHtmlString(strHtml);
        }

        #region 多行文本框
        /// <summary>
        /// 功能描述:生成一个多行文本框
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strValue">值</param>
        /// <param name="strplaceholder">水印文字</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TextBoxAreaEx(
            this HtmlHelper htmlHelper,
            string strName,
            VerifyType verifyType,
            string strValue = "",
            string strPlaceholder = "",
            bool blnReadOnly = false,
            bool blnDisabled = false)
        {
            string strHtml = string.Format(" <textarea name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" class=\"layui-textarea\" {2} {3} {4} value=\"{5}\"/>",
                strName, (verifyType == VerifyType.none ? "" : verifyType.ToEnumString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                blnReadOnly ? "readonly" : "", blnDisabled ? "disabled" : "", strValue);
            return new MvcHtmlString(strHtml);
        }
        #endregion
        #endregion

        #region 时间控件
        #region 生成一个日期控件
        /// <summary>
        /// 功能描述:生成一个日期控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">日期格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DateBox(
            this HtmlHelper htmlHelper,
            string strName,
            VerifyType verifyType,
            string strPlaceholder = "",
            string strFormat = "yyyy-MM-dd",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, (verifyType == VerifyType.none ? "" : verifyType.ToString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setDateBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        /// <summary>
        /// 功能描述:生成一个日期控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">日期格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DateBox(
            this HtmlHelper htmlHelper,
            string strName,
            string verifyType,
            string strPlaceholder = "",
            string strFormat = "yyyy-MM-dd",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, verifyType, (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setDateBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 生成一个日期范围控件
        /// <summary>
        /// 功能描述:生成一个日期范围控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">日期格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DateRangeBox(
            this HtmlHelper htmlHelper,
            string strName,
            VerifyType verifyType,
            string strPlaceholder = "",
            string strFormat = "yyyy-MM-dd",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, (verifyType == VerifyType.none ? "" : verifyType.ToString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setDateRangeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 生成一个时间控件
        /// <summary>
        /// 功能描述:生成一个时间控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">时间格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TimeBox(
           this HtmlHelper htmlHelper,
           string strName,
           VerifyType verifyType,
           string strPlaceholder = "",
            string strFormat = "HH:mm:ss",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, (verifyType == VerifyType.none ? "" : verifyType.ToString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setTimeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        /// <summary>
        /// 功能描述:生成一个时间控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">时间格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TimeBox(
           this HtmlHelper htmlHelper,
           string strName,
           string verifyType,
           string strPlaceholder = "",
            string strFormat = "HH:mm:ss",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, verifyType, (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setTimeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 生成一个时间范围控件
        /// <summary>
        /// 功能描述:生成一个时间范围控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">时间格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString TimeRangeBox(
           this HtmlHelper htmlHelper,
           string strName,
           VerifyType verifyType,
           string strPlaceholder = "",
            string strFormat = "HH:mm:ss",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, (verifyType == VerifyType.none ? "" : verifyType.ToString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setTimeRangeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 生成一个日期时间控件
        /// <summary>
        /// 功能描述:生成一个日期时间控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">日期时间格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DateTimeBox(
           this HtmlHelper htmlHelper,
           string strName,
           VerifyType verifyType,
           string strPlaceholder = "",
            string strFormat = "yyyy-MM-dd HH:mm:ss",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, (verifyType == VerifyType.none ? "" : verifyType.ToString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setDateTimeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        /// <summary>
        /// 功能描述:生成一个日期时间控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">日期时间格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DateTimeBox(
           this HtmlHelper htmlHelper,
           string strName,
           string verifyType,
           string strPlaceholder = "",
            string strFormat = "yyyy-MM-dd HH:mm:ss",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, verifyType, (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setDateTimeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 生成一个日期时间范围控件
        /// <summary>
        /// 功能描述:生成一个日期时间范围控件
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="verifyType">验证规则</param>
        /// <param name="strPlaceholder">水印文字</param>
        /// <param name="strFormat">日期时间格式</param>
        /// <param name="blnReadOnly">是否只读</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString DateTimeRangeBox(
           this HtmlHelper htmlHelper,
           string strName,
           VerifyType verifyType,
           string strPlaceholder = "",
            string strFormat = "yyyy-MM-dd HH:mm:ss",
            bool blnReadOnly = true)
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format(" <input type=\"text\" name=\"{0}\" id=\"{0}\" lay-verify=\"{1}\" autocomplete=\"off\" class=\"layui-input\" {2} {3}/>",
                           strName, (verifyType == VerifyType.none ? "" : verifyType.ToString()), (!strPlaceholder.IsEmpty() ? "placeholder=\"" + strPlaceholder + "\"" : ""),
                           blnReadOnly ? "readonly=\"\"" : ""));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("$(document).ready(function () {");
            strHtml.AppendLine("    tool.Date.setDateTimeRangeBox('" + strName + "','" + strFormat + "');");
            strHtml.AppendLine("});");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion
        #endregion

        #region CheckBox
        #region 显示一个复选框
        /// <summary>
        /// 功能描述:显示一个复选框
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="strText">文本</param>
        /// <param name="blnChecked">是否选中</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString CheckBoxEx(
            this HtmlHelper htmlHelper,
            string strName,
            string strText,
            bool blnChecked = false,
            bool blnDisabled = false)
        {
            string strHtml = string.Format(" <input type=\"checkbox\" name=\"{0}\" id=\"{0}\" lay-skin=\"primary\" title=\"{1}\" {2} {3}>", strName, strText,
                blnChecked ? "checked=\"\"" : "", blnDisabled ? "disabled" : "");
            return new MvcHtmlString(strHtml);
        }
        #endregion

        #region 显示一个扩展复选框
        /// <summary>
        /// 功能描述:显示一个扩展复选框
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="strText">文本</param>
        /// <param name="blnChecked">是否选中</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString CheckBoxEx2(
            this HtmlHelper htmlHelper,
            string strName,
            string strText,
            bool blnChecked = false,
            bool blnDisabled = false)
        {
            string strHtml = string.Format(" <input type=\"checkbox\" name=\"{0}\" id=\"{0}\" title=\"{1}\" {2} {3}>", strName, strText,
                blnChecked ? "checked=\"\"" : "", blnDisabled ? "disabled" : "");
            return new MvcHtmlString(strHtml);
        }
        #endregion

        #region 显示一个开关复选框
        /// <summary>
        /// 功能描述:显示一个开关
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="strText">开关文字，格式为”开|关“</param>
        /// <param name="blnChecked">是否选中</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString CheckBoxEx3(
            this HtmlHelper htmlHelper,
            string strName,
            string strText = "ON|OFF",
            bool blnChecked = false,
            bool blnDisabled = false)
        {
            string strHtml = string.Format(" <input type=\"checkbox\" name=\"{0}\" id=\"{0}\" lay-skin=\"switch\" lay-text=\"{1}\" {2} {3}>", strName, strText,
                blnChecked ? "checked=\"\"" : "", blnDisabled ? "disabled" : "");
            return new MvcHtmlString(strHtml);
        }
        #endregion

        #endregion

        #region radioButton
        #region 显示一个单选框
        /// <summary>
        /// 功能描述:显示一个单选框
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="lstSource">数据源</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString RadioButtonEx(
            this HtmlHelper htmlHelper,
            string strName,
            Dictionary<string, object> lstSource)
        {
            StringBuilder strHtml = new StringBuilder();           
            foreach (var item in lstSource)
            {
                strHtml.AppendLine(string.Format(" <input type=\"radio\" name=\"{0}\" value=\"{1}\" title=\"{2}\">", strName, item.Key, item.Value));
            }
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #endregion
        #region 显示一个单选框
        /// <summary>
        /// 功能描述:显示一个单选框
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="strName">绑定名称</param>
        /// <param name="strText">文本</param>
        /// <param name="strValue">值</param>
        /// <param name="blnChecked">是否选中</param>
        /// <param name="blnDisabled">是否禁用</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString RadioButtonEx(
            this HtmlHelper htmlHelper,
            string strName,
            string strText,
            string strValue,
            bool blnChecked = false,
            bool blnDisabled = false)
        {
            string strHtml = string.Format(" <input type=\"radio\" name=\"{0}\" value=\"{1}\"  title=\"{2}\" {3} {4}>", strName, strValue, strText,
                blnChecked ? "checked=\"\"" : "", blnDisabled ? "disabled" : "");
            return new MvcHtmlString(strHtml);
        }
        #endregion

        #region 按钮
        #region 显示一个提交按钮
        /// <summary>
        /// 功能描述:显示一个提交按钮
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <param name="strName">strName</param>
        /// <param name="strUrl">strUrl</param>
        /// <param name="strText">strText</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString SubmitButtonEx(
          this HtmlHelper htmlHelper,
          string strName,
          string strUrl,
          string strText = "提交")
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine(string.Format("<button class=\"layui-btn\" lay-submit=\"\" name=\"{0}\" id=\"{0}\" lay-filter=\"{0}\">{1}</button>", strName, strText));
            strHtml.AppendLine("<script>");
            strHtml.AppendLine("    tool.form.setPost(\"" + strName + "\",\"" + strUrl + "\");");
            strHtml.AppendLine("</script>");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        #region 显示一个重置按钮
        /// <summary>
        /// 功能描述:显示一个重置按钮
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <param name="strName">strName</param>
        /// <param name="strText">strText</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString ResetButtonEx(
          this HtmlHelper htmlHelper,
          string strName,
          string strText = "重置")
        {
            string strHtml = string.Format("<button type=\"reset\" class=\"layui-btn layui-btn-primary\" name=\"{0}\" id=\"{0}\" lay-filter=\"{0}\">{1}</button>", strName, strText);
            return new MvcHtmlString(strHtml);
        }
        #endregion
        #endregion

        #region 表格
        #region 生成表格列
        /// <summary>
        /// 功能描述:显示一个提交按钮
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <param name="strName">strName</param>
        /// <param name="strUrl">strUrl</param>
        /// <param name="strText">strText</param>
        /// <returns>返回值</returns>
        public static MvcHtmlString CreatTableColumens(
          this HtmlHelper htmlHelper,
            bool blnCheckBox,
            List<ccm_TableDefaults> lstColumns
          )
        {
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendLine("[[");
            if (blnCheckBox)
            {
                strHtml.AppendLine("{ checkbox: true, fixed: true },");
            }
            foreach (var item in lstColumns)
            {
                string strTempCode = string.Empty;
                if (!item.F_FormatType.IsEmpty())
                {
                    switch (item.F_FormatType)
                    {
                        case "YesNo":
                            strTempCode = "if(value>0) return '" + CheckBoxEx(htmlHelper, "", "", true, true).ToHtmlString()
                               + "';else return '" + CheckBoxEx(htmlHelper, "", "", false, true).ToHtmlString() + "';";
                            break;
                        case "Enabled":
                            strTempCode = "if(value>0) return '" + CheckBoxEx3(htmlHelper, "", "启用|禁用", true, true).ToHtmlString()
                                + "';else return '" + CheckBoxEx3(htmlHelper, "", "启用|禁用", false, true).ToHtmlString() + "';";
                            break;
                        case "Custom":
                            strTempCode = item.F_FormatCode;
                            break;
                        default:
                            break;
                    }
                }
                strHtml.AppendLine("{" + string.Format(" field: '{0}', title: '{1}',{2} sort: {3}, fixed: {4}, {5} {6} align:'{7}',",
                    item.F_Field,
                    item.F_ColumnText,
                    item.F_Width.HasValue && item.F_Width.Value > 0 ? ("width:" + item.F_Width + ",") : "",
                    item.F_IsSortField.HasValue && item.F_IsSortField.Value == 1 ? "true" : "false",
                    item.F_IsFixed.HasValue && item.F_IsFixed.Value == 1 ? "true" : "false",
                    strTempCode.IsEmpty() ? "" : ("templet: function(d){ var value=d." + item.F_Field + ";  " + strTempCode + "},"),
                    item.F_IsHide.HasValue && item.F_IsHide.Value == 1 ? "hide:true," : "",
                    item.F_AlignType.IsEmpty() ? "left" : item.F_AlignType) + "},");
            }
            strHtml.AppendLine("]]");
            return new MvcHtmlString(strHtml.ToString());
        }
        #endregion

        /// <summary>
        /// 功能描述:获取表格偏移高度
        /// </summary>
        /// <param name="htmlHelper">htmlHelper</param>
        /// <param name="blnIsShowToolBar">是否显示工具栏</param>
        /// <param name="blnIsShowForm">是否显示表单</param>
        /// <param name="intFormRowCount">表单行数</param>
        /// <returns>返回值</returns>
        public static int GetTableOffset(this HtmlHelper htmlHelper, bool blnIsShowToolBar, bool blnIsShowForm, int intFormRowCount)
        {
            int intOffset = 35;
            if (blnIsShowToolBar)
                intOffset += 55;
            if (blnIsShowForm && intFormRowCount > 0)
            {
                intOffset += 17 + 43 * intFormRowCount;
            }
            return intOffset;
        }
        #endregion

    }
}
