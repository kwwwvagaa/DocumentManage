//*******************************************
// 版权所有 黄正辉
// 文件名称：Log4NetHelper.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:21:43
// 功能描述：日子累
// 任务编号：档案管理系统
//*******************************************

using log4net;
using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace DM.Tools
{
    /// <summary>
    /// 功能描述:log4net
    /// 使用说明：复制log4net.config配置文件到程序，程序入口调用InitLog4Net进行初始化，在需要写日志的地方调用写日志函数
    /// 作　　者:beck.huang
    /// 创建日期:2018-07-24 10:51:46
    /// 任务编号:档案管理系统
    /// </summary>
    public class Log4NetHelper
    {
        private static string m_logFile;
        private static Dictionary<string, ILog> m_lstLog = new Dictionary<string, ILog>();
        /// <summary>
        /// 功能描述:初始化区域
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-24 10:41:10
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strLog4NetConfigFile">配置文件路径(如果为空则取程序目录下的log4net.config)</param>
        public static void InitLog4Net(string strLog4NetConfigFile = null)
        {
            if (string.IsNullOrEmpty(strLog4NetConfigFile))
            {
                strLog4NetConfigFile = HttpContext.Current.Server.MapPath("/Configs/log4net.config");
            }
            if (!System.IO.File.Exists(strLog4NetConfigFile))
            {
                throw new System.IO.FileNotFoundException("配置文件不存在");
            }
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(strLog4NetConfigFile));
            m_logFile = strLog4NetConfigFile;
            m_lstLog["info_logo"] = log4net.LogManager.GetLogger("info_logo");
            m_lstLog["error_logo"] = log4net.LogManager.GetLogger("error_logo");
            m_lstLog["debug_logo"] = log4net.LogManager.GetLogger("debug_logo");
            m_lstLog["warn_logo"] = log4net.LogManager.GetLogger("warn_logo");
        }

        /// <summary>
        /// 功能描述:写入常规日志
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-20 16:33:20
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strInfoLog">strInfoLog</param>
        /// <param name="ex">ex</param>
        public static void WriteInfoLog(string strInfoLog, Exception ex = null)
        {
            if (m_lstLog["info_logo"].IsInfoEnabled)
            {
                m_lstLog["info_logo"].Info(strInfoLog, ex);
            }
        }

        /// <summary>
        /// 功能描述:写入调试日志
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-20 16:33:20
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strDebugLog">strDebugLog</param>
        /// <param name="ex">ex</param>
        public static void WriteDebugLog(string strDebugLog, Exception ex = null)
        {
            if (m_lstLog["debug_logo"].IsInfoEnabled)
            {
                m_lstLog["debug_logo"].Debug(strDebugLog, ex);
            }
        }

        /// <summary>
        /// 功能描述:写入错误日志
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-20 16:33:27
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strErrLog">strErrLog</param>
        /// <param name="ex">ex</param>
        public static void WriteErrorLog(string strErrLog, Exception ex = null)
        {
            if (m_lstLog["error_logo"].IsErrorEnabled)
            {
                m_lstLog["error_logo"].Error(strErrLog, ex);
            }
        }

        /// <summary>
        /// 功能描述:写入错误日志
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-20 16:33:27
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strWarnLog">strWarnLog</param>
        /// <param name="ex">ex</param>
        public static void WriteWarnLog(string strWarnLog, Exception ex = null)
        {
            if (m_lstLog["warn_logo"].IsErrorEnabled)
            {
                m_lstLog["warn_logo"].Warn(strWarnLog, ex);
            }
        }

        /// <summary>
        /// 功能描述:写入日志
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-20 16:33:33
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strType">日志类型（对应log4net配置文件中logger.nama）</param>
        /// <param name="strLog">strLog</param>
        public static void WriteByLogType(string strType, string strLog)
        {
            if (!m_lstLog.ContainsKey(strType))
            {
                //判断是否存在节点
                if (!HasLogNode(strType))
                {
                    WriteErrorLog("log4net配置文件不存在【" + strType + "】配置");
                    return;
                }
                m_lstLog[strType] = log4net.LogManager.GetLogger(strType);
            }
            m_lstLog[strType].Error(strLog);
        }

        /// <summary>
        /// 功能描述:是否存在指定的配置
        /// 作　　者:beck.huang
        /// 创建日期:2018-07-20 16:39:48
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strNodeName">strNodeName</param>
        /// <returns>返回值</returns>
        private static bool HasLogNode(string strNodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(m_logFile);
            var lstNodes = doc.SelectNodes("//configuration/log4net/logger");
            foreach (XmlNode item in lstNodes)
            {
                if (item.Attributes["name"].Value.ToLower() == strNodeName)
                    return true;
            }
            return false;
        }
    }
}
